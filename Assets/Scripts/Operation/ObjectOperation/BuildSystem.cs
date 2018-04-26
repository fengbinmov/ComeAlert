using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    //<国家ID<建筑类型，该建筑数>>
    private Dictionary<ushort,Dictionary<ENUM_BUILD_TYPE, UInt16>> buildhas = new Dictionary<ushort, Dictionary<ENUM_BUILD_TYPE, ushort>>();
    private Dictionary<ushort, Dictionary<ENUM_BUILD_TYPE, List<BaseMember>>> buildsMen = new Dictionary<ushort, Dictionary<ENUM_BUILD_TYPE, List<BaseMember>>>();


    public void AddCountry(ushort countryID) {
        Dictionary<ENUM_BUILD_TYPE, UInt16> dictionary = new Dictionary<ENUM_BUILD_TYPE, ushort>
        {
            { ENUM_BUILD_TYPE.DEMOS, 0 },
            { ENUM_BUILD_TYPE.SOLDIER, 0 },
            { ENUM_BUILD_TYPE.CAR, 0 },
            { ENUM_BUILD_TYPE.WATER, 0 },
            { ENUM_BUILD_TYPE.AIR, 0 }
        };
        Dictionary<ENUM_BUILD_TYPE,List<BaseMember>> dictionary2 = new Dictionary<ENUM_BUILD_TYPE, List<BaseMember>>
        {
            { ENUM_BUILD_TYPE.DEMOS, new List<BaseMember>() },
            { ENUM_BUILD_TYPE.SOLDIER, new List<BaseMember>() },
            { ENUM_BUILD_TYPE.CAR, new List<BaseMember>() },
            { ENUM_BUILD_TYPE.WATER, new List<BaseMember>() },
            { ENUM_BUILD_TYPE.AIR, new List<BaseMember>() }
        };

        buildhas.Add(countryID,dictionary);
        buildsMen.Add(countryID, dictionary2);
    }
    public void AddBuildForACountry(ushort countryID, UInt16 id,BaseMember mem) {
        if (id >= 1500 && id < 1600) {

            buildhas[countryID][(ENUM_BUILD_TYPE)id]++;
            buildsMen[countryID][(ENUM_BUILD_TYPE)id].Add(mem);
        }
    }
    public void SubBuildForACountry(ushort countryID, UInt16 id, BaseMember mem)
    {
        if (id >= 1500 && id < 1600)
        {
            buildhas[countryID][(ENUM_BUILD_TYPE)id]--;
            buildsMen[countryID][(ENUM_BUILD_TYPE)id].Remove(mem);
        }
    }

    public ushort GetBuildNumForACountry(ushort countryID, ENUM_BUILD_TYPE buildType)
    {
        //Debug.Log("countryID[" + countryID + "]");
        return buildhas[countryID].TryGet(buildType);
    }
    public List<BaseMember> GetBuildsForACountry(ushort countryID, ENUM_BUILD_TYPE buildType)
    {
        return buildsMen[countryID][buildType];
    }
}
