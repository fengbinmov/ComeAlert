using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class BuildData1502 : ObjectDataValue
{
    public BuildData1502() : base()
    {
        m_data.m_u2ID = 1502;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/SoliderBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/SoliderBuildHP";
        m_data.selfName = "士兵营";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "可训练士兵，并激活士兵面板";
    }
}
