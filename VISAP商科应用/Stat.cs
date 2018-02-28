using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Numerics;
namespace VISAP商科应用
{
    public class Stat
    {
        //下面是分位数计算
        //分位数计算统一用double
        public static double BetaCDF(double x, double a, double b)
        {
            //Beta的累积密度函数，a，b为自由度
            //x在0～1之间
            int m, n;
            double I = 0, U = 0;
            double ta = 0, tb = 0;
            m = (int)(2 * a);
            n = (int)(2 * b);
            //下面分四种情况
            if (m % 2 == 1 && n % 2 == 1)
            {
                ta = 0.5;
                tb = 0.5;
                U = Math.Sqrt(x * (1.0 - x)) / Math.PI;
                I = 1.0 - 2.0 / Math.PI * Math.Atan(Math.Sqrt((1.0 - x) / x));
            }
            else if (m % 2 == 1 && n % 2 == 0)
            {
                ta = 0.5;
                tb = 0.1;
                U = 0.5 * Math.Sqrt(x) * (1.0 - x);
                I = Math.Sqrt(x);
            }
            else if (m % 2 == 0 && n % 2 == 1)
            {
                ta = 1;
                tb = 0.5;
                U = 0.5 * x * Math.Sqrt(1.0 - x);
                I = 1.0 - Math.Sqrt(1.0 - x);
            }
            else if (m % 2 == 0 && n % 2 == 0)
            {
                ta = 1;
                tb = 1;
                U = x * (1.0 - x);
                I = x;
            }
            while (ta < a)
            {
                I = I - U / ta;
                U = (ta + tb) / ta * x * U;
                ta++;
            }
            while (tb < b)
            {
                I = I + U / tb;
                U = (ta + tb) / tb * (1.0 - x) * U;
                tb++;
            }
            return I;
        }
        
        public static double TDIST(double x, int v,double Tail)
        {
            //计算t分布的累积密度函数
            //v为自由度
            //Tail为单/双尾
            //1为单尾，2为双尾
            double t, prob;
            t = v / (v + x * x);
            if (x > 0)
            {
                prob = 1 - 0.5 * BetaCDF(t, v / 2.0, 0.5);
            }
            else
            {
                prob = 0.5 * BetaCDF(t, v / 2.0, 0.5);
            }
            //对结果进行调整
            return (1-prob)*Tail ;
        }
        public static double FDIST(double x, int m, int n)
        {
            //计算F分布的累积密度函数
            //m，n为两个自由度
            double y, prob;
            if (x <= 0)
            {
                return 0;
            }
            y = m * x / (n + m * x);
            prob = BetaCDF(y, m / 2.0, n / 2.0);
            return 1 - prob;
        }
        public static double BinomialCDF(double x, double p, int n)
        {
            //二项分布的累积密度函数
            //事件发生的概率为p
            double prob = 0.0;
            if (x < 0)
            {
                prob = 0.0;
                return prob;
            }
            else if (x >= n)
            {
                prob = 1.0;
                return prob;
            }
            else
            {
                prob = BetaCDF(1.0 - p, n - (int)x, (int)x + 1);
                return prob;
            }

        }
       
        public static double BetaUa(double af, double a, double b)
        {
            //Beta函数的分位数
            //af为概率
            //a，b为自由度
            //返回分位数
            int MaxTime = 500;
            int times = 0;
            double x1, x2, xn = 0.0;
            double f1, f2, fn, ua;
            double eps = 1.0e-10;
            x1 = 0.0;
            x2 = 1.0;
            f1 = BetaCDF(x1, a, b) - (1.0 - af);
            f2 = BetaCDF(x2, a, b) - (1.0 - af);
            while (Math.Abs((x2 - x1) / 2.0) > eps)
            {
                xn = (x1 + x2) / 2.0;
                fn = BetaCDF(xn, a, b) - (1.0 - af);
                if (f1 * fn < 0)
                {
                    x2 = xn;
                }
                else if (fn * f2 < 0)
                {
                    x1 = xn;
                }
                f1 = BetaCDF(x1, a, b) - (1.0 - af);
                f2 = BetaCDF(x2, a, b) - (1.0 - af);
                times++;
                if (times > MaxTime)
                {
                    break;
                }
            }
            ua = xn;
            return ua;
        }
       
        public static double TINV(double af, int v)
        {
            //T分布的分位数
            //af为概率
            double ua = 0.0, tbp, bf;
            bf = 1 - af;
            if (af <= 0.5)
            {
                tbp = BetaUa(1 - 2 * af, v / 2.0, 0.5);
                ua = Math.Sqrt(v / tbp - v);
            }
            else if (af > 0.5)
            {
                tbp = BetaUa(1 - 2 * (1.0 - af), v / 2.0, 0.5);
                ua = -Math.Sqrt(v / tbp - v);
            }
            return ua;
        }
        
        public static double FINV(double af, int m, int n)
        {
            //F分布的分位数
            //上侧概率分位数
            double ua, tbp, bf;
            bf = 1 - af;
            tbp = BetaUa(af, m / 2.0, n / 2.0);
            ua = n * tbp / (m * (1.0 - tbp));
            return ua;
        }
        
        public static double chi2(double x, int Freedom)
        {
            //计算卡方分布累积密度函数
            int k, n;
            double f, h, prob;
            k = Freedom % 2;
            if (k == 1)
            {
                f = Math.Exp(-x / 2.0) / Math.Sqrt(2 * Math.PI * x);
                h = 2.0 * GaossFx1(Math.Sqrt(x)) - 1.0;
                n = 1;
                while (n < Freedom)
                {
                    n = n + 2;
                    f = x / (n - 2.0) * f;
                    h = h - 2.0 * f;
                }
            }
            else
            {
                f = Math.Exp(-x / 2.0) / 2.0;
                h = 1.0 - Math.Exp(-x / 2.0);
                n = 2;
                while (n < Freedom)
                {
                    n = n + 2;
                    f = x / (n - 2.0) * f;
                    h = h - 2.0 * f;
                }
            }
            prob = h;
            return prob;
        }
        
        private static double chi21(double x, int Freedom)
        {
            //这个函数一般无需调用
            int k, n;
            double f, h, prob;
            k = Freedom % 2;
            if (k == 1)
            {
                f = Math.Exp(-x / 2.0) / Math.Sqrt(2 * Math.PI * x);
                h = 2.0 * GaossFx1(Math.Sqrt(x)) - 1.0;
                n = 1;
                while (n < Freedom)
                {
                    n = n + 2;
                    f = x / (n - 2.0) * f;
                    h = h - 2.0 * f;
                }
            }
            else
            {
                f = Math.Exp(-x / 2.0) / 2.0;
                h = 1.0 - Math.Exp(-x / 2.0);
                n = 2;
                while (n < Freedom)
                {
                    n = n + 2;
                    f = x / (n - 2.0) * f;
                    h = h - 2.0 * f;
                }
            }
            prob = h;
            return prob;
        }
        
        public static double PossionCDF(double x, double p)
        {
            //Possion分布的累积密度函数
            double prob = 0.0;
            prob = 1.0 - chi21(2 * p, 2 * ((int)x) + 1);
            return prob;
        }
        
        public static double chi2Ua(double af, int Freedom)
        {
            //卡方分布的上侧分位数的计算  
            //int times;
            //int MaxTime = 500;
            double eps = 1.0e-10;
            double ua, x0, xn, bf;
            bf = 1 - af;
            x0 = chi2Ua0(af, Freedom);
            if (Freedom == 1 || Freedom == 2)
            {
                ua = x0;
            }
            else
            {
                //times = 1;
                int Try = 1;
                //在这里我用了一个不是办法的办法，就是尝试着找到最合适的初值。

                xn = x0 - (chi21(x0, Freedom) - 1 + af) / chi2Px(x0, Freedom);
                while (Math.Abs(xn - x0) > eps)
                {
                    x0 = xn;
                    if (chi2Px(x0, Freedom) > 0.00000001)
                    {
                        //确保初值合适
                        xn = x0 - (chi21(x0, Freedom) - 1 + af) / chi2Px(x0, Freedom);
                    }
                    else
                    {
                        //如果初值不合适，造成剧烈波动，则尝试其他的初值
                        xn = Try;
                        Try++;
                    }
                    //times++;
                    //if (times > MaxTime) break;
                }
                ua = xn;
            }
            return ua;
        }
        
        private static double chi2Ua0(double af, int Freedom)
        {
            //这个函数一般无需调用
            double ua, p, temp;
            if (Freedom == 1)
            {
                p = 1.0 - (1.0 - af + 1.0) / 2.0;
                temp = NORMSINV(p);
                ua = temp * temp;
            }
            else if (Freedom == 2)
            {
                ua = -2.0 * Math.Log(af);
            }
            else
            {
                temp = 1.0 - 2.0 / (9.0 * Freedom) + Math.Sqrt(2.0 / (9.0 * Freedom)) * NORMSINV(af);
                ua = Freedom * (temp * temp * temp);
            }
            return ua;
        }
       
        public static double chi2Px(double x, int Freedom)
        {
            //卡方分布的密度函数  
            double p, g;
            if (x <= 0) return 0.0;
            g = Gama(Freedom);
            p = 1.0 / Math.Pow(2.0, Freedom / 2.0) / g * Math.Exp(-x / 2.0) * Math.Pow(x, Freedom / 2.0 - 1.0);
            return p;
        }
        public static double Gama(int n)//伽马分布函数Gama(n/2)  
        {
            double g;
            int i, k;
            k = n / 2; if (n % 2 == 1)
            {
                g = Math.Sqrt(Math.PI) * 0.5;
                for (i = 1; i < k; i++)
                    g *= (i + 0.5);
            }
            else
            {
                g = 1.0;
                for (i = 1; i < k; i++)
                    g *= i;
            }
            return g;
        }
        
