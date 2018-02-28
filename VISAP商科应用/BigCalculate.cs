using System;
using System.Collections.Generic;
using System.Text;

namespace VISAP商科应用
{
    //对大数进行运算
    internal class BigCalculate
    {
        /// <summary>加</summary>
        public static BigNumber Add(BigNumber one, BigNumber two) {
            BigNumber oneAbsolute = one.AbsoluteNumber;
            BigNumber twoAbsolute = two.AbsoluteNumber;
            //正数加正数
            if (one.IsPlus && two.IsPlus) {
                return PlusAdd(one, two);
            }
                //正数加负数
            else if (one.IsPlus && !two.IsPlus) {
                return Minus(oneAbsolute, twoAbsolute);
            }
                //负数加正数
            else if (!one.IsPlus && two.IsPlus) {
                return Add(two, one);
            }
                //负数加负数
            else if (!one.IsPlus && !two.IsPlus) {
                BigNumber result = PlusAdd(one.AbsoluteNumber, two.AbsoluteNumber);
                return new BigNumber(result.IntPart, result.DecimalPart, false);
            }
            throw new Exception("不可能到达的地方");
        }

        /// <summary>减</summary>
        public static BigNumber Minus(BigNumber one, BigNumber two) {
            BigNumber oneAbsolute = one.AbsoluteNumber;
            BigNumber twoAbsolute = two.AbsoluteNumber;
            //正数减正数
            if (one.IsPlus && two.IsPlus) {
                if (oneAbsolute.CompareTo(twoAbsolute) == 1)
                    return PlusMinus(one, two);
                else if (oneAbsolute.CompareTo(twoAbsolute) == -1)
                    return PlusMinus(two, one).ReverseNumber;
                else
                    return BigNumber.Zero;
            }
                //正数减负数
            else if (one.IsPlus && !two.IsPlus) {
                return PlusAdd(oneAbsolute, twoAbsolute);
            }
                //负数减正数
            else if (!one.IsPlus && two.IsPlus) {
                return PlusAdd(oneAbsolute, twoAbsolute).ReverseNumber;
            }
                //负数减负数
            else if (!one.IsPlus && !two.IsPlus) {
                return Add(one, twoAbsolute);
            }
            throw new Exception("不可能到达的地方");
        }

        /// <summary> 乘  </summary>
        public static BigNumber Multiply(BigNumber one, BigNumber two) {
            List<int> oneText = new List<int>();
            List<int> twoText = new List<int>();
            oneText.AddRange(one.IntPart);
            oneText.AddRange(one.DecimalPart);
            twoText.AddRange(two.IntPart);
            twoText.AddRange(two.DecimalPart);
            List<int> resultText = Multiply(oneText, twoText);

            int decimalLength = one.DecimalPart.Count + two.DecimalPart.Count;
            List<int> intPart = resultText.GetRange(0, resultText.Count - decimalLength);
            List<int> decimalPart = resultText.GetRange(resultText.Count - decimalLength, decimalLength);
            return new BigNumber(intPart, decimalPart, !(one.IsPlus ^ two.IsPlus));
        }

        /// <summary>除</summary>
        public static BigNumber Division(BigNumber one, BigNumber two) {
            return Division(one, two, 50);
        }

