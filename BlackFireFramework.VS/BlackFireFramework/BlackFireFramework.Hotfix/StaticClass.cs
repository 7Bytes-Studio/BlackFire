using System;
using System.Collections;
using UnityEngine;
namespace BlackFireFramework.Hotfix
{
    public static class StaticClass
    {

        public static void StaticMethodTest_Void_Empty()
        {

            Log.Info("!!!StaticMethodTest_Void_Empty!!!");

        }


        public static void StaticMethodTest_Void_Monobehaviour(object monobehaviour)
        {

            Log.Info("!!!StaticMethodTest_Void_Monobehaviour!!!");
            Log.Info("!!!"+ monobehaviour.ToString() + "!!!");

            var go = (monobehaviour as UnityEngine.MonoBehaviour).gameObject;

            for (int i = 0; i < 50; i++)
            {
               var gg = new GameObject(":::NB");
                gg.transform.SetParent(go.transform);
            }

        }


        public static void TestStartEnumerator1()
        {
            UnityInterface.StartCoroutine(TestEnumerator1());
        }

        public static void TestStartEnumerator2()
        {
            UnityInterface.StartCoroutine(TestEnumerator2());
        }


        public static IEnumerator TestEnumerator1()
        {
            Log.Info("!!!WaitForSeconds!!!");
            yield return new WaitForSeconds(3f);
            Log.Info("!!!WaitForSeconds!!! Done!!!");

            BlackFireFramework.Event.Fire("TestDelegate","Alan:Sender",EventArgs.Empty);
        }

        public static IEnumerator TestEnumerator2()
        {
            while (true)
            {
                Log.Info("!!!null!!!");
                yield return null;

            }

        }

    }
}
