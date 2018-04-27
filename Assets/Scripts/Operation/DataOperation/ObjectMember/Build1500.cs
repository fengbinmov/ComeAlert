using System;
using System.Collections.Generic;
using System.Text;
using GameAttrType;
using UnityEngine;


public class Build1500 : BuildMem
{
    private Vector3 objectPostion;
    private GameObject prefab;
    private GameObject mObject;
    public Build1500()
    {
        selfDataValue = new BuildData1500();
        objectPostion = transform.Find("ObjectPostion").position;
    }

    public override void BuildMakeObject(BaseMember mem)
    {
        prefab = Resources.Load(mem.selfDataValue.m_data.self) as GameObject;
        mObject = Instantiate(prefab, transform.position, Quaternion.identity);
        mObject.SetActive(false);
    }
}
