//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFireFramework.Unity
{
    public static class TransformExtension
	{
        public static T FindComponent<T>(this Transform transform)
        {
            T target = default(T);
            Utility.Transform.TraverseParents(transform, t => null == (target = t.GetComponent<T>()) );
            return target;
        }
	
	}
}
