using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfosPanel : BasePanel
{
    private Text nameIP;
    private Text outlayIP;
    private Text introduceIP;
    private UIDirftInfo uiDirftInfo;

    public ItemInfosPanel():base()
    {
        uIPanelType = UIPanelType.ItemInfos;
    }

    public override void OnEnter()
    {
        Init();
        Vector3 dirftP = uiDirftInfo.GetDirftInfo.panelPostion;
        transform.position = new Vector3(dirftP.x, dirftP.y + transform.GetComponent<RectTransform>().sizeDelta.y*0.8f, dirftP.z);
        nameIP.text = uiDirftInfo.GetDirftInfo.name;
        outlayIP.text = " 花费：" + uiDirftInfo.GetDirftInfo.outlay;
        introduceIP.text = " 介绍：" + uiDirftInfo.GetDirftInfo.introduce;
    }

    public override void OnExit()
    {
        Destroy(this.gameObject);
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
    private void Init() {

        nameIP = transform.Find("Context/Name").GetComponent<Text>();
        outlayIP = transform.Find("Context/Outlay").GetComponent<Text>();
        introduceIP = transform.Find("Context/Introduce").GetComponent<Text>();
        uiDirftInfo = GameOperation.gameOperation.GetInfoOperation.uIDirftInfo;
    }
}
