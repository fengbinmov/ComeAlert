using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GameAttrType;


public class CommandOperation : BaseOperation
{
    private bool isAIInit = true;
    private Dictionary<ushort,AICountrysOperation> aiCountrys = new Dictionary<ushort, AICountrysOperation>();

    public CommandOperation(GameOperation gameOperation) : base(gameOperation) {}

    public override void Init()
    {

    }

    public override void Update()
    {
        BuildPanelActiveEvent();
        if (GameOperation.gameOperation.GetInfoOperation.gameProgressInfo.IsGamePlaying()) {
            if (isAIInit) {
                isAIInit = false;
                InitCountrysInfo();
            }
            foreach (AICountrysOperation country in aiCountrys.Values)
            {
                country.Update();
            }
        }
        
    }

    public override void Destroy()
    {

    }
    //检测所有国家的对应的建筑所激活的面板，并激活相应的面板事件
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
    private void InitCountrysInfo() {

        ushort[] allCounteyID = GameOperation.gameOperation.GetAllCountryID();
        for (int num = 0; allCounteyID[num] != 0; num++)
        {
            AICountrysOperation aICountry = new AICountrysOperation();
            aICountry.Init(GameOperation.gameOperation.GetCountrySystem().GetObjectSystem(allCounteyID[num]));
            aiCountrys.Add(allCounteyID[num], aICountry);
        }
    }
}          
