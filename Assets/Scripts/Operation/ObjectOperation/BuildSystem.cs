using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    ushort countryID;
    //<建筑ID，建筑脚本>
    private Dictionary<uint, BuildMem> buildMems = new Dictionary<uint, BuildMem>();
    private Dictionary<int , List<BuildMem>> activeBuildDict;
    private ushort xuhao;
    //<建筑序号，建筑ID>
    private Dictionary<int, uint> buildIDs;
    private BuildMem activeBuild = new BuildMem();

    public BuildSystem(ushort countryId) {

        countryID = countryId;
        xuhao = 0;
        buildIDs = new Dictionary<int, uint>();
        activeBuild = null;
        activeBuildDict = new Dictionary<int, List<BuildMem>>
        {
            { 0,new List<BuildMem>()},
            { 1,new List<BuildMem>()},
            { 2,new List<BuildMem>()},
            { 3,new List<BuildMem>()},
            { 4,new List<BuildMem>()}
        };
    }
    public void AddMem(BaseMember mem) {

        uint memID = mem.selfDataValue.m_data.m_u4IDNum;
        if (IsExist(memID, mem)) {

            BuildMem buildMem = (BuildMem)mem;

            buildMems.Add(memID, buildMem);
            ushort id = mem.selfDataValue.m_data.m_u2ID;
            if (id >= 1500 && id < 1505 && id != 1501) {
                activeBuildDict[id - 1500].Add(buildMem);
            }
            if (countryID == 1) {
                GameOperation.gameOperation.UpdateNativeBuildLabCount();
            }
        }
    }
    public void SubMem(uint memID){

        if (IsExist(memID,null)) {

            BuildMem buildMem = buildMems[memID];

            ushort id = buildMem.selfDataValue.m_data.m_u2ID;
            if (id >= 1500 && id < 1505 && id != 1501)
            {
                activeBuildDict[id - 1500].Remove(buildMem);
            }

            buildMems.Remove(memID);
            
            if (countryID == 1){
                GameOperation.gameOperation.UpdateNativeBuildLabCount();
            }
        }
    }
    public void SetActiveBuild(ENUM_BUILDLAB_TYPE _TYPE, int CodeNum) {
        
        activeBuild = activeBuildDict[(int)_TYPE - 1500][CodeNum];
        Debug.Log("memID=" + activeBuild.selfDataValue.m_data.m_u4IDNum+";Code="+CodeNum+"次序="+activeBuildDict[(int)_TYPE - 1500].IndexOf(activeBuild));
    }

    public void BuildMakeObject(BaseMember mem) {

        activeBuild.BuildMakeObject();
    }
    private bool IsExist(uint memID, BaseMember mem)
    {
        if (mem.selfDataValue == null)
        {
            return buildMems.ContainsKey(memID);
        }
        else {
            if (mem.selfDataValue.m_data.m_emObjectType == ENUM_OBJECT_TYPE.OBJECT_BUILD)
                return true;
            else
                return false;
        }
    }
}
