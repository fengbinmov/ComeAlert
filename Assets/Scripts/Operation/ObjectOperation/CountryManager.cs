using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class CountryManager
{
    ObjectSystem mObjectSystem;
    ArmySystem mArmySystem;
    BuildSystem mBuildSystem;
    AllotSystem mAllotSystem;
    EnemySystem mEnemySystem;

    ushort countryTeamNum;
    ushort countryID;

    public CountryManager(ushort teamNum,ushort countryId) {
        this.countryTeamNum = teamNum;
        this.countryID = countryId;
        mObjectSystem = new ObjectSystem();
        mBuildSystem = new BuildSystem();
    }
    public void Init() {

    }

#region ObjectSystem方法集
    public void AddMem(BaseMember mem, uint memID)
    {

        mObjectSystem.AddMemInCountry(mem, memID);
    }
    public void RemvoeMem(uint memID)
    {
        mObjectSystem.RemoveMemInCountry(memID);
    }
    public BaseMember GetMemForMemID(UInt32 memID)
    {
        return mObjectSystem.GetMemForMemID(memID);
    }
#endregion

#region BuildSystem方法集
    public ushort GetSameBuildCount(ENUM_OBJECT_NAME oBJECT_NAME)
    {
        return mBuildSystem.GetSameBuildCount(oBJECT_NAME);
    }
    public void BuildMakeObject(BaseMember mem)
    {
        mBuildSystem.BuildMakeObject(mem);
    }
#endregion


}
