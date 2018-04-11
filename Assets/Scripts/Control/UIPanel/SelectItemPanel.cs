using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SelectItemPanel : BasePanel{

    private GameObject selectItemPrefab;
    private GameObject instansCubeBuild;

    private RectTransform mRectTransform;
    private HorizontalLayoutGroup selectListLayout;
    
    public override void OnEnter()
    {
        base.OnEnter();
        mRectTransform = GetComponent<RectTransform>();
        selectItemPrefab = Resources.Load("UIPanel/ItemPanel") as GameObject;
        transform.Find("SelectItem/CloseButton").GetComponent<Button>().onClick.AddListener(OnClickCloseButton);
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

    private void ShowAnim()
    {
        gameObject.SetActive(true);
        mRectTransform.localPosition = new Vector3(0, -100f,0);
        transform.DOMoveY(mRectTransform.position.y + 100f, 0.5f);
    }
    public void OnClickCloseButton()
    {
        mRectTransform.DOLocalMoveY(-100f, 0.1f).OnComplete(() => GameControl.gameControl.PopPanel());
    }
    private void LoadSelectList(List<ObjectDataValue> selectList) {
        SelectItem[] selectItems = selectListLayout.GetComponentsInChildren<SelectItem>();
        foreach (SelectItem item in selectItems) {
            item.DestroySelf();
        }
        int count = selectList.Count;
        Debug.Log(count);
        for (int i = 0; i < count; i++) {
            GameObject selectObject = GameObject.Instantiate(selectItemPrefab);
            selectObject.transform.SetParent(selectListLayout.transform);
            selectObject.GetComponent<SelectItem>().SetSelectInfo(selectList[i]);
        }
        Vector2 size = selectListLayout.GetComponent<RectTransform>().sizeDelta;
        float sizeWidth = count * (selectItemPrefab.GetComponent<RectTransform>().sizeDelta.x + selectListLayout.spacing);
        selectListLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeWidth, size.y);
        selectListLayout.GetComponent<RectTransform>().localPosition = new Vector3(sizeWidth/2, 0); //TODO可以更简单的恢复到顶部
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(25, 25, 100, 30), "Cube_1"))
        {
            List<ObjectDataValue> objectItems = new List<ObjectDataValue>();
            objectItems.Add(new Solider1100());
            LoadSelectList(objectItems);
        }
        if (GUI.Button(new Rect(135, 25, 100, 30), "Cube_2"))
        {
            List<ObjectDataValue> objectItems = new List<ObjectDataValue>();
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            objectItems.Add(new Solider1100());
            LoadSelectList(objectItems);
        }
    }
}
