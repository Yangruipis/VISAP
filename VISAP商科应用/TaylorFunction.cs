/*============================================
 * 类名 :TaylorFunction
 * 描述 :计算泰勒公式的静态类
 *   
 * 创建时间: 2011-2-5 22:10:52
 * Blog:   http://home.cnblogs.com/xiangism
 *============================================*/
using System;
using System.Collections.Generic;

using System.Text;

namespace VISAP商科应用
{
    /// <summary>计算泰勒公式的静态类</summary>
    class TaylorFunction
    {
        //static BigNumber precision = new BigNumber( "100" );
        static BigNumber symbol = new BigNumber("-1");

        /// <summary>正弦的泰勒公式</summary>
        public static BigNumber Sine(BigNumber value, int precision) {
            BigNumber sum = new BigNumber("0");

            for (BigNumber n = new BigNumber("0"); ; n++) {
                BigNumber r = BigNumber.Division(symbol.Power(n) * value.Power(1 + 2 * n), (1 + 2 * n).Factorial(), precision + 1);

                if (r.GetPrecision(0) > precision)
                    break;
                sum = sum + r;
            }
            Remove(sum, precision);
            return sum;
        }

        /// <summary>余弦的泰勒公式</summary>
        public static BigNumber Cosine(BigNumber value, int precision) {
            BigNumber sum = new BigNumber("0");

            for (BigNumber n = new BigNumber("0"); ; n++) {
                BigNumber r = BigNumber.Division(symbol.Power(n) * value.Power(2 * n), (2 * n).Factorial(), precision + 1);

                if (r.GetPrecision(0) > precision)
                    break;
                sum = sum + r;
            }
            Remove(sum, precision);
            return sum;
        }

        /// <summary>移除精度后多余的数字</summary>
        private static void Remove(BigNumber sum, int precision) {
            if (precision < sum.DecimalPart.Count)
                sum.DecimalPart.RemoveRange(precision, sum.DecimalPart.Count - precision);
        }
        
        /// <summary>e次幂</summary>
        public static BigNumber Exp(BigNumber value, int precision) {
            BigNumber sum = new BigNumber("0");

            for (BigNumber n = new BigNumber("0"); ; n++) {
                BigNumber r = BigNumber.Division(value.Power(n), n.Factorial(), precision + 1);

                if (r.GetPrecision(0) > precision)
                    break;
                sum = sum + r;
            }
            Remove(sum, precision);
            return sum;
        }

    } // end class
}