        internal static BigNumber Division(BigNumber one, BigNumber two, int precision) {
            List<int> oneInt = new List<int>();
            List<int> oneDecimal = new List<int>();
            oneInt.AddRange(one.IntPart);
            oneDecimal.AddRange(one.DecimalPart);
            List<int> twoText = new List<int>();
            twoText.AddRange(two.IntPart);
            twoText.AddRange(two.DecimalPart);
            RemoveStartZero(twoText);
            //将15/2.3 移位为 150/23  //DecimalLength
            for (int i = 0; i < two.DecimalPart.Count; i++) {
                if (oneDecimal.Count != 0) {
                    oneInt.Add(oneDecimal[0]);
                    oneDecimal.RemoveAt(0);
                } else {
                    oneInt.Add(0);
                }
            }
            List<int> resultInt = new List<int>();
            List<int> resultDecimal = new List<int>();

            int index = twoText.Count < oneInt.Count ? twoText.Count - 1 : oneInt.Count - 1;
            List<int> div = oneInt.GetRange(0, index + 1);
            //正数部分的除法
            while (true) {
                resultInt.Add(Division(div, twoText));
                div = IntMinus(div, Multiply(twoText, new List<int> { resultInt[resultInt.Count - 1] }), 0);
                index++;
                if (index >= oneInt.Count)
                    break;
                div.Add(oneInt[index]);
            }
            index = 0;
            //小数部分的除法
            while (true) {
                //满足精度后退出
                if (resultDecimal.Count >= precision)
                    break;
                if (index >= oneDecimal.Count)
                    div.Add(0);
                else {
                    div.Add(oneDecimal[index]);
                }
                int r = Division(div, twoText);
                resultDecimal.Add(r);
                div = IntMinus(div, Multiply(twoText, new List<int> { r }), 0);
                index++;
            }
            return new BigNumber(resultInt, resultDecimal, !(one.IsPlus ^ two.IsPlus));
        }

        //两个正数的相加
        private static BigNumber PlusAdd(BigNumber one, BigNumber two) {
            List<int> intPart = new List<int>();
            List<int> decimalPare = new List<int>();
            int intAdd = 0;

            //将两数的小数部分相加
            if (one.DecimalPart.Count >= two.DecimalPart.Count)
                decimalPare = DecimalAdd(one.DecimalPart, two.DecimalPart, ref intAdd);
            else
                decimalPare = DecimalAdd(two.DecimalPart, one.DecimalPart, ref intAdd);

            //将两数的正数部分相加
            //if ( one.IntPart.Count >= two.IntPart.Count )
            //    intPart = IntAddBigAddSmall( one.IntPart, two.IntPart, intAdd );
            //else
            //    intPart = IntAddBigAddSmall( two.IntPart, one.IntPart, intAdd );
            intPart = IntAdd(one.IntPart, two.IntPart, intAdd);
            return new BigNumber(intPart, decimalPare, true);
        }

        //小数部分相加 ,one的长度比two长
        private static List<int> DecimalAdd(List<int> one, List<int> two, ref int intAdd) {
            List<int> result = new List<int>();
            int oneResult = 0;
            for (int i = 0; i < one.Count; i++)
                result.Add(one[i]);

            for (int i = two.Count - 1; i >= 0; i--) {
                oneResult = result[i] + two[i];
                result[i] = (int)(oneResult % BigNumber.Max);
                if (oneResult > BigNumber.Max - 1) {
                    if (i != 0)
                        result[i - 1]++;
                    else
                        //进位到整数部分
                        intAdd = 1;
                }
            }
            return result;
        }

        static internal List<int> IntAdd(List<int> one, List<int> two, int intAdd) {
            RemoveStartZero(one);
            RemoveStartZero(two);
            if (one.Count >= two.Count)
                return IntAddBigAddSmall(one, two, intAdd);
            return IntAddBigAddSmall(two, one, intAdd);
        }

        /// <summary>整数部分相加，one的长度比two长</summary>
        static List<int> IntAddBigAddSmall(List<int> one, List<int> two, int intAdd) {
            List<int> result = new List<int>();
            int oneResult = 0;

            for (int i = 0; i < one.Count; i++)
                result.Add(one[i]);
            result[result.Count - 1] += intAdd;

            for (int i = 0; i < result.Count; i++) {
                if (i > two.Count - 1) {
                    oneResult = result[result.Count - 1 - i];
                } else {
                    oneResult = result[result.Count - 1 - i] + two[two.Count - 1 - i];
                }
                result[result.Count - 1 - i] = oneResult % BigNumber.Max;
                if (oneResult > BigNumber.Max - 1) {
                    if (i != result.Count - 1) {
                        result[result.Count - 2 - i]++;
                    } else {
                        result.Insert(0, 1);
                    }
                }
            }
            return result;
        }

