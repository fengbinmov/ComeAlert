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
