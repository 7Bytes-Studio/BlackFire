//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {
        public static class GL
        {

            public static Vector3[] QuadrangleLine(Vector3 origin, Vector3 end,float width)
            {
                var vector = (end - origin).normalized;
                var virticalVector = Quaternion.AngleAxis(90, Vector3.forward) * vector;
                return new Vector3[] {
                                        origin + virticalVector * (width / 2),
                                        origin - virticalVector * (width / 2),
                                        end + virticalVector * (width / 2),
                                        end - virticalVector * (width / 2),
                                     };
            }
        }

    }
}