        /// <summary>两正数相减，并且one大于two</summary>
        private static BigNumber PlusMinus(BigNumber one, BigNumber two) {
            int minusInt = 0;
            List<int> decimalPart = new List<int>();
            List<int> intPart = new List<int>();
            decimalPart = DecimalMinus(one.DecimalPart, two.DecimalPart, ref minusInt);

            intPart = IntMinus(one.IntPart, two.IntPart, minusInt);
            return new BigNumber(intPart, decimalPart, true);
        }

        //小数部分相减,one所在的数大，two所在的数小
        private static List<int> DecimalMinus(List<int> one, List<int> two, ref int intMinus) {
            int oneResult = 0;
            List<int> result = new List<int>();
            for (int i = 0; i < one.Count; i++)
                result.Add(one[i]);

            //将result的长度和two的长度弄成一样
            if (result.Count < two.Count) {
                for (int i = 0; i < two.Count - one.Count; i++)
                    result.Add(0);
            }
            for (int i = two.Count - 1; i >= 0; i--) {
                oneResult = result[i] - two[i];
                if (oneResult < 0) {

                    result[i] = (int)(oneResult + BigNumber.Max);
                    //下面是找高位借数
                    //这里是从正数中借
                    if (i == 0)
                        intMinus = 1;
                    //这里中从小数部分的高一位借
                    else
                        result[i - 1]--;
                } else {
                    result[i] = (int)oneResult;
                }
            }
            return result;
        }
        /// <summary>整数部分相减,one所在的数大，two所在的数小</summary>
        internal static List<int> IntMinus(List<int> one, List<int> two) {
            return IntMinus(one, two, 0);
        }
        /// <summary>整数部分相减,one所在的数大，two所在的数小</summary>
        internal static List<int> IntMinus(List<int> one, List<int> two, int Minus) {
            RemoveStartZero(one);
            RemoveStartZero(two);
            List<int> result = new List<int>();
            int oneResult;
            if (one.Count == 0)
                return new List<int>() { 0 };
            for (int i = 0; i < one.Count; i++)
                result.Add(one[i]);
            result[result.Count - 1] -= Minus;

            for (int i = 0; i < two.Count; i++) {
                oneResult = result[result.Count - 1 - i] - two[two.Count - 1 - i];
                if (oneResult < 0) {
                    result[result.Count - 1 - i] = oneResult + BigNumber.Max;
                    result[result.Count - 2 - i]--;
                } else {
                    result[result.Count - 1 - i] = oneResult;
                }
            }
            return result;
        }

