using GameAttrType;

public class SoldierData1100:ObjectDataValue
{
    public SoldierData1100():base() {

        m_data.m_u2ID = 1100;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_PANLE_SOLIDER;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/CubeBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/CubePhoto";
        m_data.selfName = "召唤兵";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "就是普通战士";

        m_atrr.m_u4AttackPlaneR = 20;
        m_atrr.m_u4Blood = 200;
        m_atrr.m_u4BloodY = 70;
        m_atrr.m_u4Concussion = 20;
        m_atrr.m_u4ConcussionY = 5;
        m_atrr.m_u4Laceration = 5;
        m_atrr.m_u4LacerationY = 0;
        m_atrr.m_u2MakeTime = 2f;
        
    }
}
