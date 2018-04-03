using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnPressBtn : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private bool isPress = false;

    private GameObject cubeBuildObject;
    private GameObject cubeBuild = null;
    private Vector3 currentScreenPoint;
    
    private LayerMask layerMask = 1 << 8;


    private void Start()
    {
        cubeBuildObject = Resources.Load("Prefabs/CubeBuild") as GameObject;
    }
    private void Update()
    {
        currentScreenPoint = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
        if (cubeBuild != null && cubeBuild.activeSelf == false) {

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
                cubeBuild = Instantiate(cubeBuildObject, hit.point, Quaternion.identity);
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
        if (isPress) {
            Ray ray = Camera.main.ScreenPointToRay(currentScreenPoint);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,500,layerMask))
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
}
