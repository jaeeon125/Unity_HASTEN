using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private static GameMgr Instance = null;
    private GameMgr() { }
    //
    public PlayerState P_State;
    //

    public static GameMgr getInst()
    {
        if (!Instance)
            Instance = new GameMgr();

        return Instance;
    }

    public void Awake()
    {
        Instance = this;    //Instance할당
        this.Init();    //게임 처음 시작시 초기화
    }

    public void Start()
    {
        
    }

    public void Init()
    {
        P_State.StatusInit(100, 50, 10, 5, 10);
    }
}
