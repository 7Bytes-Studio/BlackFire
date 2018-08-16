using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework;

public class GroupDemo : MonoBehaviour {


    private void Start()
    {
        Organize.CreateGroup<UICommonTestGroup>(1,"UICommonGroup",100);
        
        Organize.Join(1,new UICommonTestGroupMember(11),11);
        Organize.Join(1,new UICommonTestGroupMember(22),22);
        
        Organize.SetCommandPermission<IGroupCommandTest>(100);
        Organize.SetCommandPermission<ISingleGroupMemberCommandTest>(100);
        Organize.SetCommandPermission<IMultiGroupMemberCommandTest>(100);
        
        Organize.ExecuteCommand<IGroupCommandTest>(1,i=>i.HideAllUI());
        Organize.ExecuteCommand<ISingleGroupMemberCommandTest>(1,i=>i.HideUI_SingleCommand());
        Organize.ExecuteCommand<IMultiGroupMemberCommandTest>(1,i=>i.HideUI_MultiCommand());
        
//        Organize.SetCommandPermission<IGroupCommandTest>(101);
//        
//        Organize.ExecuteCommand<IGroupCommandTest>(1,i=>i.HideAllUI());
//        Organize.ExecuteCommand<ISingleGroupMemberCommandTest>(1,i=>i.HideUI_SingleCommand());
//        Organize.ExecuteCommand<IMultiGroupMemberCommandTest>(1,i=>i.HideUI_MultiCommand());
    }

}
