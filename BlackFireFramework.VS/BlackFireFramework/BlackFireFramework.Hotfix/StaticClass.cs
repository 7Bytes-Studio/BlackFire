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



    }
}
