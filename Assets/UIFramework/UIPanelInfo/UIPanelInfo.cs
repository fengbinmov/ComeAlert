using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver
{

    [NonSerialized]
    public UIPanelType panelType;
    public string panelTypeString;

    public string path;

    //反序列化
    public void OnAfterDeserialize()
    {
        UIPanelType type = (UIPanelType)System.Enum.Parse(typeof(UIPanelType), panelTypeString);
        panelType = type;
    }

    public void OnBeforeSerialize()
    {
    }
}