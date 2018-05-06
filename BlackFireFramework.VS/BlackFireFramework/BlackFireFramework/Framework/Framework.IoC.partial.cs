//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFireFramework
{
    public static partial class Framework
    {
        private static ISparrowIoC s_IoC = new SparrowIoC();

        /// <summary>
        /// 框架IoC服务接口。
        /// </summary>
        public static ISparrowIoC IoC { get { return s_IoC; } }
    }
}
