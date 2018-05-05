using GameAttrType;


public class BuildData1500 : ObjectDataValue
{
    public BuildData1500():base()
    {
        m_data.m_u2ID = 1500;
        m_data.m_emObjectType = ENUM_OBJECT_TYPE.OBJECT_BUILD;
        m_data.m_emObjectName = ENUM_OBJECT_NAME.B_DEMOS;
        m_data.m_emObjectState = ENUM_OBJECT_STATE.OBJECT_DISPLAY_STATE;
        m_data.self = "Prefabs/Build/DemosBuild";
        m_data.selfHeadP = "Images/ObjectHeadP/DemosBuildHP";
        m_data.selfName = "社区";
        m_data.selfOutlay = "1111|2323|32423|233";
        m_data.selfIntroduce = "人民赖以生存的社区，可激活社区面板";


        m_atrr.m_u2MakeTime = 2;
    }
}
