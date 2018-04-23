using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GameAttrType;

public class SelectItem : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    private bool isPress = false;
    private bool isInit = false;

    private SelectItemPanel m_parentPanel = null;
    private GameObject cubeSoliderObject;
    private GameObject cubeBuild = null;
    private Vector3 currentScreenPoint;

    private LayerMask layerMask = 1 << 8;

    private BaseMember mBaseMember = new BaseMember();
    //private ObjectDataValue objectDataValue = new ObjectDataValue();

    private Text selectName;
    private Text SelectNum;
    private RawImage selectHeadP;
    private Image selectHeadMAsk;
    private float maskProgress = 1;
    private int selectCount = 0;

    private UIDirftInfo uiDirftInfo;



    public void SetSelectInfo(BaseMember value)
    {

        Init();
        mBaseMember = value;
        cubeSoliderObject = Resources.Load(mBaseMember.selfDataValue.m_data.self) as GameObject;
        selectName.text = mBaseMember.selfDataValue.m_data.selfName;
        selectHeadP.texture = Resources.Load(mBaseMember.selfDataValue.m_data.selfHeadP) as Texture;
    }
    private void Update()
    {
        currentScreenPoint = Input.mousePosition;

        //控制对象选中后的图像剩余时间显示
        ItemPitchOnEvent();
        

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("OnPointerDown");
        Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (mBaseMember.selfDataValue.m_data.m_emObjectType == ENUM_OBJECT_TYPE.OBJECT_BUILD)
                {
                    cubeBuild = Instantiate(cubeSoliderObject);
                    cubeBuild.transform.position = hit.point;
                    cubeBuild.SetActive(false);
                    m_parentPanel.CurrentSelectObjectData = mBaseMember.selfDataValue;

                    //浮动面板运营处理
                    DirftOperation(transform.position);

                    GameControl.gameControl.InitBuildSelectItem(cubeBuild, this);
                }
                else
                {
                    DirftOperation(transform.position);
                    selectCount++;
                    SelectNum.text = selectCount.ToString();

                }
                
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
    }

    private void Init() {
        selectName = transform.GetComponentsInChildren<Text>()[0];
        SelectNum = transform.GetComponentsInChildren<Text>()[1];
        selectHeadP = transform.GetComponent<RawImage>();
        selectHeadMAsk = transform.GetComponentInChildren<Image>();
        m_parentPanel = transform.GetComponentInParent<SelectItemPanel>();
        uiDirftInfo = GameOperation.gameOperation.GetInfoOperation.uIDirftInfo;
        isInit = true;
    }
    public void CancelSelfInvoke(bool isbulding)
    {
        if (isInit == false)Init();

        if (isbulding == true)      //对象选择成功,让父面板显示之前隐藏的Bar中的所有项目,并更新“对象系统”
        {
            m_parentPanel.NotHideSelfAllSelectItem();
            GameOperation.gameOperation.AddMemInCountry(1, mBaseMember);

        }
        else{                      //对象选择失败,销毁数遍按下时生成的未激活对象模型
            Destroy(cubeBuild.gameObject);
        }
        //Debug.Log("OnUp");
    }
    public void HideSelfAllSelectItem_FP(){
        m_parentPanel.HideSelfAllSelectItem();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameOperation.gameOperation.GetInfoOperation.uIDirftInfo.CleanDirftPanelInfo();
        GameControl.gameControl.RemovePanel(UIPanelType.ItemInfos);
    }
    private void DirftOperation(Vector3 postion) {

        uiDirftInfo.SetDirftPanelInfo(postion, mBaseMember.selfDataValue.m_data.selfName, mBaseMember.selfDataValue.m_data.selfOutlay, mBaseMember.selfDataValue.m_data.selfIntroduce);

        GameControl.gameControl.AddPanel(UIPanelType.ItemInfos);
    }
    private void ItemPitchOnEvent() {
        if (selectCount > 0)
        {
            maskProgress -= Time.deltaTime;
            selectHeadMAsk.fillAmount = maskProgress;
            if (maskProgress <= 0)
            {
                selectCount--;
                SelectNum.text = selectCount.ToString();
                if (selectCount == 0)
                    SelectNum.text = "";
                maskProgress = 1;
                GameOperation.gameOperation.AddMemInCountry(1, mBaseMember);//TODO
            }
        }
    }
}
