using GameAttrType;


public class BuildData1501 : ObjectDataValue
{
    public BuildData1501():base()
    {
        m_data.m_u2ID = 1501;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectName = ENUM_OBJECT_NAME.B_POWER;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/";
        m_data.selfHeadP = "Images/ObjectHeadP/";
        m_data.selfName = "电站";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "生产电能";


        m_atrr.m_u2MakeTime = 2;
    }
}
