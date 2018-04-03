using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SoldierTypePanel : BasePanel
{
    private RectTransform mRectTransform;
    public override void OnEnter()
    {
        base.OnEnter();
        mRectTransform = transform.Find("SoldierType").GetComponent<RectTransform>();
        transform.Find("SoldierType/BuildVolume").GetComponent<Button>().onClick.AddListener(OnClickBuildVolume);
    }

    public override void OnExit()
    {

    }

    public override void OnPause()
    {
        HiteAnim();
    }

    public override void OnResume()
    {
        ShowAnim();
    }
    private void OnClickBuildVolume() {
        GameControl.gameControl.PushPanel(UIPanelType.SelectItem);
    }
    private void ShowAnim() {
        gameObject.SetActive(true);
        mRectTransform.localPosition = new Vector3(60f, 0);
        mRectTransform.DOLocalMove(new Vector3(0, 0), 0.1f);
    }
    private void HiteAnim()
    {
        mRectTransform.DOLocalMove(new Vector3(70f, 0), 0.2f).OnComplete(() => gameObject.SetActive(false));
    }
}
