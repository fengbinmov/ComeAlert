using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropPanel : BasePanel
{
    public DragAndDropPanel():base()
    {
        uIPanelType = UIPanelType.DragAndDrop;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        this.gameObject.SetActive(true);
    }

    public override void OnExit()
    {
        base.OnExit();
        this.gameObject.SetActive(false);
    }

    public override void OnPause()
    {
        this.gameObject.SetActive(false);
    }

    public override void OnResume()
    {
        this.gameObject.SetActive(true);
    }
    public void OnClickBackUp() {
        GameControl.gameControl.PopPanel(false);
    }
    public void OnClickStartGame() {

        //SceneManager.LoadScene(1);
        GameControl.gameControl.PushPanel(UIPanelType.Sketch);
    }
}
