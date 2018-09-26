//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class FormUnitTest : MonoBehaviour
    {
        private Asset m_CC919 = null;
        private Asset m_Boeing787 = null;
        private IEnumerator Start()
        {
            BlackFire.Form.CreateFormGroup<PlaneGroup>("Plane",100,0);
            
            m_CC919 = Resources.Load<Asset>("CC919");
            var cc919 = BlackFire.Form.Instantiate<CC919>(m_CC919,"Plane",100);
            
            m_Boeing787 = Resources.Load<Asset>("Boeing787");
            var boeing787 = BlackFire.Form.Instantiate<Boeing787>(m_Boeing787,"Plane",101);
            
            yield return new WaitForSeconds(1f);
            Organize.SetCommandPermission<IFly_FormGroupMemberCommand>(100);
            BlackFire.Form.ExecuteCommand<IFly_FormGroupMemberCommand>("Plane",i=>i.Fly());

        }
    }
}