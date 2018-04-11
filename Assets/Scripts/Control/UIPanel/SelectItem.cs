using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool isPress = false;

    private GameObject cubeSoliderObject;
    private GameObject cubeBuild = null;
    private Vector3 currentScreenPoint;

    private LayerMask layerMask = 1 << 8;

    private ObjectDataValue objectDataValue = new ObjectDataValue();

    private Text selectName;
    private Image selectHeadP;

    public void SetSelectInfo(ObjectDataValue value){

            Debug.Log(value.m_data.m_u8ID);
            objectDataValue = value;
            cubeSoliderObject = Resources.Load(objectDataValue.m_data.self) as GameObject;
            //selectName.text = objectDataValue.m_data.selfName;
            //selectHeadP = Resources.Load(objectDataValue.m_data.selfHeadP, typeof(Image)) as Image;
        
    }
    private void Start(){

        selectName = transform.GetComponentInChildren<Text>();
        selectHeadP = transform.GetComponent<Image>();
        Debug.Log(selectName.name+"1");
    }
    private void Update()
    {
        currentScreenPoint = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
        if (cubeBuild != null && cubeBuild.activeSelf == false)
        {

            Destroy(cubeBuild.gameObject);
            cubeBuild = null;
        }
        CancelInvoke("OnPress");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
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
                    if (cubeBuild.activeSelf == false)
                        cubeBuild.SetActive(true);
                    cubeBuild.transform.position = hit.point;
                }

            }
        }
    }
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
