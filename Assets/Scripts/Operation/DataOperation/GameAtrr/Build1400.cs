using GameAttrType;


public class Build1400 : ObjectDataValue
{
    public Build1400():base()
    {
        m_data.m_u8ID = 1400;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/SoliderBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/SoliderBuildHP";
        m_data.selfName = "士兵营";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产战士的基地，可激活士兵面板";

        m_atrr.m_u4AttackPlaneR = 20;
        m_atrr.m_u4Blood = 200;
        m_atrr.m_u4BloodY = 70;
        m_atrr.m_u4Concussion = 20;
        m_atrr.m_u4ConcussionY = 5;
        m_atrr.m_u4Laceration = 5;
        m_atrr.m_u4LacerationY = 0;
    }
}
