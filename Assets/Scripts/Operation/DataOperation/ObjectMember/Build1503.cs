using System;
using System.Collections.Generic;
using System.Text;
using GameAttrType;
using UnityEngine;


public class Build1503 : BuildMem
{
    public Build1503()
    {
        selfDataValue = new BuildData1503();
    }

    public override BaseMember Clone()
    {
        return new Build1503();
    }

}
