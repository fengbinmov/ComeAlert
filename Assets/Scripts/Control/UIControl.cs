using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIControl :BaseControl
{
    private const string RESOURCE_HEAD = "UIPanel/";
    private const string RESOURCE_TAIL = "Panel";
    private Dictionary<UIPanelType, BasePanel> panelDict;   //存储实例化面板游戏物体上的BasePanel组件
    private Stack<BasePanel> panelStack;                    //管理实例化的父子页面的状态
    private Transform _canvasTransfrom;
    private UIPanelType _UIPanelType = UIPanelType.None;

    public UIControl(GameControl gameControl) : base(gameControl)
    {
    }
    public override void OnInit()
    {
        base.OnInit();
        PushPanel(UIPanelType.SoldierType);
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
        panel.OnEnter();
        panelStack.Push(panel);

    }

    public void PopPanel()        //页面弹出
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();
        if (panelStack.Count <= 0) return;

        BasePanel topPanel = panelStack.Pop();

        panelDict.Remove(topPanel.GetUIPanelType());    //页面销毁后清除字典中的垃圾数据

        topPanel.OnExit();                              //调用栈顶页面退出事件

        
        if (panelStack.Count <= 0) return;                  //如果栈内还存在页面，则将其canvasblock改变 激活
        topPanel = panelStack.Peek();
        topPanel.OnResume();
        
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
            string path = RESOURCE_HEAD + panelType.ToString() + RESOURCE_TAIL;
            Debug.Log(path);
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
}