        private  static double GaossFx1(double x)
        {
            //高斯函数
            //一般无需调用
            double prob = 0, t, temp;
            int i, n, symbol;
            temp = x;
            if (x < 0)
                x = -x;
            n = 28;
            if (x >= 0 && x <= 3.0)
            {
                t = 0.0;
                for (i = n; i >= 1; i--)
                {
                    if (i % 2 == 1) symbol = -1;
                    else symbol = 1;
                    t = symbol * i * x * x / (2.0 * i + 1.0 + t);
                }
                prob = 0.5 + GaossPx(x) * x / (1.0 + t);
            }
            else if (x > 3.0)
            {
                t = 0.0;
                for (i = n; i >= 1; i--)
                    t = 1.0 * i / (x + t);
                prob = 1 - GaossPx(x) / (x + t);
            }
            x = temp;
            if (x < 0)
                prob = 1.0 - prob; return prob;
        }
        public static double NORMDIST(double x)//正态分布的分布函数的计算  
        {
            double prob = 0, t, temp;
            int i, n, symbol;
            temp = x;
            if (x < 0)
                x = -x;
            n = 28;//连分式展开的阶数  
            if (x >= 0 && x <= 3.0)//连分式展开方法  
            {
                t = 0.0;
                for (i = n; i >= 1; i--)
                {
                    if (i % 2 == 1) symbol = -1;
                    else symbol = 1;
                    t = symbol * i * x * x / (2.0 * i + 1.0 + t);
                }
                prob = 0.5 + GaossPx(x) * x / (1.0 + t);
            }
            else if (x > 3.0)
            {
                t = 0.0;
                for (i = n; i >= 1; i--)
                    t = 1.0 * i / (x + t);
                prob = 1 - GaossPx(x) / (x + t);
            }
            x = temp;
            if (x < 0)
                prob = 1.0 - prob;
            return prob;
        }
        private static double GaossPx(double x)//正态分布的密度函数  
        {
            //用于计算密度函数
            double f;
            f = 1.0 / Math.Sqrt(2.0 * Math.PI) * Math.Exp(-x * x / 2.0);
            return f;
        }
        //计算正态分布的分位数
        public static double NORMSINV(double alpha)
        {
            if (0.5 < alpha && alpha < 1)
            {
                alpha = 1 - alpha;
            }
            double[] b = new double[11];
            b[0] = 0.1570796288 * 10;
            b[1] = 0.3706987906 * 0.1;
            b[2] = -0.8364353589 * 0.001;
            b[3] = -0.2250947176 * 0.001;
            b[4] = 0.6841218299 * 0.00001;
            b[5] = 0.5824238515 * 0.00001;
            b[6] = -0.1045274970 * 0.00001;
            b[7] = 0.8360937017 * 0.0000001;
            b[8] = -0.3231081277 * 0.00000001;
            b[9] = 0.3657763036 * 0.0000000001;
            b[10] = 0.6657763036 * 0.000000000001;
            double sum = 0;
            double y = -Math.Log(4 * alpha * (1 - alpha));
            for (int i = 0; i < 11; i++)
            {
                sum += b[i] * Math.Pow(y, i);
            }
            return Math.Pow(sum * y, 0.5);
        }
        public static string CI (string VarName,string [] Numbers, string Tail, string Statistics,double  Significance, string proportion_condition,double proportion_compare_value){
            //Confidence Interval 置信区间
            //Tail为单双尾,Tail = "单尾"，Tail = "双尾"
            //Statistics为统计量  "均值" "比例"
            int count = 0;
            //count用于统计样本个数
            StringBuilder result = new StringBuilder();
            //result记录反馈结果
            BigDecimal Sd = 0;
            //Sd为标准差
            double Temp = 0;
            //Temp用于记录临时数据
            BigDecimal BigTemp = 0;
            //BigTemp用于记录BigDecimal类型的临时数据
            if (Tail == "双尾"){
                Significance =1 - (1 - Significance) /2;
                // 1 - (1 - 0.95)/2
            }
            if (Statistics == "均值" || Statistics == "方差")
            {
                BigDecimal Mean = 0;
                BigDecimal Sum = 0;
                BigDecimal Sum2 = 0;
                foreach (string Num in Numbers)
                {
                    if (double.TryParse(Num,out Temp)){
                        Sum += Temp;
                        Sum2 += (BigDecimal)Temp * (BigDecimal)Temp;
                        count++;
                    }
                }
                if (count <= 1)
                {
                    return "样本数量过少，无法进行参数估计";
                }
                else
                {
                    Mean = Sum / count;
                    BigDecimal Variance = (Sum2 / count - Mean * Mean) * count / (count - 1);
                    Sd = MathV.Sqrt(Variance.ToString()).ToString();
                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(VarName), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(count.ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Mean.ToString()), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Sd.ToString()), ' ', 12));
                    result.Append("\t");
                    if (Statistics == "均值")
                    {
                        if (count >= 30)
                        {
                            //大样本
                            BigTemp = NORMSINV(Significance) * Sd / MathV.Sqrt(count).ToString();
                        }
                        else
                        {
                            //小样本
                            BigTemp = TINV(1 - Significance, (count - 1)) * Sd / MathV.Sqrt(count).ToString();
                        }
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean - BigTemp).ToString()), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean + BigTemp).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    else
                    {
                        //Statistics == "方差"
                        BigTemp = (count - 1) * Variance;
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp/Stat.chi2Ua(1-Significance,count -1)).ToString()), ' ', 12));
                        result.Append("\t");
                        //MessageBox.Show(Significance.ToString());
                        //MessageBox.Show(Stat.chi2Ua(Significance, count - 1).ToString());
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / Stat.chi2Ua(Significance, count - 1)).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    return result.ToString();
                }
            }
            else if (Statistics == "比例")
            {
                int OneCounts = 0;
                int ZeroCounts = 0;
                foreach (string Num in Numbers)
                {
                    if (Num != "")
                    {
                        if (proportion_condition == "=")
                        {
                            if (Convert.ToDouble(Num.Trim()) == proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == ">=")
                        {
                            if (Convert.ToDouble(Num.Trim()) >= proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == ">")
                        {
                            if (Convert.ToDouble(Num.Trim()) > proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == "<=")
                        {
                            if (Convert.ToDouble(Num.Trim()) <= proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == "<")
                        {
                            if (Convert.ToDouble(Num.Trim()) < proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                    }
                   /* if (Num.Trim() == "1"){
                        OneCounts++;
                    }
                    else if (Num.Trim() == "0"){
                        ZeroCounts++;
                    }*/
                }
                if (ZeroCounts+OneCounts  == 0)
                {
                    return "样本不存在，无法进行参数估计\r\n";
                }
                else
                {
                    if (ZeroCounts + OneCounts < 30)
                    {
                        result.Append("样本数量较少，进行比例的参数估计可能会不稳定\r\n");
                    }
                    BigDecimal Proportion = (BigDecimal)OneCounts / ((BigDecimal)ZeroCounts + (BigDecimal)OneCounts);
                    count = ZeroCounts + OneCounts;
                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(VarName), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX((ZeroCounts + OneCounts).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Proportion.ToString()), ' ', 12));
                    result.Append("\t");
                    BigTemp = Proportion * (1 - Proportion);
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(((BigDecimal)MathV.Sqrt(BigTemp.ToString()).ToString() / (BigDecimal)MathV.Sqrt(count).ToString()).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    BigTemp = NORMSINV(Significance) * ((BigDecimal)MathV.Sqrt(BigTemp.ToString()).ToString() / (BigDecimal)MathV.Sqrt(count).ToString());
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion - BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion + BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\r\n");
                    return result.ToString();
                }
            }
            else
            {
                return "未知统计量\r\n";
            }
        }
        public static string CI2(string VarName1, string VarName2, string[] Numbers1, string[] Numbers2, string Tail, string Statistics, double Significance, string proportion_condition, double proportion_compare_value)
        {
            //Confidence Interval 置信区间
            //Tail为单双尾,Tail = "单尾"，Tail = "双尾"
            //Statistics为统计量  "均值" "比例"
            int count1 = 0;
            int count2 = 0;
            //count用于统计样本个数
            StringBuilder result = new StringBuilder();
            //result记录反馈结果
            BigDecimal Sd1 = 0;
            BigDecimal Sd2 = 0;
            //Sd为标准差
            double Temp = 0;
            //Temp用于记录临时数据
            BigDecimal BigTemp = 0;
            //BigTemp用于记录BigDecimal类型的临时数据
            if (Tail == "双尾")
            {
                Significance = 1 - (1 - Significance) / 2;
                // 1 - (1 - 0.95)/2
            }
            if (Statistics == "均值差" || Statistics == "方差比")
            {
                BigDecimal Mean1 = 0;
                BigDecimal Mean2 = 0;
                BigDecimal Sum_1 = 0;
                BigDecimal Sum_2 = 0;
                BigDecimal Sum2_1 = 0;
                BigDecimal Sum2_2 = 0;
                foreach (string Num in Numbers1)
                {
                    if (double.TryParse(Num, out Temp))
                    {
                        Sum_1 += Temp;
                        Sum2_1 += (BigDecimal)Temp * (BigDecimal)Temp;
                        count1 ++;
                    }
                }
                foreach (string Num in Numbers2)
                {
                    if (double.TryParse(Num, out Temp))
                    {
                        Sum_2 += Temp;
                        Sum2_2 += (BigDecimal)Temp * (BigDecimal)Temp;
                        count2++;
                    }
                }
                if (count1 <= 1 || count2 <= 1)
                {
                    return "样本数量过少，无法进行参数估计";
                }
                else
                {
                    Mean1 = Sum_1 / count1;
                    Mean2 = Sum_2 / count2;
                    BigDecimal Variance1 = (Sum2_1 / count1 - Mean1 * Mean1) * count1 / (count1 - 1);
                    BigDecimal Variance2 = (Sum2_2 / count2 - Mean2 * Mean2) * count2 / (count2 - 1);
                    Sd1 = MathV.Sqrt(Variance1.ToString()).ToString();
                    Sd2 = MathV.Sqrt(Variance2.ToString()).ToString();
                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(VarName1), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(count1.ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Mean1.ToString()), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Sd1.ToString()), ' ', 12));
                    result.Append("\t");
                    if (Statistics == "均值差")
                    {
                        if (count1 >= 30)
                        {
                            //大样本
                            BigTemp = NORMSINV(Significance) * Sd1 / MathV.Sqrt(count1).ToString();
                        }
                        else
                        {
                            //小样本
                            BigTemp = TINV(1 - Significance, (count1 - 1)) * Sd1 / MathV.Sqrt(count1).ToString();
                        }
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean1 - BigTemp).ToString()), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean1 + BigTemp).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    else
                    {
                        //Statistics == "方差"
                        BigTemp = (count1 - 1) * Variance1;
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / Stat.chi2Ua(1 - Significance, count1 - 1)).ToString()), ' ', 12));
                        result.Append("\t");
                        //MessageBox.Show(Significance.ToString());
                        //MessageBox.Show(Stat.chi2Ua(Significance, count1 - 1).ToString());
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / Stat.chi2Ua(Significance, count1 - 1)).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(VarName2), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(count2.ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Mean2.ToString()), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Sd2.ToString()), ' ', 12));
                    result.Append("\t");
                    if (Statistics == "均值差")
                    {
                        if (count2 >= 30)
                        {
                            //大样本
                            BigTemp = NORMSINV(Significance) * Sd2 / MathV.Sqrt(count2).ToString();
                        }
                        else
                        {
                            //小样本
                            BigTemp = TINV(1 - Significance, (count2 - 1)) * Sd2 / MathV.Sqrt(count2).ToString();
                        }
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean2 - BigTemp).ToString()), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean2 + BigTemp).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    else
                    {
                        //Statistics == "方差"
                        BigTemp = (count2 - 1) * Variance2;
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / Stat.chi2Ua(1 - Significance, count2 - 1)).ToString()), ' ', 12));
                        result.Append("\t");
                        //MessageBox.Show(Significance.ToString());
                        //MessageBox.Show(Stat.chi2Ua(Significance, count2 - 1).ToString());
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / Stat.chi2Ua(Significance, count2 - 1)).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    if (Statistics == "均值差")
                    {
                        result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("均值差"), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean1 - Mean2).ToString()), ' ', 12));
                        result.Append("\t");

                        if (count1 >= 30 && count2 >= 30)
                        {
                            //大样本
                            //MessageBox.Show(MathV.Sqrt((((count1 - 1) * Variance1 + (count2 - 1) * Variance2) / ((count1 - 1) + (count2 - 1))).ToString()).ToString());
                            //MessageBox.Show(MathV.Sqrt(1 / count1 + 1 / count2).ToString().ToString());
                            //MessageBox.Show((1 / Convert.ToDouble(count1) + 1 / Convert.ToDouble(count1)).ToString());

                            BigTemp = (NORMSINV(Significance) *MathV.Sqrt((((count1 - 1) * Variance1 + (count2 - 1) * Variance2) / ((count1 - 1) + (count2 - 1))).ToString()) * MathV.Sqrt((1 / Convert.ToDouble(count1) + 1 / Convert.ToDouble(count2)).ToString())).ToString();
                            result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / NORMSINV(Significance)).ToString()), ' ', 12));
                            result.Append("\t");
                        }
                        else
                        {
                            //小样本
                            BigTemp = (TINV(1 - Significance, (count1 + count2 - 1)) * MathV.Sqrt((((count1 - 1) * Variance1 + (count2 - 1) * Variance2) / ((count1 - 1) + (count2 - 1))).ToString()) * MathV.Sqrt((1 / Convert.ToDouble(count1) + 1 / Convert.ToDouble(count2)).ToString())).ToString();
                            result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((BigTemp / TINV(1 - Significance, (count1 + count2 - 1))).ToString()), ' ', 12));
                            result.Append("\t");
                        }
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean1 - Mean2 - BigTemp).ToString()), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Mean1 - Mean2 + BigTemp).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                    else
                    {
                        result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("方差比"), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Sd1 / Sd2).ToString()), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        result.Append("\t");
                        BigTemp = Variance1 / Variance2;
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Stat.FINV(Significance, count1 - 1 ,count2 - 1)).ToString()), ' ', 12));
                        result.Append("\t");
                        result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Stat.FINV(1 - Significance, count1 - 1, count2 - 1)).ToString()), ' ', 12));
                        result.Append("\r\n");
                    }
                }
            }
            else
            {
                int OneCounts1 = 0;
                int ZeroCounts1 = 0;
                int OneCounts2 = 0;
                int ZeroCounts2 = 0;
                foreach (string Num in Numbers1)
                {
                    if (Num != "")
                    {
                        if (proportion_condition == "=")
                        {
                            if (Convert.ToDouble(Num.Trim()) == proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == ">=")
                        {
                            if (Convert.ToDouble(Num.Trim()) >= proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == ">")
                        {
                            if (Convert.ToDouble(Num.Trim()) > proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == "<=")
                        {
                            if (Convert.ToDouble(Num.Trim()) <= proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == "<")
                        {
                            if (Convert.ToDouble(Num.Trim()) < proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                    }
                }
                foreach (string Num in Numbers2)
                {
                    if (Num != "")
                    {
                        if (proportion_condition == "=")
                        {
                            if (Convert.ToDouble(Num.Trim()) == proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == ">=")
                        {
                            if (Convert.ToDouble(Num.Trim()) >= proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == ">")
                        {
                            if (Convert.ToDouble(Num.Trim()) > proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == "<=")
                        {
                            if (Convert.ToDouble(Num.Trim()) <= proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == "<")
                        {
                            if (Convert.ToDouble(Num.Trim()) < proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                    }
                }
                if (OneCounts1 + ZeroCounts1 == 0 && OneCounts2 + ZeroCounts2== 0)
                {
                    return "样本不存在，无法进行参数估计\r\n";
                }
                else
                {
                    if (ZeroCounts1 + OneCounts1 < 30 || ZeroCounts1 + OneCounts1 < 30)
                    {
                        result.Append("样本数量较少，进行比例的参数估计可能会不稳定\r\n");
                    }
                    BigDecimal Proportion1 = (BigDecimal)OneCounts1 / ((BigDecimal)ZeroCounts1 + (BigDecimal)OneCounts1);
                    count1 = ZeroCounts1 + OneCounts1;
                    BigDecimal Proportion2 = (BigDecimal)OneCounts2 / ((BigDecimal)ZeroCounts2 + (BigDecimal)OneCounts2);
                    count2 = ZeroCounts2 + OneCounts2;

                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(VarName1), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX((ZeroCounts1 + OneCounts1).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Proportion1.ToString()), ' ', 12));
                    result.Append("\t");
                    BigTemp = Proportion1 * (1 - Proportion1);
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(((BigDecimal)MathV.Sqrt(BigTemp.ToString()).ToString() / (BigDecimal)MathV.Sqrt(count1).ToString()).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    BigTemp = NORMSINV(Significance) * ((BigDecimal)MathV.Sqrt(BigTemp.ToString()).ToString() / (BigDecimal)MathV.Sqrt(count1).ToString());
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion1 - BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion1 + BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\r\n");

                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(VarName2), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX((ZeroCounts2 + OneCounts2).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Proportion2.ToString()), ' ', 12));
                    result.Append("\t");
                    BigTemp = Proportion1 * (1 - Proportion2);
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(((BigDecimal)MathV.Sqrt(BigTemp.ToString()).ToString() / (BigDecimal)MathV.Sqrt(count2).ToString()).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    BigTemp = NORMSINV(Significance) * ((BigDecimal)MathV.Sqrt(BigTemp.ToString()).ToString() / (BigDecimal)MathV.Sqrt(count2).ToString());
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion2 - BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion2 + BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\r\n");

                    result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("比例差"), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion1 - Proportion2).ToString()), ' ', 12));
                    result.Append("\t");
                    BigTemp = Proportion1 * (1 - Proportion1) / count1 +  Proportion2 * (1 - Proportion2) / count2;
                    BigTemp = MathV.Sqrt(BigTemp.ToString()).ToString();
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp.ToString()),' ', 12));
                    result.Append("\t");
                    BigTemp = BigTemp * NORMSINV(Significance);
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion1 - Proportion2 - BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\t");
                    result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion1 - Proportion2 + BigTemp).ToString()).ToString(), ' ', 12));
                    result.Append("\r\n");
                }

            }
            return result.ToString();
        }
        private const string Header = "      变量名\t      样本数\t        均值\t      标准差\t    置信下限\t    置信上限\r\n";
        private const string Header_Prop = "      变量名\t      样本数\t        比例\t      标准差\t    置信下限\t    置信上限\r\n";
        public static void LoopCI(DataGridView dataGridView1, RichTextBox richTextBox1, string Cols, string Tail, string Statistics, double Significance, string proportion_condition, double proportion_compare_value)
        {
            //这个函数的目的是循环对所要求的变量进行参数估计
            char[] separator = { ',' };
            string[] AllCols = Cols.Split(separator);
            string result = "";
            richTextBox1.AppendText("参数估计: ");
            richTextBox1.AppendText(Statistics);
            richTextBox1.AppendText("\r\n");
            richTextBox1.AppendText("置信度: ");
            richTextBox1.AppendText(Significance.ToString());
            richTextBox1.AppendText("\t");
            richTextBox1.AppendText(Tail);
            richTextBox1.AppendText("\r\n");
            if (Statistics == "比例")
            {
                richTextBox1.AppendText(Header_Prop);
            }
            else
            {
                richTextBox1.AppendText(Header);
            }
            int ColNum = 0;
            foreach (string EachCol in AllCols)
            {
                if (Int32.TryParse(EachCol,out ColNum))
                {
                    string[] Numbers = Tabulation.ReadVector(MainForm.MainDT, ColNum - 1).ToArray();
                    result = CI(dataGridView1.Columns[ColNum - 1].Name, Numbers, Tail, Statistics, Significance,proportion_condition,proportion_compare_value);
                    richTextBox1.AppendText(result);
                }
            }
        }

        public static void LoopCI2(DataGridView dataGridView1, RichTextBox richTextBox1, string Cols, string Tail, string Statistics, double Significance, string proportion_condition, double proportion_compare_value)
        {
            char[] separator = { ',' };
            string[] AllCols = Cols.Split(separator);
            string result = "";
            richTextBox1.AppendText("双样本参数估计: ");
            richTextBox1.AppendText(Statistics);
            richTextBox1.AppendText("\r\n");
            richTextBox1.AppendText("置信度: ");
            richTextBox1.AppendText(Significance.ToString());
            richTextBox1.AppendText("\t");
            richTextBox1.AppendText(Tail);
            richTextBox1.AppendText("\r\n");
            if (Statistics == "比例")
            {
                richTextBox1.AppendText(Header_Prop);
            }
            else
            {
                richTextBox1.AppendText(Header);
            }
            int ColNum1 = 0;
            int ColNum2 = 0;
            if (Int32.TryParse(AllCols[0], out ColNum1))
            {
                 
                  string[] Numbers1 = Tabulation.ReadVector(MainForm.MainDT, ColNum1 - 1).ToArray();
                 if (Int32.TryParse(AllCols[1], out ColNum2))
                 {
                  string[] Numbers2 = Tabulation.ReadVector(MainForm.MainDT, ColNum2 - 1).ToArray();
                  result = CI2(dataGridView1.Columns[ColNum1 - 1].Name, dataGridView1.Columns[ColNum2 - 1].Name, Numbers1, Numbers2, Tail, Statistics, Significance, proportion_condition, proportion_compare_value);
                  richTextBox1.AppendText(result);
                 }
            }

        }

        public static string QuickSummary(DataTable MainDT,int ColNum)
        {
            string ColName = MainDT.Columns[ColNum].ColumnName;
            List <string> Numbers = Tabulation.ReadVector(MainDT, ColNum);
            StringBuilder Result = new StringBuilder();
                BigDecimal sum = 0;
                BigDecimal mean = 0;
                BigDecimal Variance = 0;
                int  count = 0;
                BigDecimal max = 0;
                BigDecimal min = 0;
                BigDecimal sum2 = 0;
                Double TempNum = 0;
                //sum2用于计算数字的平方，方便计算方差
                foreach (string Num in Numbers)
                {
                    if (Double.TryParse(Num, out TempNum))
                    {
                        sum+= TempNum;
                        sum2 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                        count++;
                        if (count == 1)
                        {
                            max = TempNum;
                            min = TempNum;
                        }
                        else{
                            if (max < TempNum)
                            {
                                max = TempNum;
                            }
                            if (min > TempNum)
                            {
                                min = TempNum;
                            }
                        }
                    }
                }
                if (count == 0)
                {
                    //如果没有获取任何数字
                    return "";
                }
                else if (count == 1)
                {
                    //如果只有一个数字，可以计算均值，但是不可以计算标准差
                    mean = sum / count;
                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("NA", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(min.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append( StrManipulation.PadLeftX(MathV.NumberPolish(max.ToString()), ' ', 12));
                    Result.Append("\r\n");
                    //Temp += Result;
                    return Result.ToString();
                }
                else
                {
                    //开始计算均值和方差
                    //方差要乘以调整系数
                    mean = sum / count;
                    Variance = (sum2 / count - mean * mean) * count / (count - 1);
                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance.ToString()).ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(min.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append( StrManipulation.PadLeftX(MathV.NumberPolish(max.ToString()), ' ', 12));
                    Result.Append("\r\n");
                    return Result.ToString();
                }
            }
        private const string HTHeader_Ztest = "      变量名\t      样本数\t        均值\t      标准差\t         z值\t     z临界值\t         p值\r\n";
        private const string HTHeader_Ttest = "      变量名\t      样本数\t        均值\t      标准差\t         t值\t     t临界值\t         p值\r\n";
        private const string HTHeader_Proptest = "      变量名\t      样本数\t        比例\t       z值\t     z临界值\t         p值\r\n";
        private const string HTHeader_XSquaretest_single = "      变量名\t       样本数\t      均值\t      标准差\t    XSquare值\t          接受域\t        p值\r\n";
        private const string HTHeader_Ftest = "      变量名\t       样本数\t      均值\t      标准差\t         F值\t       接受域\t         p值\r\n";
        public static string HypothesisTesting(DataTable MainDT, string ColName,
            string Statistics, string Operation,string Tail,double Significance,double NullHypothesis, string proportion_condition, double proportion_compare_value)
        {
            //假设检验
            //Statistics为统计量，Operation为运算(>,<,=)
            //Tail为单尾双尾，这里内容为双侧、左单侧、右单侧
            //Significance为显著性水平
            int ColNum = Tabulation.FindCol(MainDT,ColName);
            string[] Numbers = Tabulation.ReadVector(MainDT, ColNum).ToArray();
            StringBuilder Result = new StringBuilder();
            Result.Append("假设检验: ");
            Result.Append(Statistics);
            Result.Append("\r\n");
            Result.Append("显著性水平: ");
            Result.Append(Significance.ToString());
            Result.Append("\t");
            Result.Append(Tail);
            Result.Append("\r\n原假设: ");
            Result.Append(Statistics);
            Result.Append(" ");
            Result.Append(Operation);
            Result.Append(" ");
            Result.Append(NullHypothesis.ToString());
            Result.Append("\r\n备择假设: ");
            Result.Append(Statistics);
            Result.Append(" ");
            if (Operation == "=")
            {
                Result.Append("<>");
            }
            else if (Operation == "<=")
            {
                Result.Append(">");
            }
            else
            {
                Result.Append("<");
            }
            Result.Append(" ");
            Result.Append(NullHypothesis.ToString());
            Result.Append("\r\n");
           
            BigDecimal sum = 0;
            BigDecimal mean = 0;
            BigDecimal Variance = 0;
            BigDecimal Sd = 0;
            //Sd为标准差
            int count = 0;
            BigDecimal sum2 = 0;
            //sum2用于计算数字的平方，方便计算方差
            Double TempNum = 0;
            BigDecimal BigTemp = 0;
            //BigTemp用于记录BigDecimal类型的临时数据
            double Threshold = 0;
            //Threshold为临界值
            double PValue = 0;
            if (Statistics == "均值")
            {
            //Pvalue不用多解释了吧～
            foreach (string Num in Numbers)
            {
                if (Double.TryParse(Num, out TempNum))
                {
                    sum += TempNum;
                    sum2 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                    count++;
                }
            }
            //遍历了该列所有数字
                if(count >= 30){
                    Result.Append(HTHeader_Ztest);
                }
                else
                {
                    Result.Append(HTHeader_Ttest);
                }
                if (count <= 1)
                {
                    return "样本数量过少，无法进行假设检验！\r\n";
                }
                else
                {
                    //开始计算均值和方差
                    //方差要乘以调整系数
                    mean = sum / count;
                    Variance = (sum2 / count - mean * mean) * count / (count - 1);

                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance.ToString()).ToString()), ' ', 12));
                    Result.Append("\t");
                    if (count >= 30)
                    {
                        //大样本
                        //z检验
                        Sd = MathV.Sqrt(Variance.ToString()).ToString();
                        BigTemp = (mean - NullHypothesis) / (Sd / Math.Sqrt(count));
                        //BigTemp此时的值为z检验统计量
                        //样本数count无需大数开方，用普通方法开方即可
                        if (Tail == "双侧")
                        {
                            Threshold = NORMSINV(1 - Significance / 2);
                            PValue = 2 * (1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString()))));
                        }
                        else if (Tail == "左单侧")
                        {
                            Threshold = NORMSINV(Significance);
                            PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString())));
                        }
                        else if (Tail == "右单侧")
                        {
                            Threshold = NORMSINV(1 - Significance);
                            PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString())));
                        }
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                        Result.Append("\r\n");
                        if (PValue < Significance)
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上拒绝原假设");
                        }
                        else
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上不拒绝原假设");
                        }
                    }
                    else
                    {
                        //小样本
                        //t检验
                        Sd = MathV.Sqrt(Variance.ToString()).ToString();
                        BigTemp = (mean - NullHypothesis) / (Sd / Math.Sqrt(count));
                        //BigTemp此时的值为z检验统计量
                        //样本数count无需大数开方，用普通方法开方即可
                        if (Tail == "双侧")
                        {
                            Threshold = TINV(Significance / 2/2, count - 1);
                            //每个放进TINV的值都要除以2，这个bug之后会进行修复
                            PValue = TDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString())/2), count - 1, 2);
                        }
                        else if (Tail == "左单侧")
                        {
                            Threshold = TINV(Significance/2, count - 1);
                            PValue = TDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString()) / 2), count - 1, 1);
                        }
                        else if (Tail == "右单侧")
                        {
                            Threshold = TINV(Significance/2, count - 1);
                            PValue = TDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString()) / 2), count - 1, 1);
                        }
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                        Result.Append("\r\n");
                        if (PValue < Significance)
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上拒绝原假设");
                        }
                        else
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上不拒绝原假设");
                        }
                    }
                    Result.Append("\r\n");
                    Result.Append("\r\n");
                    return Result.ToString();
                }
            }
            else if (Statistics == "比率")
            {
                int OneCounts = 0;
                int ZeroCounts = 0;
                foreach (string Num in Numbers)
                {
                    if (Num != "")
                    {
                        if (proportion_condition == "=")
                        {
                            if (Convert.ToDouble(Num.Trim()) == proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == ">=")
                        {
                            if (Convert.ToDouble(Num.Trim()) >= proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == ">")
                        {
                            if (Convert.ToDouble(Num.Trim()) > proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == "<=")
                        {
                            if (Convert.ToDouble(Num.Trim()) <= proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                        if (proportion_condition == "<")
                        {
                            if (Convert.ToDouble(Num.Trim()) < proportion_compare_value)
                            {
                                OneCounts++;
                            }
                            else
                            {
                                ZeroCounts++;
                            }
                        }
                    }
                }
                if (ZeroCounts + OneCounts == 0)
                {
                    return "样本不存在，无法进行参数估计\r\n";
                }
                else
                {
                    if (ZeroCounts + OneCounts < 30)
                    {
                        Result.Append("样本数量较少，进行比例的参数估计可能会不稳定\r\n");
                    }
                    Result.Append(HTHeader_Proptest);
                    BigDecimal Proportion = (BigDecimal)OneCounts / ((BigDecimal)ZeroCounts + (BigDecimal)OneCounts);
                    count = ZeroCounts + OneCounts;
                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Proportion.ToString()), ' ', 12));
                    Result.Append("\t");
                    BigTemp = (Proportion - NullHypothesis) / Math.Sqrt((NullHypothesis * (1 - NullHypothesis)) /count);
                    if (Tail == "双侧")
                    {
                        Threshold = NORMSINV(1 - Significance / 2);
                        PValue = 2 * (1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString()))));
                    }
                    else if (Tail == "左单侧")
                    {
                        Threshold = NORMSINV(Significance);
                        PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString())));
                    }
                    else if (Tail == "右单侧")
                    {
                        Threshold = NORMSINV(1 - Significance);
                        PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp.ToString())));
                    }
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                    Result.Append("\r\n");
                    if (PValue < Significance)
                    {
                        Result.Append("在");
                        Result.Append(Significance.ToString());
                        Result.Append("的显著性水平上拒绝原假设");
                    }
                    else
                    {
                        Result.Append("在");
                        Result.Append(Significance.ToString());
                        Result.Append("的显著性水平上不拒绝原假设");
                    }
                }
                Result.Append("\r\n");
                Result.Append("\r\n");
                return Result.ToString();
            }
            else 
            {
                foreach (string Num in Numbers)
                {
                    if (Double.TryParse(Num, out TempNum))
                    {
                        sum += TempNum;
                        sum2 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                        count++;
                    }
                }
                Result.Append(HTHeader_XSquaretest_single);
                if (count <= 1)
                {
                    return "样本数量过少，无法进行假设检验！\r\n";
                }
                else
                {
                   
                      mean = sum / count;
                      Variance = (sum2 / count - mean * mean) * count / (count - 1);
                      Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName), ' ', 12));
                      Result.Append("\t");
                      Result.Append(StrManipulation.PadLeftX(count.ToString(), ' ', 12));
                      Result.Append("\t");
                      Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean.ToString()), ' ', 12));
                      Result.Append("\t");
                      Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance.ToString()).ToString()), ' ', 12));
                      Result.Append("\t");
                      int freedom = count -1;
                      BigDecimal XSquare;
                      double Threshold1=0;
                      double Threshold2=0;
                      string CI="";
                      if (NullHypothesis != 0)
                      {
                          XSquare = freedom * Variance / NullHypothesis;
                      }
                      else
                      {
                          XSquare = 0;
                          MessageBox.Show("检验方差不能为0");
                      }
                      if (Tail == "双侧")
                         {
                             
                             Threshold1 = chi2Ua(1 - Significance / 2,count -1);
                             //MessageBox.Show(Threshold1.ToString());
                             Threshold2 = chi2Ua(Significance / 2, count - 1);
                             //MessageBox.Show(Threshold2.ToString()); 
                             // 若自由度太大，会显示非数字
                             CI = "[" + MathV.round(Threshold1.ToString(),2,0) + "," + MathV.round(Threshold2.ToString(),2,0) + "]";
                             PValue = chi2(Convert.ToDouble(XSquare.ToString()), count - 1);
                      }
                       else if (Tail == "左单侧")
                         {
                             Threshold = chi2Ua(1 - Significance, count - 1);
                             PValue = chi2(Convert.ToDouble(XSquare.ToString()), count - 1);
                       }
                       else if (Tail == "右单侧")
                         {
                             Threshold = chi2Ua(Significance, count - 1);
                             PValue = chi2(Convert.ToDouble(XSquare.ToString()), count - 1);
                       }
                      if (Tail == "双侧")
                      {
                          Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(XSquare.ToString()), ' ', 12));
                          Result.Append("\t");
                          Result.Append(" ");
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX(CI, ' ', 12));
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                          Result.Append("\r\n");
                        
                      }
                      else
                      {
                          Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(XSquare.ToString()), ' ', 12));
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold1.ToString()), ' ', 12));
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                          Result.Append("\r\n");
                      }
                     if (PValue < Significance)
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上拒绝原假设");
                        }
                        else
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上不拒绝原假设");
                        }
                    }
                Result.Append("\r\n");
                Result.Append("\r\n");
                return Result.ToString();
                }
            
        }
        public static string HypothesisTesting2(DataTable MainDT, string ColName1,string ColName2,
            string Statistics, string Operation, string Tail, double Significance, double NullHypothesis, string proportion_condition, double proportion_compare_value)
        {
            int ColNum1 = Tabulation.FindCol(MainDT, ColName1);
            string[] Numbers1 = Tabulation.ReadVector(MainDT, ColNum1).ToArray();
            int ColNum2 = Tabulation.FindCol(MainDT, ColName2);
            string[] Numbers2 = Tabulation.ReadVector(MainDT, ColNum2).ToArray();
            StringBuilder Result = new StringBuilder();
            Result.Append("双样本假设检验: ");
            Result.Append(Statistics);
            Result.Append("\r\n");
            Result.Append("显著性水平: ");
            Result.Append(Significance.ToString());
            Result.Append("\t");
            Result.Append(Tail);
            Result.Append("\r\n原假设: ");
            Result.Append(Statistics);
            Result.Append(" ");
            Result.Append(Operation);
            Result.Append(" ");
            Result.Append(NullHypothesis.ToString());
            Result.Append("\r\n备择假设: ");
            Result.Append(Statistics);
            Result.Append(" ");
            if (Operation == "=")
            {
                Result.Append("<>");
            }
            else if (Operation == "<=")
            {
                Result.Append(">");
            }
            else
            {
                Result.Append("<");
            }
            Result.Append(" ");
            Result.Append(NullHypothesis.ToString());
            Result.Append("\r\n");
            BigDecimal sum1 = 0;
            BigDecimal mean1 = 0;
            BigDecimal Variance1 = 0;
            BigDecimal Sd1 = 0;
            BigDecimal sum2 = 0;
            BigDecimal mean2 = 0;
            BigDecimal Variance2 = 0;
            BigDecimal Sd2 = 0;
            int count1 = 0;
            int count2 = 0;
            BigDecimal sum2_1 = 0;
            BigDecimal sum2_2 = 0;
            Double TempNum = 0;
            BigDecimal BigTemp1 = 0;
            BigDecimal BigTemp2 = 0;
            double Threshold = 0;
            double PValue = 0;
            
            if (Statistics == "均值差")
            {
                foreach (string Num in Numbers1)
                {
                    if (Double.TryParse(Num, out TempNum))
                    {
                        sum1 += TempNum;
                        sum2_1 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                        count1++;
                    }
                }
                foreach (string Num in Numbers2)
                {
                    if (Double.TryParse(Num, out TempNum))
                    {
                        sum2 += TempNum;
                        sum2_2 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                        count2++;
                    }
                }
                 if(count1 >= 30 && count2 >= 30){
                    Result.Append(HTHeader_Ztest);
                }
                else
                {
                    Result.Append(HTHeader_Ttest);
                }
                 if (count1 <= 1 || count2 <= 1)
                 {
                     return "样本数量过少，无法进行假设检验！\r\n";
                 }
                 else
                 {
                     mean1 = sum1 / count1;
                     Variance1 = (sum2_1 / count1 - mean1 * mean1) * count1 / (count1 - 1);
                     mean2 = sum2 / count2;
                     Variance2 = (sum2_2 / count2 - mean2 * mean2) * count2 / (count2 - 1);
                     Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName1), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX(count1.ToString(), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean1.ToString()), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance1.ToString()).ToString()), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                     Result.Append("\r\n");

                     Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName2), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX(count2.ToString(), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean2.ToString()), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance2.ToString()).ToString()), ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                     Result.Append("\t");
                     Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                     Result.Append("\r\n");

                     if (count1 >= 30 && count2 >= 30)
                     {
                         //大样本
                         //z检验
                         Sd1 = MathV.Sqrt(Variance1.ToString()).ToString();
                         Sd2 = MathV.Sqrt(Variance2.ToString()).ToString();
                         BigTemp1 = (mean1 - mean2 - NullHypothesis) / MathV.Sqrt((Variance1 / count1 + Variance2 / count2).ToString()).ToString();
                         if (Tail == "双侧")
                         {
                             Threshold = NORMSINV(1 - Significance / 2);
                             PValue = 2 * (1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString()))));
                         }
                         else if (Tail == "左单侧")
                         {
                             Threshold = NORMSINV(Significance);
                             PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())));
                         }
                         else if (Tail == "右单侧")
                         {
                             Threshold = NORMSINV(1 - Significance);
                             PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())));
                         }
                         Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("均值差"), ' ', 12));
                         Result.Append("\t");
                         Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                         Result.Append("\t");
                         Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((mean1 - mean2).ToString()), ' ', 12));
                         Result.Append("\t");
                         Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                         Result.Append("\t");
                         Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp1.ToString()), ' ', 12));
                         Result.Append("\t");
                         Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold.ToString()), ' ', 12));
                         Result.Append("\t");
                         Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                         Result.Append("\r\n");
                         if (PValue < Significance)
                         {
                             Result.Append("在");
                             Result.Append(Significance.ToString());
                             Result.Append("的显著性水平上拒绝原假设");
                         }
                         else
                         {
                             Result.Append("在");
                             Result.Append(Significance.ToString());
                             Result.Append("的显著性水平上不拒绝原假设");
                         }
                     }
                     else
                     {
                         //小样本
                         BigTemp1 = (mean1 - mean2 - NullHypothesis) / MathV.Sqrt(((((count1 - 1) * Variance1 + (count2 - 1) * Variance2) / Convert.ToDouble(count1 + count2 - 1)) * (1 / Convert.ToDouble(count1) + 1 / Convert.ToDouble(count2))).ToString()).ToString();
                          if (Tail == "双侧")
                        {
                            Threshold = TINV(Significance / 2/2, count1 + count2 - 1);
                            //每个放进TINV的值都要除以2，这个bug之后会进行修复
                            PValue = TDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())/2), count1 + count2 - 1, 2);
                        }
                        else if (Tail == "左单侧")
                        {
                            Threshold = TINV(Significance/2, count1 + count2 - 1);
                            PValue = TDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString()) / 2), count1 + count2 - 1, 1);
                        }
                        else if (Tail == "右单侧")
                        {
                            Threshold = TINV(Significance / 2, count1 + count2 - 1);
                            PValue = TDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString()) / 2), count1 + count2 - 1, 1);
                        }
                          Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("均值差"), ' ', 12));
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((mean1 - mean2).ToString()), ' ', 12));
                          Result.Append("\t");
                          Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                          Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp1.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                        Result.Append("\r\n");
                        if (PValue < Significance)
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上拒绝原假设");
                        }
                        else
                        {
                            Result.Append("在");
                            Result.Append(Significance.ToString());
                            Result.Append("的显著性水平上不拒绝原假设");
                        }
                        
                    }
                     Result.Append("\r\n");
                     Result.Append("\r\n");
                     return Result.ToString();  
                 }
            }
            else if(Statistics == "比率差")
            {
                int OneCounts1 = 0;
                int ZeroCounts1 = 0;
                int OneCounts2 = 0;
                int ZeroCounts2 = 0;
                foreach (string Num in Numbers1)
                {
                    if (Num != "")
                    {
                        if (proportion_condition == "=")
                        {
                            if (Convert.ToDouble(Num.Trim()) == proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == ">=")
                        {
                            if (Convert.ToDouble(Num.Trim()) >= proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == ">")
                        {
                            if (Convert.ToDouble(Num.Trim()) > proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == "<=")
                        {
                            if (Convert.ToDouble(Num.Trim()) <= proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                        if (proportion_condition == "<")
                        {
                            if (Convert.ToDouble(Num.Trim()) < proportion_compare_value)
                            {
                                OneCounts1++;
                            }
                            else
                            {
                                ZeroCounts1++;
                            }
                        }
                    }
                }
                foreach (string Num in Numbers2)
                {
                    if (Num != "")
                    {
                        if (proportion_condition == "=")
                        {
                            if (Convert.ToDouble(Num.Trim()) == proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == ">=")
                        {
                            if (Convert.ToDouble(Num.Trim()) >= proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == ">")
                        {
                            if (Convert.ToDouble(Num.Trim()) > proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == "<=")
                        {
                            if (Convert.ToDouble(Num.Trim()) <= proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                        if (proportion_condition == "<")
                        {
                            if (Convert.ToDouble(Num.Trim()) < proportion_compare_value)
                            {
                                OneCounts2++;
                            }
                            else
                            {
                                ZeroCounts2++;
                            }
                        }
                    }
                }
                if (ZeroCounts1 + OneCounts1 == 0 && ZeroCounts2 + OneCounts2 == 0)
                {
                    return "样本不存在，无法进行参数估计\r\n";
                }
                else
                {
                    if (ZeroCounts1 + OneCounts1 < 30 && ZeroCounts2 + OneCounts2 < 30)
                    {
                        Result.Append("样本数量较少，进行比例的参数估计可能会不稳定\r\n");
                    }
                    Result.Append(HTHeader_Proptest);
                    BigDecimal Proportion1 = (BigDecimal)OneCounts1 / ((BigDecimal)ZeroCounts1 + (BigDecimal)OneCounts1);
                    BigDecimal Proportion2 = (BigDecimal)OneCounts2 / ((BigDecimal)ZeroCounts2 + (BigDecimal)OneCounts2);
                    count1 = ZeroCounts1 + OneCounts1;
                    count2 = ZeroCounts2 + OneCounts2;

                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName1), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count1.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Proportion1.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\r\n");

                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName2), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count2.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Proportion2.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\r\n");

                    BigTemp1 = (count1 * Proportion1 + count2 * Proportion2) / (count1 + count2);
                    BigTemp1 = (Proportion1 - Proportion2 - NullHypothesis) / MathV.Sqrt((BigTemp1 * (1 - BigTemp1) * (1 / Convert.ToDouble(count1) + 1 / Convert.ToDouble(count2))).ToString()).ToString();
                    if (Tail == "双侧")
                    {
                        Threshold = NORMSINV(1 - Significance / 2);
                        PValue = 2 * (1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString()))));
                    }
                    else if (Tail == "左单侧")
                    {
                        Threshold = NORMSINV(Significance);
                        PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())));
                    }
                    else if (Tail == "右单侧")
                    {
                        Threshold = NORMSINV(1 - Significance);
                        PValue = 1 - NORMDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())));
                    }
                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish("比率差"), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish((Proportion1 - Proportion2).ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(BigTemp1.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Threshold.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                    Result.Append("\r\n");
                    if (PValue < Significance)
                    {
                        Result.Append("在");
                        Result.Append(Significance.ToString());
                        Result.Append("的显著性水平上拒绝原假设");
                    }
                    else
                    {
                        Result.Append("在");
                        Result.Append(Significance.ToString());
                        Result.Append("的显著性水平上不拒绝原假设");
                    }
                }
                Result.Append("\r\n");
                Result.Append("\r\n");
                return Result.ToString();
            }
            else
            {
                foreach (string Num in Numbers1)
                {
                    if (Double.TryParse(Num, out TempNum))
                    {
                        sum1 += TempNum;
                        sum2_1 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                        count1++;
                    }
                }
                foreach (string Num in Numbers2)
                {
                    if (Double.TryParse(Num, out TempNum))
                    {
                        sum2 += TempNum;
                        sum2_2 += (BigDecimal)TempNum * (BigDecimal)TempNum;
                        count2++;
                    }
                }

                Result.Append(HTHeader_Ftest);
                if (NullHypothesis == 0)
                {
                    MessageBox.Show("检验方差不能为0");
                }

                if (count1 <= 1 || count2 <= 1)
                {
                    return "样本数量过少，无法进行假设检验！\r\n";
                }
                else
                {
                    mean1 = sum1 / count1;
                    Variance1 = (sum2_1 / count1 - mean1 * mean1) * count1 / (count1 - 1);
                    mean2 = sum2 / count2;
                    Variance2 = (sum2_2 / count2 - mean2 * mean2) * count2 / (count2 - 1);
                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName1), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count1.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean1.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance1.ToString()).ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\r\n");

                    Result.Append(StrManipulation.PadLeftX(StrManipulation.VariableNamePolish(ColName2), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(count2.ToString(), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(mean2.ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(MathV.Sqrt(Variance2.ToString()).ToString()), ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\t");
                    Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                    Result.Append("\r\n");
                    BigDecimal FValue;
                    FValue = Variance1 / Variance2;
                    double Threshold1 = 0;
                    double Threshold2 = 0;
                    string CI = "";

                    if (Tail == "双侧")
                    {
                        Threshold1 = FINV(1 - Significance / 2, count1 - 1, count2 - 1);
                        Threshold2 = FINV(Significance / 2, count1 - 1, count2 - 1);
                        CI = "[" + MathV.round(Threshold1.ToString(), 2, 0) + "," + MathV.round(Threshold2.ToString(), 2, 0) + "]";
                        PValue = FDIST(Math.Abs(Convert.ToDouble(FValue.ToString())), count1 - 1, count2 - 1);

                    }
                    else if (Tail == "左单侧")
                    {
                        Threshold = FINV(Significance, count1 - 1, count2 - 1);
                        PValue = 1 - FDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())), count1 - 1, count2 - 1);
                    }
                    else if (Tail == "右单侧")
                    {
                        Threshold = FINV(1 - Significance, count1 - 1, count2 - 1);
                        PValue = 1 - FDIST(Math.Abs(Convert.ToDouble(BigTemp1.ToString())), count1 - 1, count2 - 1);
                    }
                    if (Tail == "双侧")
                    {
                        Result.Append(StrManipulation.PadLeftX("方差比", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(FValue.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(CI, ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                        Result.Append("\r\n");

                    }
                    else
                    {
                        Result.Append(StrManipulation.PadLeftX("方差比", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX("-", ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(FValue.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(CI.ToString()), ' ', 12));
                        Result.Append("\t");
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(PValue.ToString()), ' ', 12));
                        Result.Append("\r\n");
                    }
                    if (PValue < Significance)
                    {
                        Result.Append("在");
                        Result.Append(Significance.ToString());
                        Result.Append("的显著性水平上拒绝原假设");
                    }
                    else
                    {
                        Result.Append("在");
                        Result.Append(Significance.ToString());
                        Result.Append("的显著性水平上不拒绝原假设");
                    }
                }
                Result.Append("\r\n");
                Result.Append("\r\n");
                return Result.ToString();
            }
        }

        public static BigDecimal Covariance(string [] NumberSeries1,ref BigDecimal Mean1,ref BigDecimal Variance1, string[] NumberSeries2,ref BigDecimal Mean2,ref BigDecimal Variance2)
        {
            //协方差计算
            BigDecimal sum1 = 0;
            BigDecimal sum2 = 0;
            //sum1和sum2用于计算均值
            BigDecimal sum1_2 = 0;
            BigDecimal sum2_2 = 0;
            //sum1_2和sum2_2用于计算方差
            int len = NumberSeries1.Length;
            Mean1 = 0;
            Mean2 = 0;
            BigDecimal E_xy = 0;
            double Temp1 = 0;
            double Temp2 = 0;
            int count = 0;
            for (int i = 0; i < len; i++)
            {
                if (double.TryParse(NumberSeries1[i], out Temp1) && double.TryParse(NumberSeries2[i], out Temp2))
                {
                    E_xy += (BigDecimal)Temp1 * (BigDecimal)Temp2;
                    sum1 += (BigDecimal)Temp1;
                    sum2 += (BigDecimal)Temp2;
                    sum1_2 += (BigDecimal)Temp1 * (BigDecimal)Temp1;
                    sum2_2 += (BigDecimal)Temp2 * (BigDecimal)Temp2;
                    count++;
                }
            }
            if (count > 1)
            {
                Mean1 = sum1 / count;
                Mean2 = sum2 / count;
                Variance1 = (sum1_2 / count - Mean1 * Mean1) ;
                Variance2 = (sum2_2 / count - Mean2 * Mean2);
                return E_xy / count - Mean1 * Mean2;
            }
            else
            {
                return 0;
            }
        }

        public static BigDecimal Corr(string[] NumberSeries1, string[] NumberSeries2)
        {
            //相关系数计算
            BigDecimal Mean1 = 0;
            BigDecimal Mean2 = 0;
            BigDecimal Variance1 = 0;
            BigDecimal Variance2 = 0;
            BigDecimal cov = Covariance(NumberSeries1,ref Mean1,ref Variance1, NumberSeries2,ref Mean2,ref Variance2);
            BigDecimal Rho = cov / (MathV.Sqrt((Variance1 * Variance2).ToString())).ToString();
            //计算相关系数
            return Rho;
        }
        public static void MultiCorr(DataTable dt,int [] ColNums,RichTextBox richTextBox1)
        {
            StringBuilder Result = new StringBuilder();
            //相关系数输出是一个矩阵，因此要有行名和列名
            //例如:
            //      列1      列2      列3
            //列1    1         0        0
            //列2    0         1        0
            //列3    0         1        1
            //自身的相关系数一定是1
            Result.Append(StrManipulation.PadLeftX(" ",' ',12));
            Result.Append("\t");
            foreach (int EachCol in ColNums)
            {
                Result.Append(StrManipulation.PadLeftX(dt.Columns[EachCol].ColumnName,' ',12));
                Result.Append("\t");
            }
            Result.Append("\r\n");
            foreach (int EachCol in ColNums)
            {
                Result.Append(StrManipulation.PadLeftX(dt.Columns[EachCol].ColumnName,' ',12));
                Result.Append("\t");
                foreach (int EveryCol in ColNums)
                {
                    if (EachCol == EveryCol)
                    {
                        Result.Append(StrManipulation.PadLeftX("1.000",' ',12));
                        Result.Append("\t");
                    }
                    else
                    {
                        string[] NumberSeries1 = Tabulation.ReadVector(dt,EachCol).ToArray();
                        string[] NumberSeries2 = Tabulation.ReadVector(dt,EveryCol).ToArray();
                        Result.Append(StrManipulation.PadLeftX(MathV.NumberPolish(Corr(NumberSeries1, NumberSeries2).ToString()),' ',12));
                        Result.Append("\t");
                    }
                }
                Result.Append("\r\n");
            }
            richTextBox1.AppendText(Result.ToString());
            MainForm.S.richTextBox1.Select();//让RichTextBox获得焦点
            MainForm.S.richTextBox1.Select(MainForm.S.richTextBox1.TextLength, 0);//将插入符号置于文本结束处 
            MainForm.S.richTextBox1.ScrollToCaret(); 
        }
        public static BigDecimal[,] MultiRegBeta(BigDecimal[,] b1, BigDecimal[,] b3, BigDecimal[,] x, BigDecimal[,] y)
        { //返回多元回归参数估计值**************************************注意：x第一列为1*******************
          //得到k行1列的向量，k为带估计参数数目
            int len11 = x.GetLength(0);//行数
            int len12 = x.GetLength(1);//列数
            BigDecimal[,] b4 = MathV.MatTimes(b3, b1);
            BigDecimal[,] bhat = MathV.MatTimes(b4, y);
            return bhat;
            
        }

        public static BigDecimal[,] MultiRegP(BigDecimal[,] b3, BigDecimal[,] bhat, BigDecimal[,] x, BigDecimal[,] y)
        {    //返回多元回归P值和t值
             //二维数组，第一列为p值，第二列为t值
            int len11 = x.GetLength(0);//行数
            int len12 = x.GetLength(1);//列数


            BigDecimal[,] b5 = MathV.MatTimes(x, bhat);
            BigDecimal[,] epsilon = MathV.MatMinu(y, b5);
            BigDecimal[] variance = new BigDecimal[len11];
            BigDecimal sum = 0;
            BigDecimal sum2 = 0;



            for (int i = 0; i < len11; i++)
            {
                variance[i] = epsilon[i, 0];
                sum2 += variance[i] * variance[i];
            }
            BigDecimal Variance = sum2 / (len11 - len12);
            
            BigDecimal sigma2 = Variance;  //Mean Square Error (MSE) 
            BigDecimal[,] b6 = new BigDecimal[len12, len12]; //sigma^2*(C^T C)^{-1} 参数方差
            for (int i = 0; i < len12; i++)
            {
                for (int j = 0; j < len12; j++)
                {
                    b6[i, j] = sigma2 * b3[i, j];
                }
            }

            BigDecimal[] std_b = new BigDecimal[len12];
            BigDecimal[,] value_b = new BigDecimal[len12, 2];
            BigDecimal[] tvalue_b = new BigDecimal[len12];
            for (int i = 0; i < len12; i++)
            {
                if (b6[i, i] >= 0)
                {
                    std_b[i] = MathV.Sqrt(b6[i, i].ToString()).ToString();
                   
                    tvalue_b[i] = bhat[i, 0] / (std_b[i]);
                    if (len11 < 200)
                    {
                        //小样本
                        value_b[i, 0] = Stat.TDIST(Math.Abs(Convert.ToDouble(tvalue_b[i].ToString())),len11 - len12,2);
                    }
                    else
                    {
                        value_b[i, 0] = 2 *(1 - Stat.NORMDIST(Math.Abs(Convert.ToDouble(tvalue_b[i].ToString()))));
                    }
                    value_b[i, 1] = tvalue_b[i];
                }
                else
                {
                    for (int j = 0; j < len12; j++)
                    {
                        value_b[j, 1] = 0;
                        value_b[j, 0] = 2;
                    }
                }
            }
            return value_b;
        }

        public static string MultiRegR(BigDecimal[,] bhat, BigDecimal[,] x, BigDecimal[,] y)
        {    //返回多元回归拟合优度R^2 and adj_R^2 and F值
            int len11 = x.GetLength(0);//x行数
            int len12 = x.GetLength(1);//x列数
            int len21 = y.GetLength(1);//y列数
            int len22 = y.GetLength(0);//y列数
            BigDecimal ysum = 0;
            for (int i = 0; i < len11; i++)
            {
                ysum += y[i, 0];
            }
            BigDecimal ybar = ysum / len11;
            BigDecimal TSS = 0;
            for (int i = 0; i < len11; i++)
            {
                TSS += (y[i, 0] - ybar) * (y[i, 0] - ybar);
            }
            
            BigDecimal[,] b5 = MathV.MatTimes(x, bhat);
            BigDecimal[,] epsilon = MathV.MatMinu(y, b5);
            BigDecimal ESS = 0;
            for (int i = 0; i < len11; i++)
            {
                ESS += (epsilon[i, 0]) * (epsilon[i, 0]);
            }
            BigDecimal MSS = TSS - ESS;
            BigDecimal Rsquare = MSS / TSS;
            BigDecimal Adj_Rsquare = 1 - (1 - Rsquare) * (len11 - 1) / (len11 - len12);


            //MessageBox.Show((ESS / new BigNumber((len11 - len12).ToString()).ToString()).ToString());
            //MessageBox.Show((new BigNumber(ESS.ToString()) / new BigNumber((len11 - len12).ToString())).ToString());
            BigNumber tmp = (new BigNumber(ESS.ToString())) / new BigNumber((len11 - len12).ToString()); //调用BigNumber ,放置出现很小误认为0
            BigDecimal Fvalue = (MSS / (len12 - 1)) / tmp.ToString();
            return Rsquare.ToString() + "," + Adj_Rsquare.ToString() + "," + Fvalue.ToString();

        }
        public static void BetaAlphaBeta(int SampleSize,int Success,ref int Alpha,ref int Beta){
            //根据用户输入的等效样本数量，确定beta分布的alpha和beta
            //SampleSize为用户输入的样本容量，Success为成功次数
            Alpha = Success + 1;
            Beta = SampleSize - Success + 1;
            return;
        }
        public static void ConjugateBeta(ref int Alpha,ref int Beta,int n,int y){
            //获得Beta分布共轭的后验结果
            //n为新试验次数，y为成功次数
            Alpha = Alpha + y;
            Beta = Beta + n - y;
            return;
        }
        public static double BetaPDF(double x,int a,int b)
        {
            BigInteger Numerator = MathV.Factorial(a + b - 1);
            BigInteger Denominator = MathV.Factorial(a - 1) * MathV.Factorial(b - 1);
            BigNumber Quotient = (BigNumber)Numerator.ToString() / (BigNumber)Denominator.ToString();
            double NormConst = (double)Quotient;
            return NormConst * Math.Pow(x, a - 1) * Math.Pow(1 - x, b - 1);
        }
        public static double BinomialPDF(double p, int n, int k)
        {
            //k为成功次数

            BigNumber Combination = MathV.Combination(n, k).ToString();
            return (double)Combination * Math.Pow(p, k) * Math.Pow(1 - p, n - k);
        }
        public static double BetaPrediction(int a, int b,int n,int y)
        {
            BigInteger Numerator = MathV.Factorial(a + b - 1);
            BigInteger Denominator = MathV.Factorial(a - 1) * MathV.Factorial(b - 1);
            BigNumber Quotient = (BigNumber)Numerator.ToString() / (BigNumber)Denominator.ToString();
            double NormConst = (double)Quotient;
            Numerator =MathV.Combination(n,y)*MathV.Factorial(y + a - 1) * MathV.Factorial(n - y + b - 1);
            Denominator = MathV.Factorial(a + b + n - 1);
            Quotient = (BigNumber)Numerator.ToString() / (BigNumber)Denominator.ToString();
            return NormConst * (double)Quotient;
        }
        public static bool DirichletAlphas(List<int> Nums, int ClassLen, ref List<int> Alphas)
        {
            Alphas.Clear();
            if (ClassLen != Nums.Count)
            {
                return false;
            }
            for (int i = 0; i < ClassLen; i++)
            {
                Alphas.Add(Nums[i] + 1);
            }
            return true;
        }
        public static void ConjugateDirichlet(ref List<int> Alphas,int [] successes)
        {
            if (Alphas.Count != successes.Length)
            {
                return;
            }
            else 
            {
                int len = Alphas.Count;
                for (int i = 0; i < len; i++)
                {
                    Alphas[i]+=successes[i];
                }
                return;
            }
        }
        public static string DirichletPrediction(List<int> Numbers,List<int>Alphas)
        {
          BigInteger Denominator = 1;
            int k = Alphas.Count;
            for (int i = 0; i < k; i++)
            {
                Denominator *= MathV.Factorial(Numbers[i]);
            }
            BigInteger Numerator = MathV.Factorial(Numbers.Sum());
            BigNumber Factor1 = (((BigNumber)Numerator.ToString()) / ((BigNumber)Denominator.ToString())).ToString();
            Denominator = 1;
            for (int i = 0; i < k; i++)
            {
                Denominator *= MathV.Factorial(Alphas[i]-1);
            }
            Numerator = MathV.Factorial(Alphas.Sum() - 1);
            BigNumber Factor2 = (((BigNumber)Numerator.ToString()) / ((BigNumber)Denominator.ToString())).ToString();
            Denominator = MathV.Factorial(Alphas.Sum() + Numbers.Sum() - 1);
            Numerator = 1;
            for (int i = 0; i < k; i++)
            {
                Numerator *= MathV.Factorial(Alphas[i]+Numbers[i]- 1);
            }
            BigNumber Factor3 = (((BigNumber)Numerator.ToString()) / ((BigNumber)Denominator.ToString())).ToString();
            BigNumber Result = Factor1 * Factor2 * Factor3;
            return Result.ToString();
        }

        //******************************************************************************************
        //*********************************    时间序列    *****************************************
        //******************************************************************************************
        public static string[] TimeseriesTest(int length, BigDecimal sum_Qtest,BigDecimal sum_LBtest,int lag,BigDecimal[] corr)
        {
            //白噪声检验，检验纯随机性和平稳性，输出相关系数和Qtest、LBtest的检验值和P值
            BigDecimal Qtest = sum_Qtest * length;
            BigDecimal P_Qtest = chi2(Math.Abs(Convert.ToDouble(MathV.round(Qtest.ToString(), 4, 0))), length);
            BigDecimal LBtest = length * (length + 2) * sum_LBtest;
            BigDecimal P_LBtest = chi2(Math.Abs(Convert.ToDouble(MathV.round( LBtest.ToString(),4,0))), length);
            string[] result = new string[lag + 4];
            string[] corr_str = new string[lag];
            for (int i = 0; i < lag; i++)
            {
                corr_str[i] = corr[i].ToString();
            }
            corr_str.CopyTo(result, 0);
            result[lag] = Qtest.ToString();
            result[lag + 1] = (1 - P_Qtest).ToString();
            result[lag + 2] = LBtest.ToString();
            result[lag + 3] = (1 - P_LBtest).ToString();
            return result;
        }

        public static BigDecimal[] Diff(BigDecimal[] timeseries)
        {
            //一阶一步差分
            int len = timeseries.Length;
            BigDecimal[] diff = new BigDecimal[len - 1];
            for (int i = 0; i < len - 1; i++)
            {
                diff[i] = timeseries[i + 1] - timeseries[i];
            }
            return diff;
        }

        public static BigDecimal[] AR1(string[] NumSeries, int length, BigDecimal[] corr,int period)
        {
            BigDecimal[] epsilon = new BigDecimal[length - 1];
            BigDecimal sum2 = 0;
            for (int i = 0; i < length - 1; i++)
            {
                epsilon[i] = NumSeries[i + 1] - corr[0] * NumSeries[i];
                sum2 += epsilon[i] * epsilon[i];
            }
            Random ra = new Random();
            BigDecimal[] forecast = new BigDecimal[period];
            int tmp = 0;
            for (int j = 0; j < period; j++)
            {
                tmp = ra.Next(0, length - 2);
                forecast[j] = epsilon[tmp];
                if (j == 0)
                {
                    forecast[j] = NumSeries[length - 1] * corr[0] + forecast[0];
                }
                else
                {
                    forecast[j] = forecast[j - 1] * corr[0] + forecast[j];
                }
            }
            BigDecimal[] result = new BigDecimal[period + 1];
            forecast.CopyTo(result,0);
            result[period] = sum2;
            //BigNumber[] all = new BigNumber[len + period];
            //timeseries.CopyTo(all, 0);
            //forecast.CopyTo(all, len);
            return result;
        }
        public static BigDecimal[] AR2(string[] NumSeries, int length, BigDecimal[] corr, int period)
        {
            BigDecimal[] epsilon = new BigDecimal[length - 2];
            BigDecimal sum2 = 0;
            BigDecimal fi1 = (1 - corr[1]) * corr[0] / (1 - corr[0] *  corr[0]);
            BigDecimal fi2 = (corr[1] - corr[0] * corr[0]) / (1 - corr[0] * corr[0]);
            for (int i = 0; i < length - 2; i++)
            {
                epsilon[i] = NumSeries[i + 2] - fi1 * NumSeries[i + 1] - fi2 * NumSeries[i];
                sum2 += epsilon[i] * epsilon[i];
            }
            Random ra = new Random();//伪随机数，生成残差epsilon，保证每次生成的结果相同
            BigDecimal[] forecast = new BigDecimal[period];
            int tmp = 0;
            for (int j = 0; j < period; j++)
            {
                tmp = ra.Next(0, length - 2);
                forecast[j] = epsilon[tmp];
                if (j == 0)
                {
                    forecast[j] = NumSeries[length - 1] * fi1 + NumSeries[length - 2] * fi2 + forecast[0];
                }
                else if (j == 1)
                {
                    forecast[j] = forecast[j - 1] * fi1 + NumSeries[length - 1] * fi2 + forecast[0];
                }
                else
                {
                    forecast[j] = forecast[j - 1] * fi1 + forecast[j - 2] * fi2 + forecast[j];
                }
            }
            BigDecimal[] result = new BigDecimal[period + 1];
            forecast.CopyTo(result, 0);
            result[period] = sum2;
            return result;
        }
 



        }
    }

