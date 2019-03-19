using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static GameMgr Instance = null;
    private GameMgr() { }

    public static GameMgr getInst()
    {
        if (!Instance)
            Instance = new GameMgr();

        return Instance;
    }

    public void Awake()
    {
        Instance = this;    //Instance할당
    }
}
