using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour{

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
            Destroy(this.gameObject);return;
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
    public GameObject InstantiateObj(GameObject obj,Vector3 postion,Quaternion quaternion) {
        return Instantiate(obj, postion, quaternion);
    }
    public void DestroyObj(Object obj)
    {
        Destroy(obj);
    }
    public void DestroyObj(Object obj,float time)
    {
        Destroy(obj,time);
    }
    public CommandControl SetNewCommand {
        get {
            return mCommandControl;
        }
    }
    public void PushPanel(UIPanelType uIPanelType) {
        mUIControl.PushPanel(uIPanelType);
    }
    public void PopPanel()
    {
        mUIControl.PopPanel();
    }

}
