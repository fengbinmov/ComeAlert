using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameServant : MonoBehaviour {
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {

    }
    private void Update()
    {
        MySceneManager();
    }
    private void MySceneManager() {

        switch (SceneManager.GetActiveScene().buildIndex) {
            case 0:
                break;
            case 1:
                if (!GameControl.gameControl.ControlViewInstance){

                    GameControl.gameControl.ControlViewInstance = true;
                    GameControl.gameControl.CleanAllDict();
                    
                    GameOperation.gameOperation.AddCountryList(1);
                    GameOperation.gameOperation.AddCountryList(2);
                    GameOperation.gameOperation.GetCountryInfo();       //test专用
                    GameOperation.gameOperation.GetInfoOperation.gameProgressInfo.IsGamePlay = true;


                    GameControl.gameControl.PushPanel(UIPanelType.SoldierType);
                }

                break;
            default:
                break;

        }
    }
}
