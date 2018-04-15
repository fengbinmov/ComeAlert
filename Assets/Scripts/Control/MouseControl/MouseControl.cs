using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseControl : BaseControl {

    public Vector3 screenPointStart;
    public Vector3 screenPointEnd;
    private Vector3 currentScreenPoint;
    private Vector3 currentScreenPointSith;

    //private Vector3 cameraRotateStartPoint;
    private Vector3 selectRectStartPoint;

    private GameObject mouseEffectObject;
    private GameObject selectRectObject;
    private GameObject selectRect;
    private BoxCollider selectRectRange;
    private MouseSelectCuboid selectCuboidScript;
    
    private LayerMask layerMask = 1<<8;

    private float cubeHeight = 0.05f;
    private bool getRecrtStartChart = true;
    private bool getRecrtStayChart = false;
    private bool isBuildSelectStart = false;
    private bool isBuildingSelect = false;

    private const float cameraHeight = 1.5f;
    private float cameraRatateDetail = 0.5f;
    private float cameraMoveDetail = 0.01f;
    private float cameraSenceDistanceRota = 0.1f;
    private float cameraSenceRotateXRota = 4f;
    private float cameraSenceDistanceRange = 0.5f;
    
    private SelectItem selectItem = null;
    private GameObject selectItemBuild = null;

    public MouseControl(GameControl gameControl) : base(gameControl){ }
    public override void OnInit()
    {
        base.OnInit();
        mouseEffectObject = Resources.Load("Prefabs/MouseEffect") as GameObject;
        selectRectObject = Resources.Load("Prefabs/MouseSelectRect") as GameObject;
    }
    public override void Updata()
    {
        base.Updata();
        currentScreenPoint = Input.mousePosition;

        SelectSoldierControl();
        SenceRotateCheck();
        SenceTranslation();
        SenceDistance();

        BuildingSelectItem();
        EventMouseLU();

        currentScreenPointSith = currentScreenPoint;
    }
    #region 右键点击的特效的显示

    private void MouseEffectShow(Vector3 mousePostion)
    {
        GameObject mouseEffect = GameObject.Instantiate(mouseEffectObject, mousePostion, Quaternion.identity);
        gameControl.DestroyObj(mouseEffect, 0.5f);
    }
    #endregion

    #region 场景视图 远近、旋转、平移

    //鼠标控制玩家视图的远近
    private void SenceDistance()
    {
        Vector3 scenceDistance = Camera.main.transform.position;
        Vector3 scenceRotate = Camera.main.transform.eulerAngles;
        float delta = -Input.mouseScrollDelta.y * cameraSenceDistanceRota;
        float rotateDelta = -Input.mouseScrollDelta.y * cameraSenceRotateXRota;
        if (scenceDistance.y < cameraHeight - cameraSenceDistanceRange && delta < 0)
        {
            return;
        }
        else if (scenceDistance.y > cameraHeight + cameraSenceDistanceRange && delta > 0)
        {
            return;
        }
        Camera.main.transform.position = new Vector3(scenceDistance.x, scenceDistance.y + delta, scenceDistance.z);
        Camera.main.transform.eulerAngles = new Vector3(scenceRotate.x + rotateDelta, scenceRotate.y, scenceRotate.z);
    }
    //鼠标控制玩家视图的旋转
    private void SenceRotateCheck()
    {

        if (Input.GetMouseButton(2))
        {
            Vector3 currentRotate = Camera.main.transform.eulerAngles;
            float camera_Y = currentScreenPointSith.x - currentScreenPoint.x;

            Camera.main.transform.eulerAngles = new Vector3(currentRotate.x, currentRotate.y - camera_Y * cameraRatateDetail, currentRotate.z);
        }
    }
    //键盘控制玩家视图的平移
    private void SenceTranslation()
    {
        
        Vector3 cameraPostion = Camera.main.transform.position;

        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        forward += cameraPostion;
        forward.y = 0;

        Vector3 down = Camera.main.transform.TransformDirection(Vector3.down);
        down += cameraPostion;
        down.y = 0;
        Vector3 dirt = forward - down;
        //dirt.y = cameraPostion.y;

        DebugCameraMove(cameraPostion, forward, down, dirt);

        Camera.main.transform.position = Vector3.MoveTowards(cameraPostion, cameraPostion + Input.GetAxis("Vertical") * dirt.normalized, Time.deltaTime);
        Camera.main.transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * cameraMoveDetail, Space.Self);

    }
    #endregion

    #region 选择框与选择体的生成，并激发士兵命令系统

    private void SelectSoldierControl()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameControl.gameControl.SetNewCommand.CleanSelectList();

            if (getRecrtStartChart)
            {
                getRecrtStartChart = false;
                screenPointEnd = Vector3.zero;  //为新命令的士兵初始化目标位置

                Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Plane" && !EventSystem.current.IsPointerOverGameObject())
                    {
                        getRecrtStayChart = true;       //开始计算选择区域
                        screenPointStart = hit.point;

                        selectRect =  gameControl.InstantiateObj(selectRectObject, Camera.main.WorldToViewportPoint(screenPointStart), Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0));
                        selectRectRange = selectRect.GetComponent<BoxCollider>();
                        selectCuboidScript = selectRect.GetComponent<MouseSelectCuboid>();
                        selectRect.transform.position = hit.point;

                        selectRectStartPoint = currentScreenPoint;
                    }

                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (getRecrtStayChart)
            {
                //Vector3 inputPost = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 500, layerMask))
                {
                    screenPointEnd = hit.point;

                    float rectW = currentScreenPoint.x - selectRectStartPoint.x;
                    float rectH = currentScreenPoint.y - selectRectStartPoint.y;

                    selectCuboidScript.SetSelectPaintRect(selectRectStartPoint.x, Screen.height - selectRectStartPoint.y, rectW, rectH);
                    selectCuboidScript.SetTwoPoint(screenPointStart, screenPointEnd);
                    //Debug.Log(hit.transform.tag);
                }
            }
        }
        Debug.DrawLine(screenPointStart, screenPointEnd, Color.green);
        if (Input.GetMouseButtonUp(0))
        {
            if (!getRecrtStartChart)
            {
                getRecrtStartChart = true;
                getRecrtStayChart = false;
                Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Plane" && !EventSystem.current.IsPointerOverGameObject())
                    {
                        screenPointEnd = hit.point;
                        if (selectRect != null)
                            selectCuboidScript.SetTwoPoint(screenPointStart, screenPointEnd);
                    }
                }
                if (selectRect != null)
                {
                    gameControl.DestroyObj(selectRect);
                    selectRect = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Plane" && !EventSystem.current.IsPointerOverGameObject())
                {
                    MouseEffectShow(hit.point);
                    GameControl.gameControl.SetNewCommand.SetTargetPostion(new Vector3(hit.point.x, hit.point.y + cubeHeight, hit.point.z));
                }
            }
        }
    }

    #endregion

    #region 生成选择的建筑对象

    public void InitBuildSelectItem(GameObject selectBuild,SelectItem selectItem)
    {
        this.selectItem = selectItem;
        this.selectItemBuild = selectBuild;
        this.isBuildSelectStart = true; 
    }
    private void BuildingSelectItem() {

        if (isBuildSelectStart) {

            Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, layerMask))
            {
                if (hit.collider.tag == "Plane" && !EventSystem.current.IsPointerOverGameObject())
                {
                    if (isBuildingSelect == false) {
                        selectItem.HideSelfAllSelectItem_FP();
                    }
                    isBuildingSelect = true;


                    if (selectItemBuild.activeSelf == false)
                        selectItemBuild.SetActive(true);
                    selectItemBuild.transform.position = hit.point;
                }
            }
        }
    }
    private void EventMouseLU() {
        if (Input.GetMouseButtonUp(0) && isBuildSelectStart)
        {
            selectItem.CancelSelfInvoke(isBuildingSelect);
            
            selectItem = null;
            selectItemBuild = null;
            isBuildSelectStart = false;
            isBuildingSelect = false;
        }
    }
    #endregion

    #region DebugShowLine
    private void DebugCameraMove(Vector3 cameraPostion, Vector3 forward, Vector3 down, Vector3 dirt)
    {
        Debug.DrawLine(cameraPostion, forward, Color.green);
        Debug.DrawLine(cameraPostion, down, Color.blue);
        Debug.DrawLine(forward, down, Color.red);
        Debug.DrawLine(cameraPostion, dirt, Color.yellow);
    }
    #endregion

}
