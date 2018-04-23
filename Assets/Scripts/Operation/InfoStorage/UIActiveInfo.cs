using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class UIActiveInfo
{
    //Demos、Soldier、Car、Water、Air
    private ushort[] activeArr = { 0,0,0,0,0};

    public void SetActivePanelInfo(ushort[] arr)
    {
        activeArr = arr;
    }
    public void CleanActivePanelInfo()
    {
        activeArr = null;
    }
    public ushort[] GetActiveInfo
    {
        get
        {
            return activeArr;
        }
    }
}
