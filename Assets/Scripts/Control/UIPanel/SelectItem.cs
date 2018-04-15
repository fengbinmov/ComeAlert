using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    private bool isPress = false;
    private bool isInit = false;

    private SelectItemPanel m_parentPanel = null;
    private GameObject cubeSoliderObject;
    private GameObject cubeBuild = null;
    private Vector3 currentScreenPoint;

    private LayerMask layerMask = 1 << 8;

    private ObjectDataValue objectDataValue = new ObjectDataValue();

    private Text selectName;
    private RawImage selectHeadP;

    private UIDirftInfo uiDirftInfo;

    public void SetSelectInfo(ObjectDataValue value) {

        Init();
        objectDataValue = value;
        cubeSoliderObject = Resources.Load(objectDataValue.m_data.self) as GameObject;
        selectName.text = objectDataValue.m_data.selfName;
        selectHeadP.texture = Resources.Load(objectDataValue.m_data.selfHeadP) as Texture;
    }
    private void Update()
    {
        currentScreenPoint = Input.mousePosition;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                cubeBuild = Instantiate(cubeSoliderObject, hit.point, Quaternion.identity);
                cubeBuild.SetActive(false);
                m_parentPanel.CurrentSelectObjectData = objectDataValue;

                //浮动面板运营处理
                DirftOPeration(transform.position);

                GameControl.gameControl.InitBuildSelectItem(cubeBuild, this);
            }
        }
    }
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
    public void HideSelf() {
        this.gameObject.SetActive(false);
    }
    public void NotHideSelf()
    {
        this.gameObject.SetActive(true);
        Debug.Log("showSelf");
    }

    private void Init() {
        selectName = transform.GetComponentInChildren<Text>();
        selectHeadP = transform.GetComponent<RawImage>();
        m_parentPanel = transform.GetComponentInParent<SelectItemPanel>();
        uiDirftInfo = GameOperation.gameOperation.GetInfoOPeration.uIDirftInfo;
        isInit = true;
    }
    public void CancelSelfInvoke(bool isbulding)
    {
        if (isInit == false)Init();

        if (isbulding == true)
        {
            m_parentPanel.NotHideSelfAllSelectItem();
        }
        else {
            Destroy(cubeBuild.gameObject);
        }
        Debug.Log("OnUp");
    }
    public void HideSelfAllSelectItem_FP(){
        m_parentPanel.HideSelfAllSelectItem();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameOperation.gameOperation.GetInfoOPeration.uIDirftInfo.CleanDirftPanelInfo();
        GameControl.gameControl.PopPanel();
    }
    private void DirftOPeration(Vector3 postion) {

        uiDirftInfo.SetDirftPanelInfo(postion, objectDataValue.m_data.selfName, objectDataValue.m_data.selfOutlay, objectDataValue.m_data.selfIntroduce);
        GameControl.gameControl.PushPanel(UIPanelType.ItemInfos);
    }
}
