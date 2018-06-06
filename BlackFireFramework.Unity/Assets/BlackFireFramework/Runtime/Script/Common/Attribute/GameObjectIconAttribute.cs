//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;

namespace BlackFireFramework.Unity
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
	public sealed class GameObjectIconAttribute : Attribute 
	{
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iconPath">icon图片所在的资源路径(相对于Resources目录下的路径)。</param>
        public GameObjectIconAttribute(string iconPath)
        {
            IconPath = iconPath;
        }

        /// <summary>
        /// Icon资源所在的相对路径。
        /// </summary>
        public string IconPath { get; private set; }

	}
}
