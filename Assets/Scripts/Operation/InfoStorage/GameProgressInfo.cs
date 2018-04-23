using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class GameProgressInfo
{
    private bool isGamePlay = false;
    private float playingTime;

    public bool IsGamePlaying()
    {
        return isGamePlay;
    }
    public bool IsGamePlay {

        set {
            isGamePlay = value;
            playingTime = Time.time;

        }
    }
}
