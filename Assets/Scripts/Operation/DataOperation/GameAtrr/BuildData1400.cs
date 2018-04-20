using GameAttrType;


public class BuildData1400 : ObjectDataValue
{
    public BuildData1400():base()
    {
        m_data.m_u2ID = 1400;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/SoliderBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/SoliderBuildHP";
        m_data.selfName = "士兵营";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产战士的基地，可激活士兵面板";
    }
}
