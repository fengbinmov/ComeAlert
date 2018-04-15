using UnityEngine;
using GameAttrType;

public class Solider1101 : ObjectDataValue
{
    public Solider1101():base()
    {
        m_data.m_u8ID = 1101;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_PANLE_SOLIDER;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/CubeBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/CubePhoto1";
        m_data.selfName = "特种兵";
        m_data.selfOutlay = "2342|223|564|246";
        m_data.selfIntroduce = "就是经验比较丰富的战士";

        m_atrr.m_u4AttackPlaneR = 30;
        m_atrr.m_u4Blood = 350;
        m_atrr.m_u4BloodY = 95;
        m_atrr.m_u4Concussion = 600;
        m_atrr.m_u4ConcussionY = 10;
        m_atrr.m_u4Laceration = 15;
        m_atrr.m_u4LacerationY = 0;
        
    }
}
