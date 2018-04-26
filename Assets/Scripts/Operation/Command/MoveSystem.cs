using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class MoveSystem
{
    private Vector3 targetPostion = Vector3.zero;
    private Dictionary<Transform, int> cubeDict = new Dictionary<Transform, int>();
    private List<Transform> selectCubeList = new List<Transform>();

    //设定士兵的移动目标位置
    public void SetTargetPostion(Vector3 postion)
    {
        targetPostion = postion;
    }
    //由Key得到士兵的移动目标位置
    public Vector3 GetTargetPostion(Transform cubeTransform)
    {
        return targetPostion;
    }

    #region 士兵选择的方法
    //添加要命令的士兵到选择队列
    public void AddSelectCube(Transform transform)
    {
        if (selectCubeList.IndexOf(transform) < 0)
        {
            selectCubeList.Add(transform);
        }
        else
        {
            Debug.LogWarning("[阻止]Cube的重复选择");
        }
    }
    //添加要命令的所有士兵到选择队列
    public void AddSelectCube(List<Transform> transformList)
    {
        selectCubeList = transformList;
    }
    //从选择队列移除不需要命令的士兵
    public void RemoveSelectListCube(Transform transform)
    {
        if (selectCubeList.IndexOf(transform) > -1)
        {
            selectCubeList.Remove(transform);
        }
        else
        {
            Debug.LogWarning("【阻止】该Cube并没被选择，无法取消");
        }
    }
    //返回选择队列
    public List<Transform> GetSelectListCube()
    {
        return selectCubeList;
    }
    //清空选择队列
    public void CleanSelectList()
    {
        selectCubeList.Clear();
    }
    #endregion

    //保存或更新我方的士兵信息
    public void AddCube(Transform transform, int count)
    {
        int num;
        if (cubeDict.TryGetValue(transform, out num))
        {
            cubeDict[transform] = count;
        }
        else
        {
            cubeDict.Add(transform, count);
        }
    }
    //移除我方死亡的士兵
    public void RemoveCube(Transform transform)
    {
        cubeDict.Remove(transform);
    }

    //得到选择队列中的中心士兵位置
    public Vector3 GetCenterCubePos
    {
        get
        {

            int max = int.MinValue;
            Transform transform = null;
            foreach (Transform t in selectCubeList)
            {
                if (cubeDict[t] > max)
                {
                    max = cubeDict[t];
                    transform = t;
                }
            }
            if (transform == null)
                Debug.LogWarning("致命错误！！GetCenterCube得到的值为NULL");
            return transform.position;
        }
    }
}
