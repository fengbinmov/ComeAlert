using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectItemPanel : BasePanel{

    private GameObject cubeSoldier;
    private GameObject instansCubeBuild;

    private RectTransform mRectTransform;
    
    public override void OnEnter()
    {
        base.OnEnter();
        mRectTransform = GetComponent<RectTransform>();
        transform.Find("SelectItem/CloseButton").GetComponent<Button>().onClick.AddListener(OnClickCloseButton);

        ShowAnim();
    }
    public override void OnPause()
    {
    }
    public override void OnResume()
    {
    }

    public override void OnExit()
    {
        Destroy(this.gameObject);
    }

    private void ShowAnim()
    {
        gameObject.SetActive(true);
        mRectTransform.localPosition = new Vector3(0, -100f,0);
        transform.DOMoveY(mRectTransform.position.y + 100f, 0.5f);
    }
    public void OnClickCloseButton()
    {
        mRectTransform.DOLocalMoveY(-100f, 0.1f).OnComplete(() => GameControl.gameControl.PopPanel());
    }
}
