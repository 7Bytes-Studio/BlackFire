/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/


namespace BlackFire
{
    /// <summary>
    /// 框架依赖倒置容器。
    /// </summary>
    public static partial class Framework
    {
        private static ISparrowIoC s_IoC = new SparrowIoC();

        /// <summary>
        /// 框架IoC服务接口。
        /// </summary>
        internal static ISparrowIoC IoC { get { return s_IoC; } }

        /// <summary>
        /// 创建一个IoC服务接口。
        /// </summary>
        /// <returns>IoC服务接口实例。</returns>
        public static ISparrowIoC CreateIoC() { return new SparrowIoC(); }
    }
}
