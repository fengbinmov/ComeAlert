using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    //<国家ID<建筑类型，该建筑数>>
    private Dictionary<ENUM_OBJECT_NAME, UInt16> buildhas = new Dictionary<ENUM_OBJECT_NAME, ushort>();
    private ushort xuhao;
    //<国家ID<建筑序号，建筑ID>>
    private Dictionary<int, uint> buildIDs = new Dictionary<int, uint>();
    private BuildMem activeBuild = new BuildMem();


    public void AddCountry(ushort countryID) {
        Dictionary<ENUM_OBJECT_NAME, UInt16> dictionary = new Dictionary<ENUM_OBJECT_NAME, ushort>
        {
            { ENUM_OBJECT_NAME.B_DEMOS, 0 },
            { ENUM_OBJECT_NAME.B_SOLDIER, 0 },
            { ENUM_OBJECT_NAME.B_ZHANZHENG, 0 },
            { ENUM_OBJECT_NAME.B_WATER, 0 },
            { ENUM_OBJECT_NAME.B_AIR, 0 }
        };
        
        buildhas=dictionary;
        xuhao= 0;
        buildIDs= new Dictionary<int, uint>();
        activeBuild= new BuildMem();
    }
    public void UpdateCountrySameBuildNum(ushort countryID, Dictionary<ENUM_OBJECT_NAME, ushort> dicts) {

        foreach (ENUM_OBJECT_NAME enums in dicts.Keys) {
            if ((int)enums >= 1500 && (int)enums < 1600) {
                if (buildhas.ContainsKey(enums)) {
                    buildhas[enums] = dicts[enums];
                }
                else
                    buildhas.Add(enums, dicts[enums]);
            }
        }
    }
    public void AddCountryBuildNum(ushort countryID, uint memID) {

        xuhao++;
        buildIDs.Add(xuhao, memID);
    }
    public void SubCountryBuildNum(ushort countryID, uint memID)
    {
        int removeXuhao = 0;
        for (int i = 1; i <= xuhao; i++) {
            if (buildIDs[i] == memID) {
                removeXuhao = i;
            }
        }
        if (removeXuhao == 0) return;
        buildIDs.Remove(removeXuhao);

        for (int i = removeXuhao; i < xuhao; i++)
        {
            uint id = buildIDs[i+1];
            buildIDs.Add(i, id);
        }
        if(xuhao > 1)
            buildIDs.Remove(xuhao);
        xuhao--;
    }
    public void UpdateCountryActiveBuild(ushort countryID,BuildMem buildMem) {

        activeBuild = buildMem;

    }

    public ushort GetSameBuildCount(ENUM_OBJECT_NAME buildType)
    {
        return buildhas.TryGet(buildType);
    }

    //检测本地国家的对应的建筑所激活的面板，并激活相应的面板事件
    private void BuildPanelActiveEvent()
    {
        ushort[] activeArr = { 0, 0, 0, 0, 0 };
        activeArr[0] = GetSameBuildCount(ENUM_OBJECT_NAME.B_DEMOS);
        activeArr[1] = GetSameBuildCount(ENUM_OBJECT_NAME.B_SOLDIER);
        activeArr[2] = GetSameBuildCount(ENUM_OBJECT_NAME.B_ZHANZHENG);
        activeArr[3] = GetSameBuildCount(ENUM_OBJECT_NAME.B_WATER);
        activeArr[4] = GetSameBuildCount(ENUM_OBJECT_NAME.B_AIR);

        GameControl.gameControl.SendBuildInfoForUI<ushort[]>(UIPanelType.SoldierType, ENUM_MSG_TYPE.ARRAY, activeArr);
    }
    public void BuildMakeObject(BaseMember mem) {

        activeBuild.BuildMakeObject();
    }
    public void SetActiveBuild(UInt16 countryID,ENUM_OBJECT_NAME bUILDLAB_TYPE)
    {
        //BaseMember mem = GameOperation.gameOperation.GetMemForMemID(countryID,buildhas[bUILDLAB_TYPE]);
        //activeBuild = mem as BuildMem;
    }
}
