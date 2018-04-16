using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class UIDirftInfo
{
    public struct DirftInfo
    {
        public Vector3 panelPostion;
        public string name;
        public string outlay;
        public string introduce;
    }
    private DirftInfo dirftInfo;

    public void SetDirftPanelInfo(Vector3 vector3,string na,string ou,string ie) {
        dirftInfo.panelPostion = vector3;
        dirftInfo.name = na;
        dirftInfo.outlay = ou;
        dirftInfo.introduce = ie;
    }
    public void CleanDirftPanelInfo()
    {
        dirftInfo.panelPostion = Vector3.zero;
        dirftInfo.name = null;
        dirftInfo.outlay = null;
        dirftInfo.introduce = null;
    }
    public DirftInfo GetDirftInfo{
        get {
            return dirftInfo;
        }
    }
}
