using System;
using System.Collections.Generic; 
using System.Text;

namespace VISAP商科应用
{
    /// <summary>比较两个数的大小</summary>
    class CompareNumber
    {
      
        public static  int Compare( BigNumber one, BigNumber two)
        {
            if ( one.IsPlus && two.IsPlus )
            {
                return ComparePlus(one,two );
            }
            else if ( one.IsPlus && !two.IsPlus )
            {
                return 1;
            }
            else if ( !one.IsPlus && two.IsPlus )
            {
                return -1;
            }
            else
            {
                return ( -1 ) * ComparePlus(one ,two );
            }

        }

        static int ComparePlus( BigNumber one, BigNumber two )
        {
            BigCalculate.RemoveStartZero( one.IntPart );
            BigCalculate.RemoveStartZero( two.IntPart );
            int minDecimalLength = one.DecimalPart.Count < two.DecimalPart.Count ? one.DecimalPart.Count : two.DecimalPart.Count;
            //通过正数的长短比较
            if ( one.IntPart.Count > two.IntPart.Count )
                return 1;
            else if ( one.IntPart.Count < two.IntPart.Count )
                return -1;
            else
            {
                //从最高位依次比较
                for ( int i = 0; i < one.IntPart.Count; i++ )
                {
                    if ( one.IntPart[i] > two.IntPart[i] )
                        return 1;
                    else if ( one.IntPart[i] < two.IntPart[i] )
                        return -1;
                }
                //比较小数部分，行判断是否有小数位
                if ( one.DecimalPart .Count == 0 && two.DecimalPart .Count != 0 )
                    return -1;
                else if ( one.DecimalPart .Count != 0 && two.DecimalPart .Count == 0 )
                    return 1;
                else if ( one.DecimalPart .Count == 0 && two.DecimalPart .Count == 0 )
                    return 0;
                else
                {
                    for ( int i = 0; i < minDecimalLength; i++ )
                    {
                        if ( one.DecimalPart[i] > two.DecimalPart[i] )
                            return 1;
                        else if ( one.DecimalPart[i] < two.DecimalPart[i] )
                            return -1;
                    }
                    if ( one.DecimalPart .Count > two.DecimalPart .Count )
                        return 1;
                    else if ( one.DecimalPart .Count < two.DecimalPart .Count )
                        return -1;
                }
                return 0;
            }
        }
    }
}
