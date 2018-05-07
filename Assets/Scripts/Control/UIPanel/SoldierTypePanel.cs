using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using GameAttrType;
using UnityEngine.SceneManagement;

public class SoldierTypePanel : BasePanel
{
    private bool pause = false;
    private GameObject selectItemPanel;
    private GameObject volumePanel;
    private bool volumePanelActive = false;

    private List<Button> BuildBtnList = new List<Button>();
    private Button DemosBuildBtn;
    private Button SoldierBuildBtn;
    private Button CarBuildBtn;
    private Button WaterBuildBtn;
    private Button AirBuildBtn;
    private GameObject VolumeBtnObject;

    private List<Text> BuildTextList = new List<Text>();
    private Text DemosHasNum;
    private Text SoldierHasNum;
    private Text CarHasNum;
    private Text WaterHasNum;
    private Text AirHasNum;

    //Demos、Soldier、Car、Water、Air   建筑数量
    private int[] activeBuildLabCount = { 0, 0, 0, 0, 0 };
    private int[] activeArrNow = { 0, 0, 0, 0, 0 };
    private BuildMem activebuildMem = null;

    public SoldierTypePanel() : base()
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
        volumePanelActive = false;
        volumePanel.SetActive(volumePanelActive);
        HiteAnim();
    }

    public override void OnResume()
    {
        ShowAnim();
    }
    public override void ListPanelRemoveEvent(UIPanelType uIPanelType)
    {
        if (uIPanelType == UIPanelType.SelectItem) {
            VolumeBtnObject.SetActive(true);
        }
    }
    public override void GetBroadInfo<T>(ENUM_MSG_TYPE mSG_TYPE, T info)
    {
        switch (mSG_TYPE)
        {
            case ENUM_MSG_TYPE.OBJECT:
                    MakeMessageOBJ(info);
                break;
            case ENUM_MSG_TYPE.CONTAINER:
                break;
            case ENUM_MSG_TYPE.STRING:
                break;
            case ENUM_MSG_TYPE.ARRAY:
                    InitBuildNum(info);
                break;
            case ENUM_MSG_TYPE.NUMBER:
                break;
            case ENUM_MSG_TYPE.STRUCT:
                break;
            default:
                break;
        }
    }
    private void MakeMessageOBJ<T>(T info) {

        activebuildMem = info as BuildMem;

        switch (activebuildMem.selfDataValue.m_data.m_u2ID)
        {
            case 1500:
                OnClickBuildDemos();
                break;
            case 1502:
                OnClickBuildSoldier();
                break;
            case 1503:
                OnClickBuildCar();
                break;
            case 1504:
                OnClickBuildWater();
                break;
            case 1505:
                OnClickBuildAir();
                break;
            default:
                return;
        }
    }
    #region 主选项按键事件
    private void OnClickBuildVolume()
    {
        if (GameControl.gameControl.LookPanelListTop() == UIPanelType.SelectItem)
        {
            GameControl.gameControl.RemovePanel(UIPanelType.SelectItem);
        }
        volumePanelActive = !volumePanelActive;
        volumePanel.SetActive(volumePanelActive);

    }
    private void OnClickBuildDemos()
    {
        VolumeBtnObject.SetActive(true);
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.DEMOS);
        OnClickOpenBar();
        GetCanMakeForSelectSend();
    }
    private void OnClickBuildSoldier()
    {
        VolumeBtnObject.SetActive(true);
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.SOLDIER);
        OnClickOpenBar();
        GetCanMakeForSelectSend();
    }
    private void OnClickBuildCar()
    {
        VolumeBtnObject.SetActive(true);
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.CAR);
        OnClickOpenBar();
        GetCanMakeForSelectSend();
    }
    private void OnClickBuildWater()
    {
        VolumeBtnObject.SetActive(true);
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.WATER);
        OnClickOpenBar();
        GetCanMakeForSelectSend();
    }
    private void OnClickBuildAir()
    {
        VolumeBtnObject.SetActive(true);
        UpdateBuildNumLab(ENUM_BUILDLAB_TYPE.AIR);
        OnClickOpenBar();
        GetCanMakeForSelectSend();
    }
    private void OnClickOpenBar()
    {
        volumePanel.SetActive(false);
        if (GameControl.gameControl.LookPanelListTop() == UIPanelType.SelectItem)
        {
            GameControl.gameControl.RemovePanel(UIPanelType.SelectItem);
        }
        GameControl.gameControl.AddPanel(UIPanelType.SelectItem);
        
    }
    private void GetCanMakeForSelectSend() {

        ENUM_BUILDLAB_TYPE bUILDLAB_TYPE = GameOperation.gameOperation.GetActiveBuildType(1);
        List<BaseMember> canMakeList = GameOperation.gameOperation.GetCanMakeObjectList(1, bUILDLAB_TYPE);
        GameControl.gameControl.SendBroadInfoForUI(UIPanelType.SelectItem, ENUM_MSG_TYPE.CONTAINER, canMakeList);
    }
    #endregion

    #region Volume按键事件

    public void OnClickBuildSystem() {
        VolumeBtnObject.SetActive(false);
        OnClickOpenBar();

        List<BaseMember> objectItems = new List<BaseMember>();
        objectItems.Add(new Build1500());
        objectItems.Add(new Build1502());
        objectItems.Add(new Build1503());
        objectItems.Add(new Build1504());
        objectItems.Add(new Build1505());
        GameControl.gameControl.SendBroadInfoForUI(UIPanelType.SelectItem, ENUM_MSG_TYPE.STRING, "HitBuildLab");
        GameControl.gameControl.SendBroadInfoForUI(UIPanelType.SelectItem, ENUM_MSG_TYPE.CONTAINER, objectItems);
    }
    #endregion

    #region 动画事件
    private void StartShowAnim()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x + 100f, transform.position.y, transform.position.z);
        transform.DOMoveX(transform.position.x - 100f, 0.4f);
    }
    private void ShowAnim()
    {
        gameObject.SetActive(true);
        transform.DOMoveX(transform.position.x - 100f, 0.1f);
    }
    private void HiteAnim()
    {
        transform.DOMoveX(transform.position.x + 100f, 0.2f).OnComplete(() => gameObject.SetActive(false));
    }
    #endregion

    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 55, 100, 30), "切换场景"))
        {
            pause = !pause;
            if (pause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    private void Init() {

        volumePanel = transform.Find("VolumePanel").gameObject;

        VolumeBtnObject = transform.Find("SoldierType/BuildVolume").gameObject;
        VolumeBtnObject.GetComponent<Button>().onClick.AddListener(OnClickBuildVolume);

        DemosBuildBtn = transform.Find("SoldierType/DemosBuild").GetComponent<Button>();
        DemosHasNum = transform.Find("SoldierType/DemosBuild/BuildNum").GetComponent<Text>();
        DemosBuildBtn.onClick.AddListener(OnClickBuildDemos);
        BuildTextList.Add(DemosHasNum);
        BuildBtnList.Add(DemosBuildBtn);

        SoldierBuildBtn = transform.Find("SoldierType/SoldierBuild").GetComponent<Button>();
        SoldierHasNum = transform.Find("SoldierType/SoldierBuild/BuildNum").GetComponent<Text>();
        SoldierBuildBtn.onClick.AddListener(OnClickBuildSoldier);
        BuildTextList.Add(SoldierHasNum);
        BuildBtnList.Add(SoldierBuildBtn);

        CarBuildBtn = transform.Find("SoldierType/CarBuild").GetComponent<Button>();
        CarHasNum = transform.Find("SoldierType/CarBuild/BuildNum").GetComponent<Text>();
        CarBuildBtn.onClick.AddListener(OnClickBuildCar);
        BuildTextList.Add(CarHasNum);
        BuildBtnList.Add(CarBuildBtn);

        WaterBuildBtn = transform.Find("SoldierType/WaterBuild").GetComponent<Button>();
        WaterHasNum = transform.Find("SoldierType/WaterBuild/BuildNum").GetComponent<Text>();
        WaterBuildBtn.onClick.AddListener(OnClickBuildWater);
        BuildTextList.Add(WaterHasNum);
        BuildBtnList.Add(WaterBuildBtn);

        AirBuildBtn = transform.Find("SoldierType/AirBuild").GetComponent<Button>();
        AirHasNum = transform.Find("SoldierType/AirBuild/BuildNum").GetComponent<Text>();
        AirBuildBtn.onClick.AddListener(OnClickBuildAir);
        BuildTextList.Add(AirHasNum);
        BuildBtnList.Add(AirBuildBtn);
    }
    private void InitBuildNum<T>(T info) {
        
        activeBuildLabCount = info as int[];

        for (int i = 0; i < 5; i++) {
            if (activeBuildLabCount[i] > 0)
            {
                BuildTextList[i].text = activeBuildLabCount[i].ToString();
                BuildBtnList[i].interactable = true;
            }
            else {
                BuildTextList[i].text = " ";
                BuildBtnList[i].interactable = false;
            }
        }
    }
    //更改建筑系统的 激活建筑
    private void UpdateBuildNumLab(ENUM_BUILDLAB_TYPE buildLab) {

        if (activebuildMem == null){    //点击buildLab得到的响应
            int order = (int)buildLab - 1500;
            if (activeBuildLabCount[order] > 0)
            {
                int activeBuildLabNum = GameOperation.gameOperation.GetActiveBuildLabCode(1);
                if (activeBuildLabNum == 999){

                    activeArrNow[order] = 0;
                    activeArrNow[order] = (activeArrNow[order] % activeBuildLabCount[order]);
                    GameOperation.gameOperation.SetActiveBuild(1, buildLab, activeArrNow[order]);
                }
                else {
                    activeArrNow[order] = activeBuildLabNum+1;
                    activeArrNow[order] = (activeArrNow[order] % activeBuildLabCount[order]);
                    GameOperation.gameOperation.SetActiveBuild(1, buildLab, activeArrNow[order]);
                }
            }
        }
        else {  //直接点击建筑而得到的响应
            
            int code = GameOperation.gameOperation.GetBuildLabCode(1, activebuildMem);
            GameOperation.gameOperation.SetActiveBuild(1, buildLab, code);
            activebuildMem = null;
        }
        
    }
}
