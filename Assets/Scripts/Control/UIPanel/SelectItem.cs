using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using GameAttrType;
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
    private float maskProgressMax = 0;
    private float maskProgressNow = 0;
    private int selectCount = 0;

    private UIDirftInfo uiDirftInfo;



    public void SetSelectInfo(BaseMember value)
    {

        Init();
        mBaseMember = value;
        maskProgressMax = mBaseMember.selfDataValue.m_atrr.m_u2MakeTime;
        maskProgressNow = maskProgressMax;
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
    //项目选择结束后的操作
    public void CancelSelfInvoke(bool isbulding)
    {
        if (isInit == false)Init();

        if (isbulding == true)      //对象选择成功,让父面板显示之前隐藏的Bar中的所有项目,并更新“对象系统”
        {
            m_parentPanel.NotHideSelfAllSelectItem();

            BaseMember baseMember = GetCurrObjectScript(mBaseMember.selfDataValue.m_data.m_emObjectName);
            GameOperation.gameOperation.AddMemInCountry(1, baseMember);
            cubeBuild.AddComponent<BuildOnClick>().SetMemeber = baseMember;
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
            maskProgressNow -= Time.deltaTime;
            selectHeadMAsk.fillAmount = maskProgressNow/maskProgressMax;
            if (maskProgressNow <= 0)
            {
                selectCount--;
                SelectNum.text = selectCount.ToString();
                if (selectCount == 0)
                    SelectNum.text = "";
                maskProgressNow = maskProgressMax;
                GameOperation.gameOperation.AddMemInCountry(1, mBaseMember);//TODO
            }
        }
    }
    private BaseMember GetCurrObjectScript(ENUM_OBJECT_NAME oBJECT_NAME) {
        switch (oBJECT_NAME)
        {
            case ENUM_OBJECT_NAME.Z_NENGSHI:
                break;
            case ENUM_OBJECT_NAME.Z_JINSHU:
                break;
            case ENUM_OBJECT_NAME.Z_ZHINENG:
                break;
            case ENUM_OBJECT_NAME.Z_XINENG:
                break;
            case ENUM_OBJECT_NAME.F_BUBING:
                return cubeBuild.AddComponent<SoldierMem1100>();

            case ENUM_OBJECT_NAME.F_TEZHONG:
                return cubeBuild.AddComponent<SoldierMem1101>();

            case ENUM_OBJECT_NAME.F_FANGKONG:
                break;
            case ENUM_OBJECT_NAME.F_NATASHA:
                break;
            case ENUM_OBJECT_NAME.F_GONGCHENG:
                break;
            case ENUM_OBJECT_NAME.F_YILIAO:
                break;
            case ENUM_OBJECT_NAME.F_GOU:
                break;
            case ENUM_OBJECT_NAME.F_FANJIA:
                break;
            case ENUM_OBJECT_NAME.F_CIBAO:
                break;
            case ENUM_OBJECT_NAME.C_ZHENCHA:
                break;
            case ENUM_OBJECT_NAME.C_ZHUANGJIA:
                break;
            case ENUM_OBJECT_NAME.C_TANKE:
                break;
            case ENUM_OBJECT_NAME.C_TIANQI:
                break;
            case ENUM_OBJECT_NAME.C_FANGKONG:
                break;
            case ENUM_OBJECT_NAME.C_HUOJIAN:
                break;
            case ENUM_OBJECT_NAME.C_JIHUANG:
                break;
            case ENUM_OBJECT_NAME.C_HEDAN:
                break;
            case ENUM_OBJECT_NAME.A_ZHENCHA:
                break;
            case ENUM_OBJECT_NAME.A_ZHISHENG:
                break;
            case ENUM_OBJECT_NAME.A_ZHANDOU:
                break;
            case ENUM_OBJECT_NAME.A_YUNSHU:
                break;
            case ENUM_OBJECT_NAME.A_YUJING:
                break;
            case ENUM_OBJECT_NAME.W_KUAITING:
                break;
            case ENUM_OBJECT_NAME.W_ZAIJU:
                break;
            case ENUM_OBJECT_NAME.W_YUNSHU:
                break;
            case ENUM_OBJECT_NAME.W_ZHANJIAN:
                break;
            case ENUM_OBJECT_NAME.W_HANGMU:
                break;
            case ENUM_OBJECT_NAME.W_QIANTING:
                break;
            case ENUM_OBJECT_NAME.B_DEMOS:
                return cubeBuild.AddComponent<Build1500>();

            case ENUM_OBJECT_NAME.B_POWER:
                break;
            case ENUM_OBJECT_NAME.B_SOLDIER:
                return cubeBuild.AddComponent<Build1502>();

            case ENUM_OBJECT_NAME.B_ZHANZHENG:
                return cubeBuild.AddComponent<Build1503>();
            case ENUM_OBJECT_NAME.B_WATER:
                return cubeBuild.AddComponent<Build1504>();

            case ENUM_OBJECT_NAME.B_AIR:
                return cubeBuild.AddComponent<Build1505>();

            case ENUM_OBJECT_NAME.B_ZHIHUI:
                break;
            case ENUM_OBJECT_NAME.B_SCHOOL:
                break;
            case ENUM_OBJECT_NAME.B_KEXUE:
                break;
            case ENUM_OBJECT_NAME.B_ZHENFU:
                break;
            case ENUM_OBJECT_NAME.B_JINGWEI:
                break;
            case ENUM_OBJECT_NAME.B_MAOYI:
                break;
            case ENUM_OBJECT_NAME.B_YULE:
                break;
            case ENUM_OBJECT_NAME.B_TEZHONG:
                break;
            case ENUM_OBJECT_NAME.B_WEIQIANG:
                break;
            case ENUM_OBJECT_NAME.B_SHAOJIE:
                break;
            case ENUM_OBJECT_NAME.B_DIAOBAO:
                break;
            case ENUM_OBJECT_NAME.B_DIAOBAOG:
                break;
            case ENUM_OBJECT_NAME.B_TIBA:
                break;
            default:
                return null;
        }
        return null;
    }
}
