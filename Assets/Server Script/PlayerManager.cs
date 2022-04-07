using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int playerNum = 1;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int getPlayerNum()
    {
        return playerNum;
    }

    public void setPlayerNum(int num)
    {
        playerNum = num;
    }

}