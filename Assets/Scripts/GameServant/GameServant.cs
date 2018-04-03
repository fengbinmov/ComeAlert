using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServant : MonoBehaviour {

    private GameControl gameControl;
    private GameOperation gameOperation;
    private void Awake()
    {
        gameControl = new GameControl();
        gameOperation = new GameOperation();
    }
    private void Start()
    {

    }
    private void Update()
    {
        
    }
}
