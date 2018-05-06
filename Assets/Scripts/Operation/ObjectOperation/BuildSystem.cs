using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class BuildSystem  {

    ushort countryID;
    //<建筑ID，建筑脚本>   所有建筑的记录
    private Dictionary<uint, BuildMem> buildMems = new Dictionary<uint, BuildMem>();
    //5大主建筑的记录
    private Dictionary<int , List<BuildMem>> activeBuildDict;
    //保存可制造的对象
    private Dictionary<int ,List<BaseMember>> canMakeObjectDict;

    //保存当前选定的建筑
    private BuildMem activeBuild = new BuildMem();

    public BuildSystem(ushort countryId) {

        countryID = countryId;
        activeBuild = null;
        activeBuildDict = new Dictionary<int, List<BuildMem>>
        {
            { 0,new List<BuildMem>()},
            { 1,new List<BuildMem>()},
            { 2,new List<BuildMem>()},
            { 3,new List<BuildMem>()},
            { 4,new List<BuildMem>()}
        };
        canMakeObjectDict = new Dictionary<int, List<BaseMember>>
        {
            {
                0,new List<BaseMember>()
                {
                    new SoldierMem1100()
                }
            },
            {
                1,new List<BaseMember>()
                {
                    new SoldierMem1100(),
                    new SoldierMem1100()
                }
            },
            { 2,new List<BaseMember>()},
            { 3,new List<BaseMember>()},
            { 4,new List<BaseMember>()}
        };
    }
    public void AddMem(BaseMember mem) {

        uint memID = mem.selfDataValue.m_data.m_u4IDNum;
        if (IsExist(memID, mem)) {

            BuildMem buildMem = (BuildMem)mem;

            buildMems.Add(memID, buildMem);
            ushort id = mem.selfDataValue.m_data.m_u2ID;
            switch (id){
                case 1500:
                    activeBuildDict[0].Add(buildMem);
                    break;
                case 1502:
                    activeBuildDict[1].Add(buildMem);
                    break;
                case 1503:
                    activeBuildDict[2].Add(buildMem);
                    break;
                case 1504:
                    activeBuildDict[3].Add(buildMem);
                    break;
                case 1505:
                    activeBuildDict[4].Add(buildMem);
                    break;
                default:
                    break;
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
        Debug.Log("激活[建筑," + activeBuild.selfDataValue.m_data.selfName+"][memID,"+ activeBuild.selfDataValue.m_data.m_u4IDNum+ "][次序,"+activeBuildDict[(int)_TYPE - 1500].IndexOf(activeBuild)+"]");
    }
    public int GetActiveBuildLabCode()
    {
        if (activeBuild == null)
            return 999;
        switch (activeBuild.selfDataValue.m_data.m_emObjectName)
        {
            case ENUM_OBJECT_NAME.B_DEMOS:
                return activeBuildDict[0].IndexOf(activeBuild);
            case ENUM_OBJECT_NAME.B_SOLDIER:
                return activeBuildDict[1].IndexOf(activeBuild);
            case ENUM_OBJECT_NAME.B_ZHANZHENG:
                return activeBuildDict[2].IndexOf(activeBuild);
            case ENUM_OBJECT_NAME.B_WATER:
                return activeBuildDict[3].IndexOf(activeBuild);
            case ENUM_OBJECT_NAME.B_AIR:
                return activeBuildDict[4].IndexOf(activeBuild);
            default:
                return 999;
        }
    }
    public ENUM_BUILDLAB_TYPE GetActiveBuildType()
    {
        switch (activeBuild.selfDataValue.m_data.m_emObjectName)
        {
            case ENUM_OBJECT_NAME.B_DEMOS:
                return ENUM_BUILDLAB_TYPE.DEMOS;
            case ENUM_OBJECT_NAME.B_SOLDIER:
                return ENUM_BUILDLAB_TYPE.SOLDIER;
            case ENUM_OBJECT_NAME.B_ZHANZHENG:
                return ENUM_BUILDLAB_TYPE.CAR;
            case ENUM_OBJECT_NAME.B_WATER:
                return ENUM_BUILDLAB_TYPE.WATER;
            default :
                return ENUM_BUILDLAB_TYPE.AIR;
        }
    }
    public int GetBuildLabCode(BuildMem member)
    {
        switch (member.selfDataValue.m_data.m_emObjectName)
        {
            case ENUM_OBJECT_NAME.B_DEMOS:
                return activeBuildDict[0].IndexOf(member);
            case ENUM_OBJECT_NAME.B_SOLDIER:      
                return activeBuildDict[1].IndexOf(member);
            case ENUM_OBJECT_NAME.B_ZHANZHENG:    
                return activeBuildDict[2].IndexOf(member);
            case ENUM_OBJECT_NAME.B_WATER:        
                return activeBuildDict[3].IndexOf(member);
            case ENUM_OBJECT_NAME.B_AIR:          
                return activeBuildDict[4].IndexOf(member);
            default:
                return 999;
        }
    }
    
    public List<BaseMember> GetCanMakeObjectList(ENUM_BUILDLAB_TYPE bUILDLAB_TYPE) {

        return canMakeObjectDict[(int)bUILDLAB_TYPE-1500];
    }
    public void BuildMakeObject(BaseMember mem) {

        
    }
    private bool IsExist(uint memID, BaseMember mem)
    {
        //mem为空是删除的或滤器
        if (mem.selfDataValue == null)
        {
            return buildMems.ContainsKey(memID);
        }
        else {  //检测是否是建筑标签
            if (mem.selfDataValue.m_data.m_emObjectType == ENUM_OBJECT_TYPE.OBJECT_BUILD)
                return true;
            else
                return false;
        }
    }
}
