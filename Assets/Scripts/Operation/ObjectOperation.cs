using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class ObjectOperation : BaseOperation
{
    public ObjectOperation(GameOperation gameOperation) : base(gameOperation) { }

    private UInt32 objectID = 0;          //“对象省份证”|总数
    private UInt16 countryID = 0;      //“国家省份证”|总数

    private Dictionary<ushort,CountryManager> countryDict;

    public void AddCountryList(ushort team) {

        ++countryID;
        countryDict.Add(countryID, new CountryManager(team, countryID));
    }
    public void AddMemInCountry(ushort countryID,BaseMember mem) {
        
        countryDict[countryID].AddMem(mem, objectID);
    }
    public void RemoveCountryList(ushort countryID) {

        countryDict.Remove(countryID);
    }
    public void RemoveMemInCountry(ushort countryID, UInt32 memID)
    {
        countryDict[countryID].RemvoeMem(memID);
    }

    public override void Init()
    {
        foreach (CountryManager memCountry in countryDict.Values){

            memCountry.Init();
        }
    }
    public override void Update() { }
    public override void Destroy() {  }
    

    //返回场景中所有的 士兵数+建筑数
    public UInt32 MemCount { get { return objectID; } }


    //返回场景中的国家数
    public UInt32 CountryCount { get { return countryID; } }


    //Debug
    public void GetCountryInfo() {
        foreach (ushort keyID in countryDict.Keys)
        {
            Debug.Log("总数keyID[" + keyID + "]");
        }
    }
    public ushort GetBuildNumForACountry(ushort countryID, ENUM_OBJECT_NAME buildType) {

        return countryDict[countryID].GetSameBuildCount(buildType);
    }
    public ushort[] GetAllCountryID()
    {
        ushort[] countryID = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        ushort count = 0;
        foreach (ushort memCountryID in countryDict.Keys)
        {
            countryID[count] = memCountryID;
            count++;
        }
        return countryID;
    }

    public BaseMember GetMemForMemID(ushort countryID, UInt32 memID)
    {
        return countryDict[countryID].GetMemForMemID(memID);
    }
}
