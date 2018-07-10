//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections.Generic;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public class UguiEntity : EntityBase<UguiLogicBase>
    {


        protected override void OnSpawn(object args)
        {
            if (null!= args && args is UguiLogicBase) 
            {
                Target = args as UguiLogicBase;
            }

            if (null!= Target)
            {
                Target.Open();
            }
        }

        protected override void OnRecycle()
        {
            Target.Close();
        }

        protected override void OnRelease()
        {
            GameObject.DestroyImmediate(Target.gameObject);
            Target = null;
        }


    }
}
