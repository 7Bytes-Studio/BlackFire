using System;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 游戏轮询委托管家接口。
    /// </summary>
    public interface ILoopManager:IManager
    {
        /// <summary>
        /// 注册的委托数量。
        /// </summary>
        int DelegateCount { get; }

        /// <summary>
        /// 注册的被物理帧轮训的委托数量。
        /// </summary>
        int FixedUpdateDelegateCount { get; }

        /// <summary>
        /// 注册的被逻辑帧轮训的委托数量。
        /// </summary>
        int UpdateDelegateCount { get; }

        /// <summary>
        /// 注册的被逻辑帧后轮训的委托数量。
        /// </summary>
        int LateUpdateCount { get; }

        /// <summary>
        /// 获取所有被相机场景渲染完成后轮训条目的数量。
        /// </summary>
        int OnRenderObjectCount { get; }

        /// <summary>
        /// 获取所有被轮训条目的信息。
        /// </summary>
        /// <returns>委托命名数组。</returns>
        string[] GetNames();

        /// <summary>
        /// 获取所有被物理帧轮训条目的名字数组。
        /// </summary>
        /// <returns>条目的信息。</returns>
        string[] GetFixedUpdateNames();

        /// <summary>
        /// 获取所有被逻辑帧轮训条目的名字数组。
        /// </summary>
        /// <returns>条目的信息。</returns>
        string[] GetUpdateNames();

        /// <summary>
        /// 获取所有被逻辑帧后轮训条目的名字数组。
        /// </summary>
        /// <returns>条目的信息。</returns>
        string[] GetLateUpdateNames();

        /// <summary>
        /// 是否已经注册了委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        /// <returns>结果。</returns>
        bool HasRegisted(Delegate @delegate);

        /// <summary>
        /// 是否已经注册了委托。
        /// </summary>
        /// <param name="delegate">给委托的命名。</param>
        /// <returns>结果。</returns>
        bool HasRegisted(string name);

        /// <summary>
        /// 注册委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        void Register(Delegate @delegate,LoopType loopType,string name=null);

        /// <summary>
        /// 注销委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        void UnRegister(Delegate @delegate);

        /// <summary>
        /// 注销委托。
        /// </summary>
        /// <param name="delegate">委托实例。</param>
        void UnRegister(string name);
    }
}