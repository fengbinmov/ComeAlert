using System;
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
        Debug.Log("allCounteyID["+
            allCounteyID[0].ToString()+"、"+ 
            allCounteyID[1].ToString() + "、" +
            allCounteyID[2].ToString() + "、" +
            allCounteyID[3].ToString() + "、" +
            allCounteyID[4].ToString() + "、" +
            allCounteyID[5].ToString() + "、" +
            allCounteyID[6].ToString() + "、" +
            allCounteyID[7].ToString() + "、" +
            allCounteyID[8].ToString() + "、" +
            allCounteyID[9].ToString() + "]");
        for (int num = 0; allCounteyID[num] !=0 ; num++) {

            ushort[] activeArr = { 0, 0, 0, 0, 0 };
            ushort temp = 0;
            for (int i = 0; i < 6; i++)     //因为 id=1的为电站所以并不需要
            {
                if (i == 1) continue;
                if (i > 1) temp = 1;

                activeArr[i - temp] = GameOperation.gameOperation.GetBuildNumForACountry(allCounteyID[num], (ENUM_BUILD_TYPE)(i + 1500));
            }
            //GameOperation.gameOperation.GetInfoOPeration.uIActiveInfo.SetActivePanelInfo(activeArr);
            GameOperation.gameOperation.GetInfoOperation.uIActiveInfoDict[allCounteyID[num]].SetActivePanelInfo(activeArr);
        }
    }
}          
