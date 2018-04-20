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
                    GameControl.gameControl.PushPanel(UIPanelType.SoldierType);

                    GameOperation.gameOperation.AddMenList();
                    GameOperation.gameOperation.AddMenList();
                }

                break;
            default:
                break;

        }
    }
}
