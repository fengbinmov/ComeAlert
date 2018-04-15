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

    public override void OnEnter()
    {
        Init();

        transform.position = new Vector3(uiDirftInfo.PanelPostion.x, uiDirftInfo.PanelPostion.y + transform.GetComponent<RectTransform>().sizeDelta.y*0.8f, uiDirftInfo.PanelPostion.z);
        nameIP.text = uiDirftInfo.Name;
        outlayIP.text = " 花费：" + uiDirftInfo.Outlay;
        introduceIP.text = " 介绍：" + uiDirftInfo.Introduce;
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
    private void InitSelectInfoPanel(string name,string outlay,string duce)
    {
        nameIP.text = name;
        outlayIP.text = outlay;
        introduceIP.text = duce;
    }
    private void Init() {

        nameIP = transform.Find("Context/Name").GetComponent<Text>();
        outlayIP = transform.Find("Context/Outlay").GetComponent<Text>();
        introduceIP = transform.Find("Context/Introduce").GetComponent<Text>();
        uiDirftInfo = GameOperation.gameOperation.GetInfoOPeration.uIDirftInfo;
    }
}
