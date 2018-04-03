using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**************************************************************
*     ----------开发者须知--------
*     1.面板资源从Resources/UIPanel/   开始解析
*     2.面板命名规范为 [UIPanelType]Panel
*     3.请将UIPanelType的名称与面板名开头保持一致,并且面板名必须以Panel结尾
*     4.UIManager面板资源解析形式为 UIPanel/[UIPanelType]Panel
*     
*     例子：
*       面板名：MainMenuPanel
*       UIPanelType:MainMenu
**************************************************************/
public enum UIPanelType{
    None,
    SoldierType,
    SelectItem
}
