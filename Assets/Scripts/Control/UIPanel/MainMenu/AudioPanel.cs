using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using DG.Tweening;


public class AudioPanel : BasePanel
{
    public AudioPanel():base()
    {
        uIPanelType = UIPanelType.Audio;
    }
    public override void OnEnter()
    {
        base.OnEnter();
        transform.localEulerAngles = new Vector3(0, -150f, 0);
        gameObject.SetActive(true);
        transform.DOLocalRotate(new Vector3(0, -30f, 0), 0.8f);
    }

    public override void OnExit()
    {
        base.OnExit();
        transform.DOLocalRotate(new Vector3(0, -150f, 0), 0.8f);
        gameObject.SetActive(false);
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
    public void OnClickCloseButton()
    {
        GameControl.gameControl.RemovePanel(UIPanelType.Audio);
    }
}
