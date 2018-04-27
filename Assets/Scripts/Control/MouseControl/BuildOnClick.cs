using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class BuildOnClick:MonoBehaviour
{
    private BaseMember mBaseMember;
    public BaseMember SetMemeber {
        set{ mBaseMember = value; }
    }
    private void OnMouseUpAsButton()
    {
        GameControl.gameControl.SendBuildInfoForUI(UIPanelType.SoldierType, ENUM_MSG_TYPE.OBJECT, mBaseMember);
    }
}
