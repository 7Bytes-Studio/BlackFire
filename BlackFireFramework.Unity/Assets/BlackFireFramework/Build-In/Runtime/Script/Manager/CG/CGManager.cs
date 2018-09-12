//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using OpenCVForUnity;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 人脸图像管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/CG")]
	public sealed partial class CGManager : ManagerBase
    {
        protected override void OnStart()
        {
            base.OnStart();
            Init_FaceRecognizer();
        }
    }



}
