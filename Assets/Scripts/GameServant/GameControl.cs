using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    #region  SingletonPattern
    private static GameControl _instance;
    public static GameControl gameControl
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameControl();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance != null) {
            Destroy(this.gameObject); return;
        }
        _instance = this;
    }
    #endregion

    private UIControl mUIControl;
    private MouseControl mMouseControl;
    private CommandControl mCommandControl;

    private void Start()
    {
        InitControl();
    }
    private void Update()
    {
        mUIControl.Updata();
        mMouseControl.Updata();
        mCommandControl.Updata();
    }
    private void InitControl()
    {
        mUIControl = new UIControl(this);
        mMouseControl = new MouseControl(this);
        mCommandControl = new CommandControl(this);

        mUIControl.OnInit();
        mMouseControl.OnInit();
        mCommandControl.OnInit();
    }


    #region 公共方法集
    public GameObject InstantiateObj(GameObject obj, Vector3 postion, Quaternion quaternion)
    {
        return Instantiate(obj, postion, quaternion);
    }
    public void DestroyObj(Object obj)
    {
        Destroy(obj);
    }
    public void DestroyObj(Object obj, float time)
    {
        Destroy(obj, time);
    }
    #endregion

    #region Mouse方法集
    public void InitBuildSelectItem(GameObject game, SelectItem selectItem) {

        mMouseControl.InitBuildSelectItem(game, selectItem);
    }
    public bool ControlViewInstance {
        get {
            return mMouseControl.ControlViewInstance;
        }
        set {
            mMouseControl.ControlViewInstance = value;
        }
    }
    #endregion

    #region Command方法集

    //检测自身的transform是否在命令系统中
    public int GetIndexOfCommand(Transform transform){

        return  mCommandControl.GetSelectListCube().IndexOf(transform);
    }
    //得到将要移动的目标位置
    public Vector3 GetTargetPostion(Transform transform) {

        return mCommandControl.GetTargetPostion(transform);
    }
    //设置将要移动的目标位置
    public void SetTargetPostion(Vector3 vector3) {
        mCommandControl.SetTargetPostion(vector3);
    }
    //得到命令队伍中的中心士兵的位置
    public Vector3 GetCenterCubePos() {

        return mCommandControl.GetCenterCubePos;
    }
    //添加士兵到控制系统中
    public void AddObjectToComm(Transform transform,int rangeNum) {

        mCommandControl.AddCube(transform, rangeNum);
    }
    //从控制系统移除士兵
    public void RemoveObjectFromComm(Transform transform)
    {
        mCommandControl.RemoveCube(transform);
    }
    //从控制系统移除所有
    public void CleanSelectList() {
        mCommandControl.CleanSelectList();
    }
    public void AddSelectCube(List<Transform> transformList) {
        mCommandControl.AddSelectCube(transformList);
    }
    public void AddSelectCube(Transform transform)
    {
        mCommandControl.AddSelectCube(transform);
    }
    #endregion

    #region UI方法集

    public void PushPanel(UIPanelType uIPanelType)
    {
        mUIControl.PushPanel(uIPanelType);
    }
    public void PopPanel(bool isRemove = true)
    {
        mUIControl.PopPanel(isRemove);
    }
    public void AddPanel(UIPanelType uIPanelType)
    {
        mUIControl.AddPanelList(uIPanelType);
    }
    public void RemovePanel(UIPanelType uIPanelType)
    {
        mUIControl.RemovePanelList(uIPanelType);
    }
    public void AddPanelDict(UIPanelType panelType, GameObject instPanel) {

        mUIControl.AddPanelDict(panelType,instPanel);
    }
    public void CleanAllDict() {
        mUIControl.CleanAllDict();
    }
    public UIPanelType LookPanelStackTop()
    {
        return mUIControl.LookPanelStackTop();
    }
    public UIPanelType LookPanelListTop()
    {
        return mUIControl.LookPanelListTop();
    }
    public void SendBroadInfoForUI<T>(UIPanelType uIPanelType, ENUM_MSG_TYPE mSG_TYPE, T info) {
        mUIControl.SendBroadInfoForOne(uIPanelType, mSG_TYPE, info);
    }
    #endregion

}
