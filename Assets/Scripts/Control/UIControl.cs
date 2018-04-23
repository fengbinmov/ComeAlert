using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIControl : BaseControl
{
    private const string RESOURCE_HEAD = "UIPanel/";
    private const string RESOURCE_TAIL = "Panel";
    private Dictionary<UIPanelType, string> panelPathDict;  //存储面板的路径
    private Dictionary<UIPanelType, BasePanel> panelDict;   //存储实例化面板游戏物体上的BasePanel组件
    private Stack<BasePanel> panelStack = null;                    //管理实例化的父子页面的状态
    private List<BasePanel> panelList = null;                      //管理实例化的页面的状态
    private Transform _canvasTransfrom;
    private UIPanelType _UIPanelType = UIPanelType.None;

    public UIControl(GameControl gameControl) : base(gameControl) { }

    public override void OnInit()
    {
        base.OnInit();
        ParseUIPanelTypeJson();
        PushPanel(UIPanelType.MainMenu);
    }
    public override void Updata()
    {
        if (_UIPanelType != UIPanelType.None) {
            PushPanel(_UIPanelType);
            _UIPanelType = UIPanelType.None;
        }
    }

    private Transform CanvasTransfrom
    {
        get {
            if (_canvasTransfrom == null)
            {
                _canvasTransfrom = GameObject.Find("Canvas").transform;
            }
            return _canvasTransfrom;
        }
    }

    #region 层次性UI--栈式结构
    public void PushPanel(UIPanelType panelType)        //页面入栈
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count > 0)                       //判断栈里面是否有页面,有则暂停
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);          //子页面响应并入栈
        //Debug.Log(panel.name + "入栈");
        panel.OnEnter();
        panelStack.Push(panel);

    }

    public void PopPanel(bool isRemove = true)        //页面弹出
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();
        if (panelStack.Count <= 0) return;

        BasePanel topPanel = panelStack.Pop();

        if(isRemove) panelDict.Remove(topPanel.GetUIPanelType());    //页面销毁后清除字典中的垃圾数据

        //Debug.Log(topPanel.name + "出栈");
        topPanel.OnExit();                              //调用栈顶页面退出事件

        
        if (panelStack.Count <= 0) return;                  //如果栈内还存在页面，则将其canvasblock改变 激活
        topPanel = panelStack.Peek();
        topPanel.OnResume();
        
    }
    #endregion

    #region 结构性UI--队列结构
    public void AddPanelList(UIPanelType panelType)        //页面入队
    {
        if (panelList == null)
            panelList = new List<BasePanel>();

        BasePanel panel = GetPanel(panelType);          //子页面响应并入队
        panel.OnEnter();
        panelList.Add(panel);
        //Debug.Log(panel.name + "入队");

    }
    public void RemovePanelList(UIPanelType uIPanelType)        //页面出队
    {
        if (panelList == null)
            panelList = new List<BasePanel>();
        if (panelList.Count <= 0) return;
        if (panelList.IndexOf(GetPanel(uIPanelType)) < 0) return;

        BasePanel removePanel = GetPanel(uIPanelType);

        //Debug.Log(removePanel.name + "出队");
        panelList.Remove(removePanel);                      //页面销毁后清除字典中的垃圾数据
        panelDict.Remove(removePanel.GetUIPanelType());

        removePanel.OnExit();                              //调用栈顶页面退出事件
        if (panelStack != null) {                          //对栈内面板响应对应的时间系统
            panelStack.Peek().ListPanelRemoveEvent(uIPanelType);
        }
        
    }
    #endregion

    // 查看栈顶面板类型
    public UIPanelType LookPanelStackTop() {
        return panelStack.Peek().GetUIPanelType();
    }
    // 查看堆顶面板类型
    public UIPanelType LookPanelListTop()
    {
        if (panelList == null || panelList.Count == 0)
            return UIPanelType.None;
        return panelList[panelList.Count-1].GetUIPanelType();
    }
    private BasePanel GetPanel(UIPanelType panelType)       //根据面板类型 得到实例化的面板
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        
        BasePanel panel = panelDict.TryGet(panelType);      //使用扩展方法
        if (panel == null)
        {
            //string path = RESOURCE_HEAD + panelType.ToString() + RESOURCE_TAIL;
            string path = panelPathDict.TryGet(panelType);
            //Debug.Log(path);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransfrom, false);
            if (!panelDict.TryGetValue(panelType, out panel))
            {
                panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            }
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }
    }
    public void AddPanelDict(UIPanelType panelType,GameObject instPanel) {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        BasePanel panel = panelDict.TryGet(panelType);      //使用扩展方法
        if (panel == null)
        {
            if (!panelDict.TryGetValue(panelType, out panel))
            {
                panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            }
        }
    }
    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList = new List<UIPanelInfo>();
    }

    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();
        TextAsset ta = Resources.Load<TextAsset>("Info/UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            panelPathDict.Add(info.panelType, info.path);
            //Debug.Log(info.panelType + " " + info.path);
        }
    }
    public void CleanAllDict() {

        if (panelList != null)
            panelList.Clear();
        if (panelStack != null)
            panelStack.Clear();
    }
}
