//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------



namespace BlackFireFramework.Unity
{
    /// <summary>
    /// BlackFire Framework 功能管家接口。
    /// </summary>
    public interface IManager 
	{
        /// <summary>
        /// 是否可用。
        /// </summary>
        bool IsWorking { get; }

        /// <summary>
        /// 启动管家。
        /// </summary>
        void StartManager();

        /// <summary>
        /// 关闭管家。
        /// </summary>
        void ShutdownManager();
	}

}
