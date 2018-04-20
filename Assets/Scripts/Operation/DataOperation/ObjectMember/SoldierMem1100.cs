using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class SoldierMem1100 : FootSoldierMem
{
    public SoldierMem1100()
    {
        selfDataValue = new SoldierData1100();
    }
    public override void Init()
    {
        mLineRenderer = GetComponent<LineRenderer>();

        speed = selfDataValue.m_atrr.m_u2MoveSpeed;
        rotateSpeed = selfDataValue.m_atrr.m_u2RotateSpeed;
        cubeWatchRang = selfDataValue.m_atrr.m_u4AttackPlaneR;
    }

    public override void Updata()
    {
        base.Updata();
    }
    public override void Destroy()
    {
        base.Destroy();
    }

    public override BaseMember Clone()
    {
        return new SoldierMem1100();
    }
}
