using System;
using System.Collections.Generic;
using System.Text;

namespace ZTool.Lang.Util
{
    /// <summary>
    /// 数值工具类
    /// </summary>
    public class NumberUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToInteger(string s)
        {
            int result;
            if (int.TryParse(s, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 四舍五入，支持特殊处理：若数值非零但四舍五入后为零，则返回0.1的指定小数位次幂。
        /// </summary>
        /// <param name="value"> 数值 </param>
        /// <param name="decimals"> 小数点位数</param>
        /// <param name="allowRoundZero"> 是否允许四舍五入值为零，如果不允许，输入值不为0，舍入后为0，则返回0.1的decimals的幂</param>
        /// <returns></returns>
        public static decimal Round(decimal value, int decimals, bool allowRoundZero = false)
        {
            decimal roundValue = decimal.Round(value, decimals, MidpointRounding.AwayFromZero);
            if (roundValue == decimal.Zero && value != decimal.Zero && !allowRoundZero)
            {
                return (decimal)Math.Pow(0.1, decimals);
            }
            else
            {
                return roundValue;
            }
        }
    }
}
