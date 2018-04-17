using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenuPanel : BasePanel {

    private GameObject MenuPanel;
    private GameObject SettingsPanel;

    public MainMenuPanel():base()
    {
        uIPanelType = UIPanelType.MainMenu;
    }

    public override void OnEnter()
    {
        Debug.Log("OnEnter");
        Init();
        MenuPanel.transform.localPosition= new Vector3(800f, transform.position.y);
        MenuPanel.SetActive(true);
        MenuPanel.transform.DOLocalMoveX(0, 0.8f);
    }

    public override void OnPause()
    {
        MenuPanel.transform.DOLocalMoveY(800f, 0.5f).OnComplete(()=>MenuPanel.SetActive(false));
    }

    public override void OnResume()
    {
        MenuPanel.SetActive(true);
        MenuPanel.transform.DOLocalMoveY(0, 0.5f);
    }

    public override void OnExit()
    {
        base.OnExit();
        //根面板
    }
    public void OnClickStartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
    public void OnClickSettings()
    {
        GameControl.gameControl.AddPanelDict(UIPanelType.Settings, SettingsPanel);
        GameControl.gameControl.PushPanel(UIPanelType.Settings);
    }
    private void Init() {

        MenuPanel = transform.Find("Menu").gameObject;
        SettingsPanel = transform.Find("Settings").gameObject;
    }
}
