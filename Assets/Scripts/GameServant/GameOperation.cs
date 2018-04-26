using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameAttrType;

public class GameOperation : MonoBehaviour
{
    #region SingletonPattern
    private static GameOperation _instance;
    public static GameOperation gameOperation
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameOperation();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject); return;
        }
        _instance = this;
    }
    #endregion

    private InfoOperation mInfoOperation;
    private ObjectOperation mObjectOperation;
    private CommandOperation mCommandOperation;

    private void Start()
    {
        InitOperation();
    }
    private void Update()
    {
        mInfoOperation.Update();
        //游戏对战开始后激活"对象系统"与"命令系统"
        if (mInfoOperation.gameProgressInfo.IsGamePlaying()) {

            mObjectOperation.Update();
            mCommandOperation.Update();
        }
    }
    private void InitOperation() {
        mInfoOperation = new InfoOperation(this);
        mObjectOperation = new ObjectOperation(this);
        mCommandOperation = new CommandOperation(this);

        mInfoOperation.Init();
        mObjectOperation.Init();
        mCommandOperation.Init();
    }
    private void OnDestroy()
    {
        mInfoOperation.Destroy();
        mObjectOperation.Destroy();
        mCommandOperation.Destroy();
    }

    #region ObjectOperation集合
    public void AddCountryList(ushort teamNum) {
        mObjectOperation.AddCountryList(teamNum);
    }
    public void AddMemInCountry(ushort idCountryCount, BaseMember mem) {
        mObjectOperation.AddMemInCountry(idCountryCount, mem);
    }
    public void RemoveCountryList(ushort idCountryCount){

        mObjectOperation.RemoveCountryList(idCountryCount);
    }
    public void RemoveMemInCountry(ushort idCountryCount, UInt32 memID){

        mObjectOperation.RemoveMemInCountry(idCountryCount, memID);
    }
    public UInt32 GetMemCount() {
        return mObjectOperation.MemCount;
    }
    public void GetCountryInfo() {
        mObjectOperation.GetCountryInfo();
    }
    public ushort GetBuildNumForACountry(ushort countryID, ENUM_BUILD_TYPE buildType) {
        return mObjectOperation.GetBuildNumForACountry(countryID, buildType);
    }
    public ushort[] GetAllCountryID()
    {
        return mObjectOperation.GetAllCountryID();
    }
    public CountrySystem GetCountrySystem()
    {
        return mObjectOperation.GetCountrySystem();
    }
    public List<BaseMember> GetBuildsForACountry(ushort countryID, ENUM_BUILD_TYPE buildType)
    {
        return mObjectOperation.GetBuildsForACountry(countryID, buildType);
    }
    #endregion

    #region InfoOPeration集合
    public InfoOperation GetInfoOperation
    {
        get{
            return mInfoOperation;
        }
    }
    #endregion



}
