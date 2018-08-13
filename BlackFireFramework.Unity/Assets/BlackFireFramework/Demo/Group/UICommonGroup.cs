using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlackFireFramework;

public sealed class UICommonTestGroup : Organize.Group,IUICommonTest
{
    public void HideAllCommonUI()
    {
        Debug.Log("关闭了所有公共UI。");
    }
}

public interface IUICommonTest: BlackFireFramework.Event.IEventHandler
{
    void HideAllCommonUI();
}