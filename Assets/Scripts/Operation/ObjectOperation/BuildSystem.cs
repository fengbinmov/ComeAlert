using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    public Dictionary<ushort,Dictionary<ENUM_BUILD_TYPE, UInt16>> buildhas = new Dictionary<ushort, Dictionary<ENUM_BUILD_TYPE, ushort>>();

    public void AddCountry(ushort countryID) {
        Dictionary<ENUM_BUILD_TYPE, UInt16> dictionary = new Dictionary<ENUM_BUILD_TYPE, ushort>
        {
            { ENUM_BUILD_TYPE.DEMOS, 0 },
            { ENUM_BUILD_TYPE.SOLDIER, 0 },
            { ENUM_BUILD_TYPE.CAR, 0 },
            { ENUM_BUILD_TYPE.WATER, 0 },
            { ENUM_BUILD_TYPE.AIR, 0 }
        };

        buildhas.Add(countryID,dictionary);
    }
    public void AddBuildForACountry(ushort countryID, UInt16 id) {
        switch ((ENUM_BUILD_TYPE)id)
        {
            case ENUM_BUILD_TYPE.DEMOS:
                buildhas[countryID][ENUM_BUILD_TYPE.DEMOS]++;
                break;
            case ENUM_BUILD_TYPE.POWER:
                break;
            case ENUM_BUILD_TYPE.SOLDIER:
                buildhas[countryID][ENUM_BUILD_TYPE.SOLDIER]++;
                break;
            case ENUM_BUILD_TYPE.CAR:
                buildhas[countryID][ENUM_BUILD_TYPE.CAR]++;
                break;
            case ENUM_BUILD_TYPE.WATER:
                buildhas[countryID][ENUM_BUILD_TYPE.WATER]++;
                break;
            case ENUM_BUILD_TYPE.AIR:
                buildhas[countryID][ENUM_BUILD_TYPE.AIR]++;
                break;
            default:
                break;
        }
    }
    public void SubBuildForACountry(ushort countryID, UInt16 id)
    {
        switch ((ENUM_BUILD_TYPE)id)
        {
            case ENUM_BUILD_TYPE.DEMOS:
                buildhas[countryID][ENUM_BUILD_TYPE.DEMOS]--;
                break;
            case ENUM_BUILD_TYPE.POWER:
                break;
            case ENUM_BUILD_TYPE.SOLDIER:
                buildhas[countryID][ENUM_BUILD_TYPE.SOLDIER]--;
                break;
            case ENUM_BUILD_TYPE.CAR:
                buildhas[countryID][ENUM_BUILD_TYPE.CAR]--;
                break;
            case ENUM_BUILD_TYPE.WATER:
                buildhas[countryID][ENUM_BUILD_TYPE.WATER]--;
                break;
            case ENUM_BUILD_TYPE.AIR:
                buildhas[countryID][ENUM_BUILD_TYPE.AIR]--;
                break;
            default:
                break;
        }
    }

    public ushort GetBuildNumForACountry(ushort countryID, ENUM_BUILD_TYPE buildType)
    {
        //Debug.Log("countryID[" + countryID + "]");
        return buildhas[countryID].TryGet(buildType);
    }
}
