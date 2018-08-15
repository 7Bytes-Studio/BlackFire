using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework;
using BlackFireFramework.Unity;
using UnityEditor;

public sealed class UICommonTestGroup : UIGroup
{
    


    
    protected override bool HandleCommand<T>(Organize.CommandCallback<T> commandCallback)
    {
        var members = GetUIGroupMembers();
        foreach (var member in members)
        {
            if (member.Window.Logic is T)
            {
                commandCallback.Invoke((T)member.Window.Logic);
                return true;
            }
        }
        return false;
    }
    
}

public sealed class UICommonTestGroupMember : UIGroupMember,IUICommonTest
{
    public UICommonTestGroupMember(long id) : base(null)
    {
        this.Id = id;
    }
    
    public void HideAllCommonUI()
    {
        Debug.Log("关闭了公共UI。"+GetHashCode());
    }
}



public interface IUICommonTest: BlackFireFramework.Event.IEventHandler
{
    void HideAllCommonUI();
}