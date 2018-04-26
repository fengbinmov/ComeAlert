using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class ObjectOperation : BaseOperation
{
    public ObjectOperation(GameOperation gameOperation) : base(gameOperation) { }

    private UInt32 iDNumCount = 0;          //“对象省份证”|总数
    private UInt16 iDCountryCount = 0;      //“国家省份证”|总数
    private CountrySystem mCountrySystem = new CountrySystem();
    private BuildSystem mBuildSystem = new BuildSystem();

    public void AddCountryList(ushort team) {

        ++iDCountryCount;
        mCountrySystem.AddCountryList(iDCountryCount,team, mBuildSystem);
    }
    public void AddMemInCountry(ushort idCountryCount,BaseMember mem) {

        ++iDNumCount;
        mCountrySystem.AddMemInCountry(idCountryCount, mem, iDNumCount, mBuildSystem);
    }
    public void RemoveCountryList(ushort idCountryCount) {

        --iDCountryCount;
        mCountrySystem.RemoveCountryList(idCountryCount);
    }
    public void RemoveMemInCountry(ushort idCountryCount, UInt32 memID)
    {
        mCountrySystem.RemoveMemInCountry(idCountryCount, memID, mBuildSystem);
    }

    public override void Init()
    {
        base.Init();
        foreach (Dictionary<UInt32, BaseMember> memCountry in mCountrySystem.CountryMem.Values)
        {
            foreach (BaseMember mem in memCountry.Values)
            {
                mem.Init();
            }
        }
    }
    public override void Update()
    {
        foreach (Dictionary<UInt32, BaseMember> memCountry in mCountrySystem.CountryMem.Values)
        {
            foreach (BaseMember mem in memCountry.Values)
            {
                mem.Updata();
            }
        }

    }
    public override void Destroy()
    {
        base.Destroy();
        foreach (Dictionary<UInt32, BaseMember> memCountry in mCountrySystem.CountryMem.Values)
        {
            foreach (BaseMember mem in memCountry.Values)
            {
                mem.Destroy();
            }
        }
    }
    

    //返回场景中所有的 士兵数+建筑数
    public UInt32 MemCount { get { return iDNumCount; } }


    //返回场景中的国家数
    public UInt32 CountryCount { get { return iDCountryCount; } }


    //Debug
    public void GetCountryInfo() {
        foreach (ushort keyID in mCountrySystem.CountryMem.Keys)
        {
            Debug.Log("总数keyID[" + keyID + "]");
        }
    }
    public ushort GetBuildNumForACountry(ushort countryID, ENUM_BUILD_TYPE buildType) {

        return mBuildSystem.GetBuildNumForACountry(countryID, buildType);
    }
    public ushort[] GetAllCountryID()
    {
        ushort[] countryID = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        ushort count = 0;
        foreach (ushort memCountryID in mCountrySystem.CountryMem.Keys)
        {
            countryID[count] = memCountryID;
            count++;
        }
        return countryID;
    }
    public CountrySystem GetCountrySystem() {
        return mCountrySystem;
    }
    public List<BaseMember> GetBuildsForACountry(ushort countryID, ENUM_BUILD_TYPE buildType) {
        return mBuildSystem.GetBuildsForACountry(countryID, buildType);
    }
}
