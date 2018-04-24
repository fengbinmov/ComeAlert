﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SelectItemPanel : BasePanel{

    private GameObject selectItemsPanel;

    private RectTransform mRectTransform;
    private HorizontalLayoutGroup selectListLayout;

    private SelectItem[] currentSelectItems;
    private GameObject currentSelectItemInfo;
    private ObjectDataValue currentSelectObjectData;

    public SelectItemPanel():base()
    {
        uIPanelType = UIPanelType.SelectItem;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        mRectTransform = GetComponent<RectTransform>();
        selectItemsPanel = Resources.Load("UIPanel/ItemPanel") as GameObject;
        transform.Find("SelectItem/CloseButton").GetComponent<Button>().onClick.AddListener(OnClickCloseButton);
        currentSelectItemInfo = transform.Find("SelectItem/SelectInfo").gameObject;
        selectListLayout = transform.Find("SelectItem/SelectItemBar/HorizontalLayout").GetComponent<HorizontalLayoutGroup>();
        
        ShowAnim();
    }
    public override void OnPause()
    {
    }
    public override void OnResume()
    {
    }

    public override void OnExit()
    {
        Destroy(this.gameObject);
    }
    public override void GetBroadInfo<T>(T info)
    {
        List<BaseMember> list = info as List<BaseMember>;
        LoadSelectList(list);
    }

    private void ShowAnim()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);
        gameObject.SetActive(true);
        transform.DOMoveY(transform.position.y + 100f, 0.2f);
    }
    public void OnClickCloseButton()
    {
        transform.DOMoveY(transform.position.y- 100f, 0.1f).OnComplete(() => GameControl.gameControl.RemovePanel(UIPanelType.SelectItem));
    }

    private void LoadSelectList(List<BaseMember> selectList)
    {

        currentSelectItems = selectListLayout.GetComponentsInChildren<SelectItem>();
        foreach (SelectItem item in currentSelectItems)
        {
            item.DestroySelf();
        }
        int count = selectList.Count;

        for (int i = 0; i < count; i++)
        {
            GameObject selectObject = GameObject.Instantiate(selectItemsPanel);
            selectObject.transform.SetParent(selectListLayout.transform);
            selectObject.GetComponent<SelectItem>().SetSelectInfo(selectList[i]);
        }
        Vector2 size = selectListLayout.GetComponent<RectTransform>().sizeDelta;
        float sizeWidth = count * (selectItemsPanel.GetComponent<RectTransform>().sizeDelta.x + selectListLayout.spacing);
        selectListLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeWidth, size.y);
        selectListLayout.GetComponent<RectTransform>().localPosition = new Vector3(sizeWidth / 2, 0); //TODO可以更简单的恢复到顶部

        currentSelectItems = selectListLayout.GetComponentsInChildren<SelectItem>();
    }
    public void HideSelfAllSelectItem()
    {
        currentSelectItemInfo.GetComponent<Text>().text  = currentSelectObjectData.m_data.selfName;
        currentSelectItemInfo.SetActive(true);

        foreach (SelectItem item in currentSelectItems)
        {
            item.HideSelf();
        }
    }
    public void NotHideSelfAllSelectItem()
    {
        if (currentSelectItemInfo.activeSelf == true)
        {
            currentSelectItemInfo.SetActive(false);
        }
        foreach (SelectItem item in currentSelectItems)
        {
            item.NotHideSelf();
        }
    }
    public ObjectDataValue CurrentSelectObjectData{
        set {
            currentSelectObjectData = value;
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 25, 100, 30), "Cube_1"))
        {
            currentSelectItems = null;
            List<BaseMember> objectItems = new List<BaseMember>();
            objectItems.Add(new Build1500());
            objectItems.Add(new Build1502());
            objectItems.Add(new Build1503());
            objectItems.Add(new Build1504());
            objectItems.Add(new Build1505());
            LoadSelectList(objectItems);
        }
        
        if (GUI.Button(new Rect(135, 25, 100, 30), "Cube_3"))
        {
            currentSelectItems = null;
            List<BaseMember> objectItems = new List<BaseMember>();
            objectItems.Add(new SoldierMem1100());
            objectItems.Add(new SoldierMem1101());
            LoadSelectList(objectItems);
        }
    }
}
