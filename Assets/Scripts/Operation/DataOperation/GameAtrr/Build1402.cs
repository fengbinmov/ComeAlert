using GameAttrType;


public class Build1402 : ObjectDataValue
{
    public Build1402():base()
    {
        m_data.m_u8ID = 1402;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/AirBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/AirBuildHP";
        m_data.selfName = "机厂";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产空中机械的基地，可激活机厂面板";
    }
}
