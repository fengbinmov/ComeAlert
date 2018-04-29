using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    //<国家ID<建筑类型，该建筑数>>
    private Dictionary<ushort,Dictionary<ENUM_OBJECT_NAME, UInt16>> buildhas = new Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, ushort>>();
    private Dictionary<ushort, ushort> xuhao = new Dictionary<ushort, ushort>();
    //<国家ID<建筑序号，建筑ID>>
    private Dictionary<ushort, Dictionary<int, uint>> buildIDs = new Dictionary<ushort, Dictionary<int, uint>>();
    private Dictionary<ushort, BuildMem> activeBuild = new Dictionary<ushort, BuildMem>();


    public void AddCountry(ushort countryID) {
        Dictionary<ENUM_OBJECT_NAME, UInt16> dictionary = new Dictionary<ENUM_OBJECT_NAME, ushort>
        {
            { ENUM_OBJECT_NAME.B_DEMOS, 0 },
            { ENUM_OBJECT_NAME.B_SOLDIER, 0 },
            { ENUM_OBJECT_NAME.B_ZHANZHENG, 0 },
            { ENUM_OBJECT_NAME.B_WATER, 0 },
            { ENUM_OBJECT_NAME.B_AIR, 0 }
        };
        
        buildhas.Add(countryID,dictionary);
        xuhao.Add(countryID, 0);
        buildIDs.Add(countryID, new Dictionary<int, uint>());
        activeBuild.Add(countryID, new BuildMem());
    }
    public void UpdateCountrySameBuildNum(ushort countryID, Dictionary<ENUM_OBJECT_NAME, ushort> dicts) {

        foreach (ENUM_OBJECT_NAME enums in dicts.Keys) {
            if ((int)enums >= 1500 && (int)enums < 1600) {
                if (buildhas[countryID].ContainsKey(enums)) {
                    buildhas[countryID][enums] = dicts[enums];
                }
                else
                    buildhas[countryID].Add(enums, dicts[enums]);
            }
        }
    }
    public void AddCountryBuildNum(ushort countryID, uint memID) {

        xuhao[countryID]++;
        buildIDs[countryID].Add(xuhao[countryID], memID);
    }
    public void SubCountryBuildNum(ushort countryID, uint memID)
    {
        int removeXuhao = 0;
        for (int i = 1; i <= xuhao[countryID]; i++) {
            if (buildIDs[countryID][i] == memID) {
                removeXuhao = i;
            }
        }
        if (removeXuhao == 0) return;
        buildIDs[countryID].Remove(removeXuhao);

        for (int i = removeXuhao; i < xuhao[countryID]; i++)
        {
            uint id = buildIDs[countryID][i+1];
            buildIDs[countryID].Add(i, id);
        }
        if(xuhao[countryID] > 1)
            buildIDs[countryID].Remove(xuhao[countryID]);
        xuhao[countryID]--;
    }
    public void UpdateCountryActiveBuild(ushort countryID,BuildMem buildMem) {

        activeBuild[countryID] = buildMem;

    }

    public ushort GetBuildNumForACountry(ushort countryID, ENUM_OBJECT_NAME buildType)
    {
        return buildhas[countryID].TryGet(buildType);
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
    public void BuildMakeObject(UInt16 countryID, BaseMember mem) {

        activeBuild[countryID].BuildMakeObject();
    }
    public void SetActiveBuild(UInt16 countryID,ENUM_OBJECT_NAME bUILDLAB_TYPE)
    {
        //BaseMember mem = GameOperation.gameOperation.GetMemForMemID(countryID,buildhas[countryID][bUILDLAB_TYPE]);
        //activeBuild[countryID] = mem as BuildMem;
    }
}
