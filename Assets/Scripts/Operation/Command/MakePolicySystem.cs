using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

enum Policy {
    NONE = 0,
    DEVELOP=001,
    ATTACK =010,
    DEFENSE = 100
}
enum AttackType
{
    NONE = 0,
    PLANE = 001,
    WATER = 010,
    AIR = 100
}
public class MakePolicySystem
{
    //世界资源比值 [能 ,金 ,脂 ,稀]
    float[] resourceWord = { 0.3f, 0.2f, 0.4f, 0.1f };

    //现有资源比值 [能 ,金 ,脂 ,稀]
    float[] resourceSelfNow = { 0.3f, 0.2f, 0.4f, 0.1f };

    //世界资源比-现有资源量之比 = 资源贵重值
    //决策权值 [能 ,金 ,脂 ,稀] 资源贵重值
    float[] resourceRatio = { 0.25f, 0.25f, 0.25f, 0.25f };

    //决策权值 [养，养攻，养防，攻，攻防，防，养攻防] 决策方式
    float[] policyType = { 0.14f, 0.14f, 0.14f, 0.14f, 0.14f, 0.14f };
    Policy mPolicy = Policy.NONE;

    //决策权值 [养,攻,防] 占比
    float[] soldierRatio = { 0.6f, 0.2f, 0.2f };

    //决策权值 [地，地海，地空，海，海空，空,地海空] 出兵方式
    float[] attackType = { 0.14f, 0.14f, 0.14f, 0.14f, 0.14f, 0.14f };
    AttackType mAttackType = AttackType.NONE;

    //决策权值 出兵队伍量
    ushort IteamCount = 1;

    //决策权值 出兵队伍量增减比
    float IteamCountRatio = 0.5f;

    //决策权值 出兵总数量
    ushort soldierCount = 5;

    //决策权值 出兵总数量增减比
    float soldierCountRatio = 0.5f;

    //决策权值 [地面士兵，海洋士兵，天空士兵] 出兵数量比
    float[] soldierOutRatio = { 0.6f, 0.3f, 0.1f };



    //初始化世界资源值
    private void GetResourceWord()
    {
        //TODO
    }
    private void UpdateResourceRatio()
    {
        //TODO
        for (int i = 0; i < resourceSelfNow.Length; i++) {
            resourceRatio[i] = resourceWord[i] - resourceSelfNow[i];
        }
    }
    private void UpdatePolicyType()
    {
        //TODO

    }
    private void UpdateSoldierRatio()
    {
        //TODO
    }
    private void UpdateAttackType()
    {
        //TODO
    }
    private void UpdateIteamCount()
    {
        //TODO
    }
    private void UpdateIteamCountRatio()
    {
        //TODO
    }
    private void UpdateSoldierCount()
    {
        //TODO
    }
    private void UpdateSoldierCountRatio()
    {
        //TODO
    }
    private void UpdateSoldierOutRatio()
    {
        //TODO
    }
}
