using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class CountrySystem
{
    //所有的国家信息[国家id、[对象id、对象代码]]
    private Dictionary<ushort,Dictionary<UInt32, BaseMember>> countryMems = new Dictionary<ushort, Dictionary<UInt32, BaseMember>>();
    private Dictionary<ushort, IDNum> countryIDCenter = new Dictionary<ushort, IDNum>();
    private Dictionary<ushort, ObjectTypeNum> countrySametypeNum = new Dictionary<ushort, ObjectTypeNum>();
    private Dictionary<ushort, ushort> teamID = new Dictionary<ushort, ushort>();      //队伍信息



    public Dictionary<ushort, Dictionary<UInt32, BaseMember>> CountryMem
    {
        get {
            return countryMems;
        }
    }

    public void AddCountryList(ushort countryID, ushort teamNum, BuildSystem buildSystem)
    {
        Debug.Log("AddCountryList[" + countryID + "]");
        teamID.Add(countryID, teamNum);                                 //设定队伍信息

        countryMems.Add(countryID,new Dictionary<uint, BaseMember>());   //增加一个国家
        buildSystem.AddCountry(countryID);                               //为该国家增加“建筑系统
        GameOperation.gameOperation.GetInfoOperation.uIActiveInfoDict.Add(countryID,new UIActiveInfo());//为该国家增加“信息存储单元”
        countryIDCenter.Add(countryID,new IDNum());                      //为该国家增加“对象省份证”记录空间
        countrySametypeNum.Add(countryID,new ObjectTypeNum());           //为该国家增加“同类型对象数量”记录空间
    }
    public void AddMemInCountry(ushort countryID, BaseMember mem,uint memID, BuildSystem buildSystem)
    {
        mem.selfDataValue.m_data.m_u4IDNum = memID;                                     //为出生对象增加“对象省份证”信息

        countryMems[countryID].Add(memID, mem);                                         //将出生对象加入到对应国家中
        buildSystem.AddBuildForACountry(countryID, mem.selfDataValue.m_data.m_u2ID);    //将出生对象放入建筑系统检测是否为建筑并记录
        countryIDCenter[countryID].objects.Add(memID);                                  //将出生对象“对象省份证”信息存入
        AddTypeNum(countryID, mem.selfDataValue.m_data.m_u2ID);                         //将出生对象“同类型对象数”的个数累加
    }

    public void RemoveCountryList(ushort countryID)
    {
        countryMems.Remove(countryID);                                  //清除该国家所有信息
    }
    public void RemoveMemInCountry(ushort countryID, UInt32 memID, BuildSystem buildSystem)
    {
        ushort targetID = countryMems[countryID].TryGet(memID).selfDataValue.m_data.m_u2ID;
        SubTypeNum(countryID, targetID);                                //将已毁灭对象“同类型对象数”的个数减少
        buildSystem.SubBuildForACountry(countryID, targetID);           //将已毁灭对象放入建筑系统检测是否为建筑并记录
        countryMems[countryID].Remove(memID);                           //将已毁灭对象从对应国家中移除
        countryIDCenter[countryID].objectsDie.Add(memID);               //将已毁灭对象“对象省份证”从对应国家ID中心更新
    }

    private void AddTypeNum(ushort countryID, UInt32 id)
    {

        switch (id)
        {
            case 1100:
                countrySametypeNum[countryID].Solider1100++;
                break;
            case 1101:
                countrySametypeNum[countryID].Solider1101++;
                break;
            case 1102:
                countrySametypeNum[countryID].Solider1102++;
                break;
            case 1103:
                countrySametypeNum[countryID].Solider1103++;
                break;
            case 1104:
                countrySametypeNum[countryID].Solider1104++;
                break;
            case 1105:
                countrySametypeNum[countryID].Solider1105++;
                break;
            case 1106:
                countrySametypeNum[countryID].Solider1106++;
                break;
            case 1107:
                countrySametypeNum[countryID].Solider1107++;
                break;
            case 1108:
                countrySametypeNum[countryID].Solider1108++;
                break;
            case 1200:
                countrySametypeNum[countryID].Solider1200++;
                break;
            case 1201:
                countrySametypeNum[countryID].Solider1201++;
                break;
            case 1202:
                countrySametypeNum[countryID].Solider1202++;
                break;
            case 1203:
                countrySametypeNum[countryID].Solider1203++;
                break;
            case 1204:
                countrySametypeNum[countryID].Solider1204++;
                break;
            case 1205:
                countrySametypeNum[countryID].Solider1205++;
                break;
            case 1206:
                countrySametypeNum[countryID].Solider1206++;
                break;
            case 1207:
                countrySametypeNum[countryID].Solider1207++;
                break;
            case 1300:
                countrySametypeNum[countryID].Solider1300++;
                break;
            case 1301:
                countrySametypeNum[countryID].Solider1301++;
                break;
            case 1302:
                countrySametypeNum[countryID].Solider1302++;
                break;
            case 1303:
                countrySametypeNum[countryID].Solider1303++;
                break;
            case 1304:
                countrySametypeNum[countryID].Solider1304++;
                break;
            case 1400:
                countrySametypeNum[countryID].Solider1400++;
                break;
            case 1401:
                countrySametypeNum[countryID].Solider1401++;
                break;
            case 1402:
                countrySametypeNum[countryID].Solider1402++;
                break;
            case 1403:
                countrySametypeNum[countryID].Solider1403++;
                break;
            case 1404:
                countrySametypeNum[countryID].Solider1404++;
                break;
            case 1405:
                countrySametypeNum[countryID].Solider1405++;
                break;
            case 1500:
                countrySametypeNum[countryID].build1500++;
                break;
            case 1501:
                countrySametypeNum[countryID].build1501++;
                break;
            case 1502:
                countrySametypeNum[countryID].build1502++;
                break;
            case 1503:
                countrySametypeNum[countryID].build1503++;
                break;
            case 1504:
                countrySametypeNum[countryID].build1504++;
                break;
            case 1505:
                countrySametypeNum[countryID].build1505++;
                break;
            case 1506:
                countrySametypeNum[countryID].build1506++;
                break;
            case 1507:
                countrySametypeNum[countryID].build1507++;
                break;
            case 1508:
                countrySametypeNum[countryID].build1508++;
                break;
            case 1509:
                countrySametypeNum[countryID].build1509++;
                break;
            case 1510:
                countrySametypeNum[countryID].build1510++;
                break;
            case 1511:
                countrySametypeNum[countryID].build1511++;
                break;
            case 1512:
                countrySametypeNum[countryID].build1512++;
                break;
            case 1513:
                countrySametypeNum[countryID].build1513++;
                break;
            case 1514:
                countrySametypeNum[countryID].build1514++;
                break;
            case 1515:
                countrySametypeNum[countryID].build1515++;
                break;
            case 1516:
                countrySametypeNum[countryID].build1516++;
                break;
            case 1517:
                countrySametypeNum[countryID].build1517++;
                break;
            case 1518:
                countrySametypeNum[countryID].build1518++;
                break;

            default:
                break;
        }
    }
    private void SubTypeNum(ushort countryID, UInt32 id)
    {

        switch (id)
        {
            case 1100:
                countrySametypeNum[countryID].Solider1100--;
                break;
            case 1101:
                countrySametypeNum[countryID].Solider1101--;
                break;
            case 1102:
                countrySametypeNum[countryID].Solider1102--;
                break;
            case 1103:
                countrySametypeNum[countryID].Solider1103--;
                break;
            case 1104:
                countrySametypeNum[countryID].Solider1104--;
                break;
            case 1105:
                countrySametypeNum[countryID].Solider1105--;
                break;
            case 1106:
                countrySametypeNum[countryID].Solider1106--;
                break;
            case 1107:
                countrySametypeNum[countryID].Solider1107--;
                break;
            case 1108:
                countrySametypeNum[countryID].Solider1108--;
                break;
            case 1200:
                countrySametypeNum[countryID].Solider1200--;
                break;
            case 1201:
                countrySametypeNum[countryID].Solider1201--;
                break;
            case 1202:
                countrySametypeNum[countryID].Solider1202--;
                break;
            case 1203:
                countrySametypeNum[countryID].Solider1203--;
                break;
            case 1204:
                countrySametypeNum[countryID].Solider1204--;
                break;
            case 1205:
                countrySametypeNum[countryID].Solider1205--;
                break;
            case 1206:
                countrySametypeNum[countryID].Solider1206--;
                break;
            case 1207:
                countrySametypeNum[countryID].Solider1207--;
                break;
            case 1300:
                countrySametypeNum[countryID].Solider1300--;
                break;
            case 1301:
                countrySametypeNum[countryID].Solider1301--;
                break;
            case 1302:
                countrySametypeNum[countryID].Solider1302--;
                break;
            case 1303:
                countrySametypeNum[countryID].Solider1303--;
                break;
            case 1304:
                countrySametypeNum[countryID].Solider1304--;
                break;
            case 1400:
                countrySametypeNum[countryID].Solider1400--;
                break;
            case 1401:
                countrySametypeNum[countryID].Solider1401--;
                break;
            case 1402:
                countrySametypeNum[countryID].Solider1402--;
                break;
            case 1403:
                countrySametypeNum[countryID].Solider1403--;
                break;
            case 1404:
                countrySametypeNum[countryID].Solider1404--;
                break;
            case 1405:
                countrySametypeNum[countryID].Solider1405--;
                break;
            case 1500:
                countrySametypeNum[countryID].build1500--;
                break;
            case 1501:
                countrySametypeNum[countryID].build1501--;
                break;
            case 1502:
                countrySametypeNum[countryID].build1502--;
                break;
            case 1503:
                countrySametypeNum[countryID].build1503--;
                break;
            case 1504:
                countrySametypeNum[countryID].build1504--;
                break;
            case 1505:
                countrySametypeNum[countryID].build1505--;
                break;
            case 1506:
                countrySametypeNum[countryID].build1506--;
                break;
            case 1507:
                countrySametypeNum[countryID].build1507--;
                break;
            case 1508:
                countrySametypeNum[countryID].build1508--;
                break;
            case 1509:
                countrySametypeNum[countryID].build1509--;
                break;
            case 1510:
                countrySametypeNum[countryID].build1510--;
                break;
            case 1511:
                countrySametypeNum[countryID].build1511--;
                break;
            case 1512:
                countrySametypeNum[countryID].build1512--;
                break;
            case 1513:
                countrySametypeNum[countryID].build1513--;
                break;
            case 1514:
                countrySametypeNum[countryID].build1514--;
                break;
            case 1515:
                countrySametypeNum[countryID].build1515--;
                break;
            case 1516:
                countrySametypeNum[countryID].build1516--;
                break;
            case 1517:
                countrySametypeNum[countryID].build1517--;
                break;
            case 1518:
                countrySametypeNum[countryID].build1518--;
                break;

            default:
                break;
        }
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
public class ObjectTypeNum
{
    //地面士兵
    public UInt16 Solider1100 = 0;
    public UInt16 Solider1101 = 0;
    public UInt16 Solider1102 = 0;
    public UInt16 Solider1103 = 0;
    public UInt16 Solider1104 = 0;
    public UInt16 Solider1105 = 0;
    public UInt16 Solider1106 = 0;
    public UInt16 Solider1107 = 0;
    public UInt16 Solider1108 = 0;

    //地面机械类
    public UInt16 Solider1200 = 0;
    public UInt16 Solider1201 = 0;
    public UInt16 Solider1202 = 0;
    public UInt16 Solider1203 = 0;
    public UInt16 Solider1204 = 0;
    public UInt16 Solider1205 = 0;
    public UInt16 Solider1206 = 0;
    public UInt16 Solider1207 = 0;

    //天空机械类
    public UInt16 Solider1300 = 0;
    public UInt16 Solider1301 = 0;
    public UInt16 Solider1302 = 0;
    public UInt16 Solider1303 = 0;
    public UInt16 Solider1304 = 0;

    //水体机械类
    public UInt16 Solider1400 = 0;
    public UInt16 Solider1401 = 0;
    public UInt16 Solider1402 = 0;
    public UInt16 Solider1403 = 0;
    public UInt16 Solider1404 = 0;
    public UInt16 Solider1405 = 0;

    //建筑
    public UInt16 build1500 = 0;
    public UInt16 build1501 = 0;
    public UInt16 build1502 = 0;
    public UInt16 build1503 = 0;
    public UInt16 build1504 = 0;
    public UInt16 build1505 = 0;
    public UInt16 build1506 = 0;
    public UInt16 build1507 = 0;
    public UInt16 build1508 = 0;
    public UInt16 build1509 = 0;
    public UInt16 build1510 = 0;
    public UInt16 build1511 = 0;
    public UInt16 build1512 = 0;
    public UInt16 build1513 = 0;
    public UInt16 build1514 = 0;
    public UInt16 build1515 = 0;
    public UInt16 build1516 = 0;
    public UInt16 build1517 = 0;
    public UInt16 build1518 = 0;
}