﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class CommandOperation : BaseOperation
{
    public CommandOperation(GameOperation gameOperation) : base(gameOperation) {}

    public override void Init()
    {

    }

    public override void Update()
    {
        BuildPanelActiveEvent();
    }

    public override void Destroy()
    {

    }
    private void BuildPanelActiveEvent()
    {
        ushort[] allCounteyID = GameOperation.gameOperation.GetAllCountryID();
        //DeBugText(allCounteyID);
        for (int num = 0; allCounteyID[num] !=0 ; num++) {

            ushort[] activeArr = { 0, 0, 0, 0, 0 };
            ushort temp = 0;
            for (int i = 0; i < 6; i++)     //因为 id=1的为电站所以并不需要continue
            {
                if (i == 1) continue;
                if (i > 1) temp = 1;

                activeArr[i - temp] = GameOperation.gameOperation.GetBuildNumForACountry(allCounteyID[num], (ENUM_BUILD_TYPE)(i + 1500));
            }
            //GameOperation.gameOperation.GetInfoOPeration.uIActiveInfo.SetActivePanelInfo(activeArr);
            GameOperation.gameOperation.GetInfoOperation.uIActiveInfoDict[allCounteyID[num]].SetActivePanelInfo(activeArr);
        }
    }
    private void DeBugText(ushort[] allCounteyId) {
        Debug.Log("allCounteyID[" +
            allCounteyId[0].ToString() + "、" +
            allCounteyId[1].ToString() + "、" +
            allCounteyId[2].ToString() + "、" +
            allCounteyId[3].ToString() + "、" +
            allCounteyId[4].ToString() + "、" +
            allCounteyId[5].ToString() + "、" +
            allCounteyId[6].ToString() + "、" +
            allCounteyId[7].ToString() + "、" +
            allCounteyId[8].ToString() + "、" +
            allCounteyId[9].ToString() + "]");
    }
}          
