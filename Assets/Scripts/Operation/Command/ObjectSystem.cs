using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class ObjectSystem
{
    private Dictionary<UInt32, BaseMember> countryMen = new Dictionary<uint, BaseMember>();
    private IDNum countryIDCenter = new IDNum();
    private Dictionary<ENUM_OBJECT_NAME, ushort> countrySametypeNum = new Dictionary<ENUM_OBJECT_NAME, ushort>();
    private ushort teamID = 0;      //队伍信息

    public ObjectSystem(Dictionary<UInt32, BaseMember> dict, IDNum ids, Dictionary<ENUM_OBJECT_NAME, ushort> typeNums, ushort team) {

        countryMen = dict;
        countryIDCenter = ids;
        countrySametypeNum = typeNums;
        teamID = team;
    }
}
