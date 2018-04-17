using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class MenuPanel : BasePanel
{
    public MenuPanel():base()
    {
        uIPanelType = UIPanelType.Menu;
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnPause()
    {
        base.OnPause();
    }

    public override void OnResume()
    {
        base.OnResume();
    }
}
