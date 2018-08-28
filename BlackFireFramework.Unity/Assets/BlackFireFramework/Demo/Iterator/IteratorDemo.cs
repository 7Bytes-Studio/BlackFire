//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    public sealed class IteratorDemo : MonoBehaviour
    {
        private IEnumerator Start()
        {
            for (int i = 1; i <= 100; i++)
            {
                yield return new WaitForSeconds(0.5f);
                var _name = "Test_" + i;
                Iterator.Start(_name,IteratorTest(_name));
            }
        }

        
        private IEnumerator IteratorTest(string name)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(string.Format("The name '{0}' Has done.",name));
            Iterator.Cancel(name);
        }

    }
}