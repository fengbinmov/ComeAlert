using System;
using System.Collections.Generic;
using System.Text;
using GameAttrType;
using UnityEngine;
using System.Threading;


public class Build1500 : BuildMem
{
    private Vector3 objectPostion;
    private GameObject prefab;
    private GameObject mObject;
    private float makeTime;
    public Build1500()
    {
        selfDataValue = new BuildData1500();
        //objectPostion = transform.Find("ObjectPostion").position;
    }
    public override void Updata()
    {
        BuildMakeObjects();
    }

    private void BuildMakeObjects()
    {
        //BaseMember mem = makeObjectList[0];
        //if (mem == null) return;

        //prefab = Resources.Load(mem.selfDataValue.m_data.self) as GameObject;
        //mObject = Instantiate(prefab, objectPostion, Quaternion.identity);
        ////mObject.SetActive(false);
        //GameOperation.gameOperation.AddMemInCountry(countryID, mObject.GetComponent<BaseMember>());
    }
    public override BaseMember Clone()
    {
        Debug.Log("Clone");
        return new Build1500();
    }


}
