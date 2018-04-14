using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool isPress = false;
    private bool isBuild = false;

    private Transform m_parentPanel = null;
    private GameObject cubeSoliderObject;
    private GameObject cubeBuild = null;
    private Vector3 currentScreenPoint;

    private LayerMask layerMask = 1 << 8;

    private ObjectDataValue objectDataValue = new ObjectDataValue();

    private Text selectName;
    private RawImage selectHeadP;

    public void SetSelectInfo(ObjectDataValue value){

        Init();
        //Debug.Log("ObjectDataValue[" + value.m_data.m_u8ID+"]");
        objectDataValue = value;
        cubeSoliderObject = Resources.Load(objectDataValue.m_data.self) as GameObject;
        selectName.text = objectDataValue.m_data.selfName;
        selectHeadP.texture = Resources.Load(objectDataValue.m_data.selfHeadP) as Texture;
    }
    private void Start(){
        m_parentPanel = transform.GetComponentInParent<Transform>();
    }
    private void Update()
    {
        currentScreenPoint = Input.mousePosition;
        if (Input.GetMouseButtonUp(0)) {
            if (isBuild)
            {
                Debug.Log("OnPointerUp");
                isPress = false;
                if (cubeBuild != null && cubeBuild.activeSelf == false)
                {

                    Destroy(cubeBuild.gameObject);
                    cubeBuild = null;
                }
                isBuild = false;
                CancelInvoke("OnPress");
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        isPress = true;
        Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                cubeBuild = Instantiate(cubeSoliderObject, hit.point, Quaternion.identity);
                cubeBuild.SetActive(false);
            }
        }

        InvokeRepeating("OnPress", 0, 0.1f);
    }
    private void OnPress()
    {
        Debug.Log("OnPress");
        MyFunction();
    }
    public void MyFunction()
    {
        if (isPress)
        {
            Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, layerMask))
            {
                if (hit.collider.tag == "Plane" && !EventSystem.current.IsPointerOverGameObject())
                {
                    isBuild = true;
                    if (isBuild)
                    {
                        Debug.Log("Cube...");
                        if (cubeBuild.activeSelf == false)
                            cubeBuild.SetActive(true);
                        cubeBuild.transform.position = hit.point;
                    }
                }

            }
        }
    }
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
    private void Init() {
        selectName = transform.GetComponentInChildren<Text>();
        selectHeadP = transform.GetComponent<RawImage>();
    }
}
