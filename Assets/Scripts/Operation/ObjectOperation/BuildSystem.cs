using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    //<国家ID<建筑类型，该建筑数>>
    private Dictionary<ushort,Dictionary<ENUM_OBJECT_NAME, UInt16>> buildhas = new Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, ushort>>();
    private Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, List<BaseMember>>> buildsMen = new Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, List<BaseMember>>>();


    public void AddCountry(ushort countryID) {
        Dictionary<ENUM_OBJECT_NAME, UInt16> dictionary = new Dictionary<ENUM_OBJECT_NAME, ushort>
        {
            { ENUM_OBJECT_NAME.B_DEMOS, 0 },
            { ENUM_OBJECT_NAME.B_SOLDIER, 0 },
            { ENUM_OBJECT_NAME.B_ZHANZHENG, 0 },
            { ENUM_OBJECT_NAME.B_WATER, 0 },
            { ENUM_OBJECT_NAME.B_AIR, 0 }
        };
        Dictionary<ENUM_OBJECT_NAME, List<BaseMember>> dictionary2 = new Dictionary<ENUM_OBJECT_NAME, List<BaseMember>>
        {
            { ENUM_OBJECT_NAME.B_DEMOS, new List<BaseMember>() },
            { ENUM_OBJECT_NAME.B_SOLDIER, new List<BaseMember>() },
            { ENUM_OBJECT_NAME.B_ZHANZHENG, new List<BaseMember>() },
            { ENUM_OBJECT_NAME.B_WATER, new List<BaseMember>() },
            { ENUM_OBJECT_NAME.B_AIR, new List<BaseMember>() }
        };

        buildhas.Add(countryID,dictionary);
        buildsMen.Add(countryID, dictionary2);
    }
    public void AddBuildForACountry(ushort countryID, UInt16 id,BaseMember mem) {
        if (buildhas[countryID].ContainsKey((ENUM_OBJECT_NAME)id)) {

            buildhas[countryID][(ENUM_OBJECT_NAME)id]++;
            buildsMen[countryID][(ENUM_OBJECT_NAME)id].Add(mem);

            if(countryID == 1) BuildPanelActiveEvent();
        }
    }
    public void SubBuildForACountry(ushort countryID, UInt16 id, BaseMember mem)
    {
        if (buildhas[countryID].ContainsKey((ENUM_OBJECT_NAME)id))
        {
            buildhas[countryID][(ENUM_OBJECT_NAME)id]--;
            buildsMen[countryID][(ENUM_OBJECT_NAME)id].Remove(mem);
            
            if (countryID == 1) BuildPanelActiveEvent();
        }
    }

    public ushort GetBuildNumForACountry(ushort countryID, ENUM_OBJECT_NAME buildType)
    {
        //Debug.Log("countryID[" + countryID + "]");
        return buildhas[countryID].TryGet(buildType);
    }
    public List<BaseMember> GetBuildsForACountry(ushort countryID, ENUM_OBJECT_NAME buildType)
    {
        return buildsMen[countryID][buildType];
    }

    //检测本地国家的对应的建筑所激活的面板，并激活相应的面板事件
    private void BuildPanelActiveEvent()
    {
        ushort[] activeArr = { 0, 0, 0, 0, 0 };
        activeArr[0] = GetBuildNumForACountry(1, ENUM_OBJECT_NAME.B_DEMOS);
        activeArr[1] = GetBuildNumForACountry(1, ENUM_OBJECT_NAME.B_SOLDIER);
        activeArr[2] = GetBuildNumForACountry(1, ENUM_OBJECT_NAME.B_ZHANZHENG);
        activeArr[3] = GetBuildNumForACountry(1, ENUM_OBJECT_NAME.B_WATER);
        activeArr[4] = GetBuildNumForACountry(1, ENUM_OBJECT_NAME.B_AIR);

        GameControl.gameControl.SendBuildInfoForUI<ushort[]>(UIPanelType.SoldierType, ENUM_MSG_TYPE.ARRAY, activeArr);
    }
    private void BuildMakeObject(ushort countryID, ENUM_OBJECT_NAME buildType,ushort buildID) {
        if (buildhas[countryID].ContainsKey(buildType))
        {
            List<BaseMember> list = buildsMen[countryID][buildType];
            foreach (BaseMember mem in list) {
                if (mem.selfDataValue.m_data.m_u4IDNum == buildID) {

                }
            }
        }
    }
}
