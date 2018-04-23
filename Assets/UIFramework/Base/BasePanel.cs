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
    public virtual void ListPanelRemoveEvent(UIPanelType uIPanelType)
    {
    }
    public virtual UIPanelType GetUIPanelType() {
        return uIPanelType;
    }
    
}
