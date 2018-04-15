using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class UIDirftInfo
{
    private Vector3 panelPostion;
    private string name;
    private string outlay;
    private string introduce;

    public void SetDirftPanelInfo(Vector3 vector3,string na,string ou,string ie) {
        panelPostion = vector3;
        name = na;
        outlay = ou;
        introduce = ie;
    }
    public void CleanDirftPanelInfo()
    {
        panelPostion = Vector3.zero;
        name = null;
        outlay = null;
        introduce = null;
    }
    public Vector3 PanelPostion{
        get{
            return panelPostion;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
    }
    public string Outlay
    {
        get
        {
            return outlay;
        }
    }
    public string Introduce
    {
        get
        {
            return introduce;
        }
    }
}
