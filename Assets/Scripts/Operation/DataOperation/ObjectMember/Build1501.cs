using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Build1501 : BuildMem
{
    public Build1501()
    {
        selfDataValue = new BuildData1501();
    }
    public override BaseMember Clone()
    {
        return new Build1501();
    }
}
