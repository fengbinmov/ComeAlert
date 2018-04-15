using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour, IPointerDownHandler
{
    private bool isPress = false;

    private SelectItemPanel m_parentPanel = null;
    private GameObject cubeSoliderObject;
    private GameObject cubeBuild = null;
    private Vector3 currentScreenPoint;

    private LayerMask layerMask = 1 << 8;

    private ObjectDataValue objectDataValue = new ObjectDataValue();

    private Text selectName;
    private RawImage selectHeadP;

    public void SetSelectInfo(ObjectDataValue value) {

        Init();
        objectDataValue = value;
        cubeSoliderObject = Resources.Load(objectDataValue.m_data.self) as GameObject;
        selectName.text = objectDataValue.m_data.selfName;
        selectHeadP.texture = Resources.Load(objectDataValue.m_data.selfHeadP) as Texture;
    }
    private void Start() {
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
    }
    public void CancelSelfInvoke(bool isbulding)
    {
        Init();
        if (isbulding)
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
}
