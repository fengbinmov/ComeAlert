using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class CountrySystem
{
    //所有的国家信息  <国家ID,<省份证号,对象代码>>
    private Dictionary<ushort,Dictionary<UInt32, BaseMember>> countryMems = new Dictionary<ushort, Dictionary<UInt32, BaseMember>>();
    private Dictionary<ushort, IDNum> countryIDCenter = new Dictionary<ushort, IDNum>();//<国家ID,省份证号>
    private Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, ushort>> countrySametypeNum = new Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, ushort>>();//<国家ID,同对象总数>

    private Dictionary<ushort, ushort> teamID = new Dictionary<ushort, ushort>();      //<国家ID,队伍号>



    public Dictionary<ushort, Dictionary<UInt32, BaseMember>> CountryMem
    {
        get {
            return countryMems;
        }
    }

    public void AddCountryList(ushort countryID, ushort teamNum, BuildSystem buildSystem)
    {
        teamID.Add(countryID, teamNum);                                 //设定队伍信息

        countryMems.Add(countryID,new Dictionary<uint, BaseMember>());   //增加一个国家
        buildSystem.AddCountry(countryID);                               //为该国家增加“建筑系统
        GameOperation.gameOperation.GetInfoOperation.uIActiveInfoDict.Add(countryID,new UIActiveInfo());//为该国家增加“信息存储单元”
        countryIDCenter.Add(countryID,new IDNum());                      //为该国家增加“对象省份证”记录空间
        countrySametypeNum.Add(countryID,new Dictionary<ENUM_OBJECT_NAME, ushort>());           //为该国家增加“同类型对象数量”记录空间
    }
    public void AddMemInCountry(ushort countryID, BaseMember mem,uint memID, BuildSystem buildSystem)
    {
        mem.selfDataValue.m_data.m_u4IDNum = memID;                                     //为出生对象增加“对象省份证”信息
        ushort targetID = mem.selfDataValue.m_data.m_u2ID;

        countryMems[countryID].Add(memID, mem);                                         //将出生对象加入到对应国家中
        buildSystem.AddBuildForACountry(countryID, targetID, mem);    //将出生对象放入建筑系统检测是否为建筑并记录
        countryIDCenter[countryID].objects.Add(memID);                                  //将出生对象“对象省份证”信息存入
        countrySametypeNum[countryID][(ENUM_OBJECT_NAME)targetID]++;//将出生对象“同类型对象数”的个数累加
    }

    public void RemoveCountryList(ushort countryID)
    {
        countryMems.Remove(countryID);                                  //清除该国家所有信息
    }
    public void RemoveMemInCountry(ushort countryID, UInt32 memID, BuildSystem buildSystem)
    {
        ushort targetID = countryMems[countryID].TryGet(memID).selfDataValue.m_data.m_u2ID; 
        
        countrySametypeNum[countryID][(ENUM_OBJECT_NAME)targetID]--;    //将已毁灭对象“同类型对象数”的个数减少
        buildSystem.SubBuildForACountry(countryID, targetID, countryMems[countryID].TryGet(memID));           //将已毁灭对象放入建筑系统检测是否为建筑并记录
        countryMems[countryID].Remove(memID);                           //将已毁灭对象从对应国家中移除
        countryIDCenter[countryID].objectsDie.Add(memID);               //将已毁灭对象“对象省份证”从对应国家ID中心更新
    }

    //返回国家ID指定的国家信息
    public ObjectSystem GetObjectSystem(ushort countryID) {

        ObjectSystem objectSystem = new ObjectSystem(countryMems[countryID],countryIDCenter[countryID],countrySametypeNum[countryID],teamID[countryID]);
        return objectSystem;
    }
}
public class IDNum
{
    public List<UInt32> objects = new List<UInt32>();
    public List<UInt32> objectsDie = new List<UInt32>();
}