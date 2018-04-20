using GameAttrType;

public class BuildData1401 : ObjectDataValue
{
    public BuildData1401():base()
    {
        m_data.m_u2ID = 1401;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/CarBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/CarBuildHP";
        m_data.selfName = "机械厂";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产机械的基地，可激活机械面板";
    }
}
