//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;

namespace BlackFireFramework
{

    using ILRuntime.Runtime.Enviorment;

    public interface IHotFixAssemblyLoader
    {
        string AssemblyPath { get; }
        IEnumerator LoadHotFixAssembly(AppDomain appDomain, Action loadCompleteCallback);
    }




}
