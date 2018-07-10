//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 引用计数器接口。
    /// </summary>
	public interface IReferenceCounter 
	{
        /// <summary>
        /// 当引用计数为零事件。
        /// </summary>
        event Action OnRefCountIsZero;

        /// <summary>
        /// 引用计数。
        /// </summary>
        int RefCount { get; }

        /// <summary>
        /// 累加次数。
        /// </summary>
        int CumulativeCount { get; }
        /// <summary>
        /// 累减次数。
        /// </summary>
        int RegressiveCount { get; }

        /// <summary>
        /// 引用累加功能。
        /// </summary>
        /// <param name="ref_owner">引用的所属者。</param>
        void Cumulative(object ref_owner);

        /// <summary>
        /// 引用累减功能。
        /// </summary>
        /// <param name="ref_owner">引用的所属者。</param>
        void Regressive(object ref_owner);
    }
}
