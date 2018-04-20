using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMem1101 : FootSoldierMem
{
    public SoldierMem1101()
    {
        selfDataValue = new SoldierData1101();
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
        return new SoldierMem1101(); 
    }
}
