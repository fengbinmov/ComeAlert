using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOperation :MonoBehaviour
{
    #region SingletonPattern
    private static GameOperation _instance;
    public static GameOperation masterCube
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

    private void Start()
    {
        InitOperation();
    }
    private void Update()
    {
        
    }
    private void InitOperation() {
    }

    
}
