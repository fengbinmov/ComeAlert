using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class ObjectOperation : BaseOperation
{
    public ObjectOperation(GameOperation gameOperation) : base(gameOperation) { }

    private UInt32 iDNumCount = 0;
    private List<Dictionary<UInt32, BaseMember>> memObjects = new List<Dictionary<UInt32, BaseMember>>();
    private List<IDNum> CountryIDNum = new List<IDNum>(); 
    private List<ObjectTypeNum> CountryTypeNum = new List<ObjectTypeNum>();


    public void AddMenList(Dictionary<UInt32, BaseMember> memList){
        memObjects.Add(memList);
        CountryIDNum.Add(new IDNum());
        CountryTypeNum.Add(new ObjectTypeNum());
    }
    public void AddMem(int listNum, BaseMember mem){
        iDNumCount++;

        //更新士兵省份证ID的信息
        mem.selfDataValue.m_data.m_u4IDNum = iDNumCount;

        memObjects[listNum].Add(iDNumCount, mem);
        CountryIDNum[listNum].objects.Add(iDNumCount);
        AddTypeNum(listNum, mem.selfDataValue.m_data.m_u2ID);
    }

    public void RemoveMenList(Dictionary<UInt32, BaseMember> memList){
        memObjects.Remove(memList);
    }
    public void RemoveMem(int listNum, UInt32 id){

        SubTypeNum(listNum, memObjects[listNum].TryGet(id).selfDataValue.m_data.m_u2ID);
        memObjects[listNum].Remove(id);
        CountryIDNum[listNum].objectsDie.Add(id);
    }


    public override void Init()
    {
        base.Init();
        foreach (Dictionary<UInt32, BaseMember> mems in memObjects)
        {
            foreach (BaseMember mem in mems.Values)
            {
                mem.Init();
            }
        }
    }
    public override void Update()
    {
        foreach (Dictionary<UInt32, BaseMember> mems in memObjects)
        {
            foreach (BaseMember mem in mems.Values)
            {
                mem.Updata();
            }
        }
    }
    public override void Destroy()
    {
        base.Destroy();
        foreach (Dictionary<UInt32, BaseMember> mems in memObjects)
        {
            foreach (BaseMember mem in mems.Values)
            {
                mem.Destroy();
            }
        }
    }

    private void AddTypeNum(int listNum, UInt32 id) {

        switch (id) {
            case 1100:
                CountryTypeNum[listNum].Solider1100++;
                break;
            case 1101:
                CountryTypeNum[listNum].Solider1101++;
                break;
            case 1102:
                CountryTypeNum[listNum].Solider1102++;
                break;
            case 1103:
                CountryTypeNum[listNum].Solider1103++;
                break;
            case 1104:
                CountryTypeNum[listNum].Solider1104++;
                break;
            case 1105:
                CountryTypeNum[listNum].Solider1105++;
                break;
            case 1106:
                CountryTypeNum[listNum].Solider1106++;
                break;
            case 1107:
                CountryTypeNum[listNum].Solider1107++;
                break;
            case 1108:
                CountryTypeNum[listNum].Solider1108++;
                break;
            case 1200:
                CountryTypeNum[listNum].Solider1200++;
                break;
            case 1201:
                CountryTypeNum[listNum].Solider1201++;
                break;
            case 1202:
                CountryTypeNum[listNum].Solider1202++;
                break;
            case 1203:
                CountryTypeNum[listNum].Solider1203++;
                break;
            case 1204:
                CountryTypeNum[listNum].Solider1204++;
                break;
            case 1205:
                CountryTypeNum[listNum].Solider1205++;
                break;
            case 1206:
                CountryTypeNum[listNum].Solider1206++;
                break;
            case 1207:
                CountryTypeNum[listNum].Solider1207++;
                break;
            case 1300:
                CountryTypeNum[listNum].Solider1300++;
                break;
            case 1301:
                CountryTypeNum[listNum].Solider1301++;
                break;
            case 1302:
                CountryTypeNum[listNum].Solider1302++;
                break;
            case 1303:
                CountryTypeNum[listNum].Solider1303++;
                break;
            case 1304:
                CountryTypeNum[listNum].Solider1304++;
                break;
            case 1400:
                CountryTypeNum[listNum].Solider1400++;
                break;
            case 1401:
                CountryTypeNum[listNum].Solider1401++;
                break;
            case 1402:
                CountryTypeNum[listNum].Solider1402++;
                break;
            case 1403:
                CountryTypeNum[listNum].Solider1403++;
                break;
            case 1404:
                CountryTypeNum[listNum].Solider1404++;
                break;
            case 1405:
                CountryTypeNum[listNum].Solider1405++;
                break;
            case 1500:
                CountryTypeNum[listNum].build1500++;
                break;
            case 1501:
                CountryTypeNum[listNum].build1501++;
                break;
            case 1502:
                CountryTypeNum[listNum].build1502++;
                break;
            case 1503:
                CountryTypeNum[listNum].build1503++;
                break;
            case 1504:
                CountryTypeNum[listNum].build1504++;
                break;
            case 1505:
                CountryTypeNum[listNum].build1505++;
                break;
            case 1506:
                CountryTypeNum[listNum].build1506++;
                break;
            case 1507:
                CountryTypeNum[listNum].build1507++;
                break;
            case 1508:
                CountryTypeNum[listNum].build1508++;
                break;
            case 1509:
                CountryTypeNum[listNum].build1509++;
                break;
            case 1510:
                CountryTypeNum[listNum].build1510++;
                break;
            case 1511:
                CountryTypeNum[listNum].build1511++;
                break;
            case 1512:
                CountryTypeNum[listNum].build1512++;
                break;
            case 1513:
                CountryTypeNum[listNum].build1513++;
                break;
            case 1514:
                CountryTypeNum[listNum].build1514++;
                break;
            case 1515:
                CountryTypeNum[listNum].build1515++;
                break;
            case 1516:
                CountryTypeNum[listNum].build1516++;
                break;
            case 1517:
                CountryTypeNum[listNum].build1517++;
                break;
            case 1518:
                CountryTypeNum[listNum].build1518++;
                break;

            default:
                break;
        }
    }
    private void SubTypeNum(int listNum, UInt32 id)
    {

        switch (id)
        {
            case 1100:
                CountryTypeNum[listNum].Solider1100--;
                break;
            case 1101:
                CountryTypeNum[listNum].Solider1101--;
                break;
            case 1102:
                CountryTypeNum[listNum].Solider1102--;
                break;
            case 1103:
                CountryTypeNum[listNum].Solider1103--;
                break;
            case 1104:
                CountryTypeNum[listNum].Solider1104--;
                break;
            case 1105:
                CountryTypeNum[listNum].Solider1105--;
                break;
            case 1106:
                CountryTypeNum[listNum].Solider1106--;
                break;
            case 1107:
                CountryTypeNum[listNum].Solider1107--;
                break;
            case 1108:
                CountryTypeNum[listNum].Solider1108--;
                break;
            case 1200:
                CountryTypeNum[listNum].Solider1200--;
                break;
            case 1201:
                CountryTypeNum[listNum].Solider1201--;
                break;
            case 1202:
                CountryTypeNum[listNum].Solider1202--;
                break;
            case 1203:
                CountryTypeNum[listNum].Solider1203--;
                break;
            case 1204:
                CountryTypeNum[listNum].Solider1204--;
                break;
            case 1205:
                CountryTypeNum[listNum].Solider1205--;
                break;
            case 1206:
                CountryTypeNum[listNum].Solider1206--;
                break;
            case 1207:
                CountryTypeNum[listNum].Solider1207--;
                break;
            case 1300:
                CountryTypeNum[listNum].Solider1300--;
                break;
            case 1301:
                CountryTypeNum[listNum].Solider1301--;
                break;
            case 1302:
                CountryTypeNum[listNum].Solider1302--;
                break;
            case 1303:
                CountryTypeNum[listNum].Solider1303--;
                break;
            case 1304:
                CountryTypeNum[listNum].Solider1304--;
                break;
            case 1400:
                CountryTypeNum[listNum].Solider1400--;
                break;
            case 1401:
                CountryTypeNum[listNum].Solider1401--;
                break;
            case 1402:
                CountryTypeNum[listNum].Solider1402--;
                break;
            case 1403:
                CountryTypeNum[listNum].Solider1403--;
                break;
            case 1404:
                CountryTypeNum[listNum].Solider1404--;
                break;
            case 1405:
                CountryTypeNum[listNum].Solider1405--;
                break;
            case 1500:
                CountryTypeNum[listNum].build1500--;
                break;
            case 1501:
                CountryTypeNum[listNum].build1501--;
                break;
            case 1502:
                CountryTypeNum[listNum].build1502--;
                break;
            case 1503:
                CountryTypeNum[listNum].build1503--;
                break;
            case 1504:
                CountryTypeNum[listNum].build1504--;
                break;
            case 1505:
                CountryTypeNum[listNum].build1505--;
                break;
            case 1506:
                CountryTypeNum[listNum].build1506--;
                break;
            case 1507:
                CountryTypeNum[listNum].build1507--;
                break;
            case 1508:
                CountryTypeNum[listNum].build1508--;
                break;
            case 1509:
                CountryTypeNum[listNum].build1509--;
                break;
            case 1510:
                CountryTypeNum[listNum].build1510--;
                break;
            case 1511:
                CountryTypeNum[listNum].build1511--;
                break;
            case 1512:
                CountryTypeNum[listNum].build1512--;
                break;
            case 1513:
                CountryTypeNum[listNum].build1513--;
                break;
            case 1514:
                CountryTypeNum[listNum].build1514--;
                break;
            case 1515:
                CountryTypeNum[listNum].build1515--;
                break;
            case 1516:
                CountryTypeNum[listNum].build1516--;
                break;
            case 1517:
                CountryTypeNum[listNum].build1517--;
                break;
            case 1518:
                CountryTypeNum[listNum].build1518--;
                break;

            default:
                break;
        }
    }

    public UInt32 ObjectCount {
        get
        {
            return iDNumCount;
        }
    }
}
public class IDNum{
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