        //两个List<int> 的乘法
        internal static List<int> Multiply(List<int> one, List<int> two) {
            #region "原始的乘法运算"
            //result是用倒序来存储，最后再反序 Yes
            List<int> result = new List<int>();
            //每位数相乘的暂时结果
            int oneResult = 0;
            //这个用于进位
            int AddResult = 0;

            for (int j = 0; j < two.Count; j++) {
                for (int i = 0; i < one.Count; i++) {
                    oneResult = one[one.Count - 1 - i] * two[two.Count - 1 - j] + AddResult;
                    AddResult = oneResult / BigNumber.Max;

                    if (result.Count == i + j) {
                        result.Add(oneResult % BigNumber.Max);
                    } else {
                        result[i + j] += oneResult % BigNumber.Max;
                        if (result[i + j] > BigNumber.Max - 1) {
                            result[i + j] = result[i + j] % BigNumber.Max;
                            AddResult++;
                        }
                    }
                    if (i == one.Count - 1 && AddResult != 0) {
                        result.Add(AddResult);
                        AddResult = 0;
                    }
                }
            }
            result.Reverse();
            return result;

            #endregion
            //经过测试，发现没有多少的性能提升
            #region "用空间换时间后的乘法"
            //List<List<int>> indexResult = new List<List<int>>( 10 );
            //List<int> result = new List<int>();
            //indexResult.Add( null );
            //for ( int i = 1; i <= 9; ++i )
            //{
            //    List<int> t = new List<int>();
            //    for ( int j = 0; j < one.Count; ++j )
            //    {
            //        t.Add( one[j] * i );
            //        //indexResult[i].Add( one[j] * i );
            //    }
            //    indexResult.Add( t );
            //}
            //for ( int i = 0; i < two.Count; ++i )
            //{
            //    for ( int j = 0; j < indexResult[1].Count; ++j )
            //    {
            //        if ( two[two.Count - 1 - i] == 0 )
            //            continue;
            //        if ( result.Count <= i + j )
            //        {
            //            result.Add( indexResult[two[two.Count - 1 - i]][indexResult[two[two.Count - 1 - i]].Count - 1 - j] );
            //        }
            //        else
            //        {
            //            result[i + j] += indexResult[two[two.Count - 1 - i]][indexResult[two[two.Count - 1 - i]].Count - 1 - j];
            //        }
            //    }
            //}
            //int add = 0;
            //for ( int i = 0; i < result.Count; ++i )
            //{
            //    result[i] += add;
            //    add = result[i] / 10;
            //    result[i] -= add * 10;
            //}
            //if ( add != 0 )
            //    result.Add( add );
            //result.Reverse();
            //return result;
            #endregion

        }
        internal static List<int> Multiply(int one, int two) {
            return Multiply(new List<int>() { one }, new List<int>() { two });
        }
        /// <summary>两个List int的除法，只进行一次运算one的位数不会大于two</summary>    
        static int Division(List<int> one, List<int> two) {
            RemoveStartZero(one);
            RemoveStartZero(two);
            //List<int> result = new List<int>();
            if (two.Count > one.Count) {
                //result.Add( 0 );
                return 0;
            }
            //用于一次除法的数
            //List<int> divisioned = one.GetRange( 0, two.Count );
            //int index = two.Count;
            //while ( true )
            //{
            int i = BigNumber.Max / 2;  //进行试商的数
            int low = 0;
            int top = BigNumber.Max - 1;
            //结果连1都大了
            if (CompareList(Multiply(two, new List<int>() { 1 }), one) == 1) {
                //divisioned = IntMinus( divisioned, Multiply( two, new List<int> { low } ), 0 );
                //如果商是0，那么这次的被除数不变
                //result.Add( 0 );
                //break;
                return 0;
            }
            //如果连9999都小了
            if (CompareList(Multiply(two, new List<int>() { BigNumber.Max - 1 }), one) == -1) {
                //divisioned = IntMinus( divisioned, Multiply( two, new List<int> { BigNumber.Max - 1 } ), 0 );
                //result.Add(  );
                //break;
                return BigNumber.Max - 1;
            }
            while (true) {

                int c = CompareList(Multiply(two, new List<int> { i }), one);

                //商小了
                if (c == -1) {
                    low = i;
                    i = (low + top) / 2;  //这里不可能越界
                }
                    //商大了
                else if (c == 1) {
                    top = i;
                    i = (low + top) / 2;
                }
                    //刚好用这个商除法可以除尽
                else {
                    //divisioned.Clear();
                    //divisioned.Add( 0 );
                    //result.Add( i );
                    //break;
                    return i;
                }
                //已找到合适的商
                if (low + 1 == top) {
                    //result.Add( low );
                    //divisioned = IntMinus( divisioned, Multiply( two, new List<int> { low } ), 0 );
                    //break;
                    return low;
                }
            }
            //if ( index >= one.Count )
            //    break;
            //divisioned.Add( one[index] );
            //index++;
            ////}

            //return result;
        }
        /// <summary>比较两个用List表示的大小</summary>
        internal static int CompareList(List<int> one, List<int> two) {
            RemoveStartZero(one);
            RemoveStartZero(two);
            if (one.Count > two.Count)
                return 1;
            else if (one.Count < two.Count)
                return -1;
            else {
                for (int i = 0; i < one.Count; i++) {
                    if (one[i] > two[i])
                        return 1;
                    else if (one[i] < two[i])
                        return -1;
                }
                return 0;
            }

        }
        /// <summary>移去整数部分前面的0</summary>
        public static void RemoveStartZero(List<int> one) {
            while (true) {
                if (one.Count == 0)
                    return;
                if (one[0] == 0 && one.Count != 1)
                    one.RemoveAt(0);
                else
                    return;
            }

        }



    }
    /* 开始的想法是先将每位上的数相加，最后再遍历一次，进行进位运算，但思考下了后，就放弃了这种方法，
     * 因为这样就要对每位上的数遍历两次，效率太低
     */
}
