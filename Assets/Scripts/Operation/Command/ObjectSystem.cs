using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class ObjectSystem
{
    private Dictionary<UInt32, BaseMember> countryMen = new Dictionary<uint, BaseMember>();
    private IDNum countryIDCenter = new IDNum();
    private ObjectTypeNum countrySametypeNum = new ObjectTypeNum();
    private ushort teamID = 0;      //队伍信息

    public ObjectSystem(Dictionary<UInt32, BaseMember> dict, IDNum ids, ObjectTypeNum typeNums, ushort team) {

        countryMen = dict;
        countryIDCenter = ids;
        countrySametypeNum = typeNums;
        teamID = team;
    }
}
