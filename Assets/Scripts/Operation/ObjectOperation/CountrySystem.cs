using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class CountrySystem
{
    //所有的国家信息  <国家ID,<省份证号,对象代码>>
    private Dictionary<ushort,Dictionary<UInt32, BaseMember>> countryMems = new Dictionary<ushort, Dictionary<UInt32, BaseMember>>();
    //<国家ID,所有省份证号+死亡对象省份证号>
    private Dictionary<ushort, IDNum> countryIDCenter = new Dictionary<ushort, IDNum>();
    //<国家ID,<对象类型,同对象总数>>
    private Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, ushort>> countrySametypeNum = new Dictionary<ushort, Dictionary<ENUM_OBJECT_NAME, ushort>>();
    //<国家ID,队伍号>
    private Dictionary<ushort, ushort> teamID = new Dictionary<ushort, ushort>();



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
        //delete
        GameOperation.gameOperation.GetInfoOperation.uIActiveInfoDict.Add(countryID,new UIActiveInfo());//为该国家增加“信息存储单元”
        countryIDCenter.Add(countryID,new IDNum());                      //为该国家增加“对象省份证”记录空间
        AddCountrySametypeNum(countryID);                               //为该国家增加“同类型对象数量”记录空间        
    }
    public void AddMemInCountry(ushort countryID, BaseMember mem,uint memID, BuildSystem buildSystem)
    {
        mem.selfDataValue.m_data.m_u4IDNum = memID;                                     //为出生对象增加“对象省份证”信息
        ushort targetID = mem.selfDataValue.m_data.m_u2ID;

        countryMems[countryID].Add(memID, mem);                                         //将出生对象加入到对应国家中
        
        countryIDCenter[countryID].objects.Add(memID);                                  //将出生对象“对象省份证”信息存入
        countrySametypeNum[countryID][(ENUM_OBJECT_NAME)targetID]++;//将出生对象“同类型对象数”的个数累加
        buildSystem.UpdateCountrySameBuildNum(countryID,countrySametypeNum[countryID]);//将出生对象放入建筑系统检测是否为建筑并记录
        buildSystem.AddCountryBuildNum(countryID, memID);
    }

    public void RemoveCountryList(ushort countryID)
    {
        countryMems.Remove(countryID);                                  //清除该国家所有信息
    }
    public void RemoveMemInCountry(ushort countryID, UInt32 memID, BuildSystem buildSystem)
    {
        ushort targetID = countryMems[countryID].TryGet(memID).selfDataValue.m_data.m_u2ID; 
        
        countrySametypeNum[countryID][(ENUM_OBJECT_NAME)targetID]--;    //将已毁灭对象“同类型对象数”的个数减少  
        buildSystem.UpdateCountrySameBuildNum(countryID, countrySametypeNum[countryID]);//将已毁灭对象放入建筑系统检测是否为建筑并记录
        buildSystem.SubCountryBuildNum(countryID, memID);
        countryMems[countryID].Remove(memID);                           //将已毁灭对象从对应国家中移除
        countryIDCenter[countryID].objectsDie.Add(memID);               //将已毁灭对象“对象省份证”从对应国家ID中心更新
    }
    private void AddCountrySametypeNum(ushort countryID) {

        countrySametypeNum.Add(countryID, new Dictionary<ENUM_OBJECT_NAME, ushort>
        {
            { ENUM_OBJECT_NAME.Z_NENGSHI,0 },
            { ENUM_OBJECT_NAME.Z_JINSHU,0 },
            { ENUM_OBJECT_NAME.Z_ZHINENG,0 },
            { ENUM_OBJECT_NAME.Z_XINENG,0 },
            { ENUM_OBJECT_NAME.F_BUBING,0 },
            { ENUM_OBJECT_NAME.F_TEZHONG,0 },
            { ENUM_OBJECT_NAME.F_FANGKONG,0 },
            { ENUM_OBJECT_NAME.F_NATASHA,0 },
            { ENUM_OBJECT_NAME.F_GONGCHENG,0 },
            { ENUM_OBJECT_NAME.F_YILIAO,0 },
            { ENUM_OBJECT_NAME.F_GOU,0 },
            { ENUM_OBJECT_NAME.F_FANJIA,0 },
            { ENUM_OBJECT_NAME.F_CIBAO,0 },
            { ENUM_OBJECT_NAME.C_ZHENCHA,0 },
            { ENUM_OBJECT_NAME.C_ZHUANGJIA,0 },
            { ENUM_OBJECT_NAME.C_TANKE,0 },
            { ENUM_OBJECT_NAME.C_TIANQI,0 },
            { ENUM_OBJECT_NAME.C_FANGKONG,0 },
            { ENUM_OBJECT_NAME.C_HUOJIAN,0 },
            { ENUM_OBJECT_NAME.C_JIHUANG,0 },
            { ENUM_OBJECT_NAME.C_HEDAN,0 },
            { ENUM_OBJECT_NAME.A_ZHENCHA,0 },
            { ENUM_OBJECT_NAME.A_ZHISHENG,0 },
            { ENUM_OBJECT_NAME.A_ZHANDOU,0 },
            { ENUM_OBJECT_NAME.A_YUNSHU,0 },
            { ENUM_OBJECT_NAME.A_YUJING,0 },
            { ENUM_OBJECT_NAME.W_KUAITING,0 },
            { ENUM_OBJECT_NAME.W_ZAIJU,0 },
            { ENUM_OBJECT_NAME.W_YUNSHU,0 },
            { ENUM_OBJECT_NAME.W_ZHANJIAN,0 },
            { ENUM_OBJECT_NAME.W_HANGMU,0 },
            { ENUM_OBJECT_NAME.W_QIANTING,0 },
            { ENUM_OBJECT_NAME.B_DEMOS,0 },
            { ENUM_OBJECT_NAME.B_POWER,0 },
            { ENUM_OBJECT_NAME.B_SOLDIER,0 },
            { ENUM_OBJECT_NAME.B_ZHANZHENG,0 },
            { ENUM_OBJECT_NAME.B_WATER,0 },
            { ENUM_OBJECT_NAME.B_AIR,0 },
            { ENUM_OBJECT_NAME.B_ZHIHUI,0 },
            { ENUM_OBJECT_NAME.B_SCHOOL,0 },
            { ENUM_OBJECT_NAME.B_KEXUE,0 },
            { ENUM_OBJECT_NAME.B_ZHENFU,0 },
            { ENUM_OBJECT_NAME.B_JINGWEI,0 },
            { ENUM_OBJECT_NAME.B_MAOYI,0 },
            { ENUM_OBJECT_NAME.B_YULE,0 },
            { ENUM_OBJECT_NAME.B_TEZHONG,0 },
            { ENUM_OBJECT_NAME.B_WEIQIANG,0 },
            { ENUM_OBJECT_NAME.B_SHAOJIE,0 },
            { ENUM_OBJECT_NAME.B_DIAOBAO,0 },
            { ENUM_OBJECT_NAME.B_DIAOBAOG,0 },
            { ENUM_OBJECT_NAME.B_TIBA,0 }
        });
    }
    //返回国家ID指定的国家信息
    public ObjectSystem GetObjectSystem(ushort countryID)
    {

        ObjectSystem objectSystem = new ObjectSystem(countryMems[countryID], countryIDCenter[countryID], countrySametypeNum[countryID], teamID[countryID]);
        return objectSystem;
    }
    public BaseMember GetMemForMemID(ushort countryID, UInt32 memID) {

        if (countryMems[countryID].ContainsKey(memID))
            return countryMems[countryID][memID];
        else
            return null;
    }
}
public class IDNum
{
    public List<UInt32> objects = new List<UInt32>();
    public List<UInt32> objectsDie = new List<UInt32>();
}