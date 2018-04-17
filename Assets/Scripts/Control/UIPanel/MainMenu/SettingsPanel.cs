using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DG.Tweening;


public class SettingsPanel : BasePanel
{
    private GameObject GameplayPanel;
    private GameObject VideoPanel;
    private GameObject AudioPanel;

    public SettingsPanel():base()
    {
        uIPanelType = UIPanelType.Settings;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        Init();
        transform.localPosition = new Vector3(transform.position.x, 800f);
        gameObject.SetActive(true);
        transform.DOLocalMoveY(0, 0.8f);
    }

    public override void OnExit()
    {
        base.OnExit();
        transform.DOLocalMoveY(800, 0.5f).OnComplete(()=>gameObject.SetActive(false));
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
    public void OnClickCloseButton() {

        GameControl.gameControl.PopPanel();
    }
    public void OnClickGameplayButton()
    {
        RemvoeAll();
        GameControl.gameControl.AddPanelDict(UIPanelType.Gameplay, GameplayPanel);
        GameControl.gameControl.AddPanel(UIPanelType.Gameplay);
    }
    public void OnClickVideoButton()
    {
        RemvoeAll();
        GameControl.gameControl.AddPanelDict(UIPanelType.Video, VideoPanel);
        GameControl.gameControl.AddPanel(UIPanelType.Video);
    }
    public void OnClickAudioButton()
    {
        RemvoeAll();
        GameControl.gameControl.AddPanelDict(UIPanelType.Audio, AudioPanel);
        GameControl.gameControl.AddPanel(UIPanelType.Audio);
    }
    private void Init() {
        GameplayPanel = transform.Find("SettingsPanels/GamePlay").gameObject;
        VideoPanel = transform.Find("SettingsPanels/Video").gameObject;
        AudioPanel = transform.Find("SettingsPanels/Audio").gameObject;
    }
    private void RemvoeAll() {

        if(GameplayPanel.activeSelf == true)
            GameControl.gameControl.RemovePanel(UIPanelType.Gameplay);
        if (VideoPanel.activeSelf == true)
            GameControl.gameControl.RemovePanel(UIPanelType.Video);
        if (AudioPanel.activeSelf == true)
            GameControl.gameControl.RemovePanel(UIPanelType.Audio);
    }
}
