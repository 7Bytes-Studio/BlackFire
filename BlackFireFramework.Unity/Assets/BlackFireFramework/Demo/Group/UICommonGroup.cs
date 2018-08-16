using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework;
using BlackFireFramework.Unity;
using UnityEditor;

public sealed class UICommonTestGroup : Organize.Group,IGroupCommandTest
{
    
    public void HideAllUI()
    {
        Debug.Log("关闭了所有成员的UI。"+this.Id);
    }
    
    
    protected override bool HandleCommand<T>(Organize.CommandCallback<T> commandCallback)
    {
        
        if (typeof(ITestGroupCommand).IsAssignableFrom(typeof(T))) //组命令。
        {
            return base.HandleCommand<T>(commandCallback);
        }
        else if(typeof(ISingleGroupMemberCommandTest).IsAssignableFrom(typeof(T)))//成员命令。
        {
            var members = AcquirAllGroupMembers();
            foreach (var member in members)
            {
                if (member is T)
                {
                    commandCallback.Invoke((T)(object)member);
                    return true;
                }
            }        
        }
        else if(typeof(IMultiGroupMemberCommandTest).IsAssignableFrom(typeof(T)))//成员命令。
        {
            var members = AcquirAllGroupMembers();
            bool hasHandler = false;
            foreach (var member in members)
            {
                if (member is T)
                {
                    commandCallback.Invoke((T)(object)member);
                    hasHandler = true;
                }
            }
            return hasHandler;
        }
        return false;
    }
    
}

public sealed class UICommonTestGroupMember : Organize.GroupMember,ISingleGroupMemberCommandTest,IMultiGroupMemberCommandTest
{
    public UICommonTestGroupMember(long id) 
    {
        this.Id = id;
    }
    
    
    public void HideUI_SingleCommand()
    {
        Debug.Log("HideUI_SingleCommand 关闭了成员自身的UI。"+this.Id);
    }
    
    public void HideUI_MultiCommand()
    {
        Debug.Log("HideUI_MultiCommand 关闭了成员自身的UI。"+this.Id);
    }
}


public interface ITestSingleGroupMemberCommand : BlackFireFramework.Event.IEventHandler
{
    
}

public interface ITestMultiGroupMemberCommand : BlackFireFramework.Event.IEventHandler
{
    
}

public interface ITestGroupCommand : BlackFireFramework.Event.IEventHandler
{
    
}


public interface ISingleGroupMemberCommandTest: ITestSingleGroupMemberCommand
{
    void HideUI_SingleCommand();
}

public interface IMultiGroupMemberCommandTest: ITestMultiGroupMemberCommand
{
    void HideUI_MultiCommand();
}

public interface IGroupCommandTest: ITestGroupCommand
{
    void HideAllUI();
}