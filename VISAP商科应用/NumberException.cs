/*============================================
 * 类名 :NumberException
 * 描述 :
 *   
 * 创建时间: 2011-1-31 15:04:50
 * Blog:   http://home.cnblogs.com/xiangism
 *============================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace VISAP商科应用
{
    /// <summary>大数错误类，用于字符串不能表示一个数字时提示错误信息</summary>
    public class NumberException : Exception
    {

        public NumberException( string message, int index )
            : base( message )
        {
            _index = index;
            //_message = message;

        }
        int _index;
        /// <summary>发生错误的位置</summary>
        public int Index { get { return _index; } }
        //string _message;
        ///// <summary>错误的类型</summary>
        //public override string Message
        //{
        //    get { return _message; }
        //}
    }
}
