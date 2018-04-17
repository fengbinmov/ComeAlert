using GameAttrType;


public class Build1403 : ObjectDataValue
{
    public Build1403():base()
    {
        m_data.m_u8ID = 1403;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/WaterBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/WaterBuildHP";
        m_data.selfName = "海军船坞";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产水类机械的基地，可激活海军船坞面板";
    }
}
