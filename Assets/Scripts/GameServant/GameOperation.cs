using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    private void Start()
    {
        InitOperation();
    }
    private void Update()
    {
        mInfoOperation.Update();
        mObjectOperation.Update();
    }
    private void InitOperation() {
        mInfoOperation = new InfoOperation(this);
        mObjectOperation = new ObjectOperation(this);

        mInfoOperation.Init();
        mObjectOperation.Init();
    }
    #region ObjectOperation集合

    public void AddMenList() {
        mObjectOperation.AddMenList(new Dictionary<uint, BaseMember>());
    }
    public void AddMem(int listNum, BaseMember mem) {
        mObjectOperation.AddMem(listNum, mem);
    }
    public void RemoveMenList(Dictionary<UInt32, BaseMember> memList) {
        mObjectOperation.RemoveMenList(memList);
    }
    public void RemoveMem(int listNum, UInt32 id){
        mObjectOperation.RemoveMem(listNum, id);
    }
    public UInt32 GetObjectCount() {
        return mObjectOperation.ObjectCount;
    }
    #endregion
    #region InfoOPeration集合

    public InfoOperation GetInfoOPeration
    {
        get{
            return mInfoOperation;
        }
    }
    #endregion



}
