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
        mObjectSystem = new ObjectSystem(countryID);
        mBuildSystem = new BuildSystem(countryID);
    }
    public void Init() {

    }
    public void Update() {

    }

#region ObjectSystem方法集
    public void AddMem(BaseMember mem, uint memID)
    {

        BaseMember memT = mObjectSystem.AddMemInCountry(mem, memID);
        mBuildSystem.AddMem(memT);
    }
    public void RemvoeMem(uint memID)
    {
        mObjectSystem.RemoveMemInCountry(memID);
        mBuildSystem.SubMem(memID);
    }
    public BaseMember GetMemForMemID(UInt32 memID)
    {
        return mObjectSystem.GetMemForMemID(memID);
    }
    public ushort GetSameTypeCount(ENUM_OBJECT_NAME oBJECT_NAME)
    {
        return mObjectSystem.GetSameTypeCount(oBJECT_NAME);
    }
    public void UpdateNativeBuildLabCount()
    {
        mObjectSystem.UpdateBuildLabCount();
    }
#endregion

#region BuildSystem方法集
    public void BuildMakeObject(BaseMember mem)
    {
        mBuildSystem.BuildMakeObject(mem);
    }
    public void SetActiveBuild(ENUM_BUILDLAB_TYPE _TYPE, int CodeNum)
    {
        mBuildSystem.SetActiveBuild(_TYPE, CodeNum);
    }
    public int GetActiveBuildLabCode()
    {
        return mBuildSystem.GetActiveBuildLabCode();
    }
    public ENUM_BUILDLAB_TYPE GetActiveBuildType()
    {
        return mBuildSystem.GetActiveBuildType();
    }
    public int GetBuildLabCode(BuildMem buildMem)
    {
        return mBuildSystem.GetBuildLabCode(buildMem);
    }
    public List<BaseMember> GetCanMakeObjectList(ENUM_BUILDLAB_TYPE bUILDLAB_TYPE)
    {
        return mBuildSystem.GetCanMakeObjectList(bUILDLAB_TYPE);
    }
    #endregion


}
