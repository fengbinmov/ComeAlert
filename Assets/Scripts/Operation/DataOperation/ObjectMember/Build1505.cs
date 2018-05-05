using System;
using System.Collections.Generic;
using System.Text;
using GameAttrType;
using UnityEngine;


public class Build1505 : BuildMem
{
    public Build1505()
    {
        selfDataValue = new BuildData1505();
    }

    public override BaseMember Clone()
    {
        return new Build1505();
    }

}
