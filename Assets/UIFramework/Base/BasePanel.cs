using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour {

    protected UIPanelType uIPanelType;
    
    public virtual void OnEnter() {
    }
    public virtual void OnPause()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public virtual void OnResume()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public virtual void OnExit()
    {
    }
    //当“队列面板”退出后会在“栈顶面板”响应退事件
    public virtual void ListPanelRemoveEvent(UIPanelType uIPanelType)
    {
    }
    public virtual void GetBroadInfo<T>(ENUM_MSG_TYPE mSG_TYPE, T info) {

    }
    public virtual UIPanelType GetUIPanelType() {
        return uIPanelType;
    }
    
}
