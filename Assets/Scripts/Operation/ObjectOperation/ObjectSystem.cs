using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class ObjectSystem
{
    //所有的国家信息  <省份证号,对象代码>>
    private Dictionary<uint, BaseMember> countryMems = new Dictionary<uint, BaseMember>();
    private IDNum countryIDCenter = new IDNum(); //<所有省份证号+死亡对象省份证号>
    //<对象类型,同对象总数>>
    private Dictionary<ENUM_OBJECT_NAME, ushort> countrySametypeNum;
    private ushort teamID;

    public ObjectSystem() {
        InitSametypeNum();
    }

    public Dictionary<UInt32, BaseMember> GetCountryAllMem(){
        return countryMems;
    }
    
    public void AddMemInCountry(BaseMember mem, uint memID)
    {
        mem.selfDataValue.m_data.m_u4IDNum = memID;         //为出生对象增加“对象省份证”信息
        ushort targetID = mem.selfDataValue.m_data.m_u2ID;
        countryMems.Add(memID, mem);                        //将出生对象加入到对应国家中
        countryIDCenter.objects.Add(memID);                 //将出生对象“对象省份证”信息存入
        countrySametypeNum[(ENUM_OBJECT_NAME)targetID]++;   //将出生对象“同类型对象数”的个数累加
    }
    public void RemoveMemInCountry(uint memID)
    {
        ushort targetID = countryMems.TryGet(memID).selfDataValue.m_data.m_u2ID;

        countrySametypeNum[(ENUM_OBJECT_NAME)targetID]--;    //将已毁灭对象“同类型对象数”的个数减少  
        countryMems.Remove(memID);                           //将已毁灭对象从对应国家中移除
        countryIDCenter.objectsDie.Add(memID);               //将已毁灭对象“对象省份证”从对应国家ID中心更新
    }
    public BaseMember GetMemForMemID(UInt32 memID)
    {

        if (countryMems.ContainsKey(memID))
            return countryMems[memID];
        else
        {
            Debug.Log("GetMemForMemID[" + memID + "]的结果为空");
            return null;
        }
    }
    private void InitSametypeNum()
    {

        countrySametypeNum = new Dictionary<ENUM_OBJECT_NAME, ushort>
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
        };
    }
}
public class IDNum
{
    public List<UInt32> objects = new List<UInt32>();
    public List<UInt32> objectsDie = new List<UInt32>();
}