using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class CommandControl : BaseControl
{
    public CommandControl(GameControl gameControl) : base(gameControl){ }

    private MoveSystem mMoveSystem = new MoveSystem();



    //设定士兵的移动目标位置
    public void SetTargetPostion(Vector3 postion)
    {
        mMoveSystem.SetTargetPostion(postion);
    }
    //由Key得到士兵的移动目标位置
    public Vector3 GetTargetPostion(Transform cubeTransform)
    {
        return mMoveSystem.GetTargetPostion(cubeTransform);
    }

    #region 士兵选择的方法
    //添加要命令的士兵到选择队列
    public void AddSelectCube(Transform transform)
    {
        mMoveSystem.AddSelectCube(transform);
    }
    //添加要命令的所有士兵到选择队列
    public void AddSelectCube(List<Transform> transformList)
    {
        mMoveSystem.AddSelectCube(transformList);
    }
    //从选择队列移除不需要命令的士兵
    public void RemoveSelectListCube(Transform transform)
    {
        mMoveSystem.RemoveSelectListCube(transform);
    }
    //返回选择队列
    public List<Transform> GetSelectListCube()
    {
        return mMoveSystem.GetSelectListCube();
    }
    //清空选择队列
    public void CleanSelectList()
    {
        mMoveSystem.CleanSelectList();
    }
    #endregion

    //保存或更新我方的士兵信息
    public void AddCube(Transform transform, int count)
    {
        mMoveSystem.AddCube(transform, count);
    }
    //移除我方死亡的士兵
    public void RemoveCube(Transform transform)
    {
        mMoveSystem.RemoveCube(transform);
    }

    //得到选择队列中的中心士兵位置
    public Vector3 GetCenterCubePos{
        get{
            return mMoveSystem.GetCenterCubePos;
        }
    }

}
