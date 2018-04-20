using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SoldierTypePanel : BasePanel
{
    private RectTransform mRectTransform;

    private Button DemosBuildBtn;
    private Button SoldierBuildBtn;
    private Button CarBuildBtn;
    private Button WaterBuildBtn;
    private Button AirBuildBtn;

    public SoldierTypePanel():base()
    {
        uIPanelType = UIPanelType.SoldierType;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        StartShowAnim();
        Init();

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
    private void StartShowAnim() {
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x + 100f, transform.position.y, transform.position.z);
        transform.DOMoveX(transform.position.x - 100f, 0.4f);
    }
    private void ShowAnim() {
        gameObject.SetActive(true);
        transform.DOMoveX(transform.position.x - 100f, 0.1f);
        //mRectTransform.DOLocalMove(new Vector3(0, 0), 0.1f);
    }
    private void HiteAnim()
    {
        transform.DOMoveX(transform.position.x + 100f, 0.2f).OnComplete(() => gameObject.SetActive(false));
        //mRectTransform.DOLocalMove(new Vector3(70f, 0), 0.2f).OnComplete(() => gameObject.SetActive(false));
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 25, 100, 30), "切换场景"))
        {
            //Debug.Log("切换场景");
            //Debug.Log("ObjectCount:["+GameOperation.gameOperation.GetObjectCount().ToString()+"]");
            //SceneManager.LoadScene(0);
        }
    }
    private void Init() {
        mRectTransform = transform.Find("SoldierType").GetComponent<RectTransform>();
        transform.Find("SoldierType/BuildVolume").GetComponent<Button>().onClick.AddListener(OnClickBuildVolume);

        DemosBuildBtn = transform.Find("SoldierType/DemosBuild").GetComponent<Button>();
        SoldierBuildBtn = transform.Find("SoldierType/SoldierBuild").GetComponent<Button>();
        CarBuildBtn = transform.Find("SoldierType/CarBuild").GetComponent<Button>();
        WaterBuildBtn = transform.Find("SoldierType/WaterBuild").GetComponent<Button>();
        AirBuildBtn = transform.Find("SoldierType/AirBuild").GetComponent<Button>();
    }
}
