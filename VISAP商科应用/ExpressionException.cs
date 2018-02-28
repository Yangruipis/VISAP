/*============================================
 * 类名 :ExpressionException
 * 描述 :
 *   
 * 创建时间: 2011-2-6 13:37:15
 * Blog:   http://home.cnblogs.com/xiangism
 *============================================*/
using System;
using System.Collections.Generic;

using System.Text;

namespace VISAP商科应用
{
    /// <summary>表示式的异常类</summary>
    class ExpressionException : Exception
    {
        /// <summary>错误开始的位置</summary>
        public int Index { get; set; }
        /// <summary>错误的长度</summary>
        public int Length { get; set; }

        public ExpressionException( string value ) : this( value, 0 ) { }
        public ExpressionException( string value, int index )
            : this( value, index, 0 ) { }
        public ExpressionException( string value, int index, int length )
            : base( value )
        {
            this.Index = index;
            this.Length = length;
        }
    }
}
