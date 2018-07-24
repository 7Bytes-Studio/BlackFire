using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework;

public class GroupDemo : MonoBehaviour {


    private void Start()
    {
        Organize.CreateGroup<UICommonGroup>(1,"UICommonGroup",100);
        Organize.SetCommandPermission<IUICommonTest>(100);
        Organize.ExecuteCommand<IUICommonTest>(1,i=>i.HideAllCommonUI());
        Organize.SetCommandPermission<IUICommonTest>(101);
        Organize.ExecuteCommand<IUICommonTest>(1,i=>i.HideAllCommonUI());
    }

}
