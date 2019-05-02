using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMgr : MonoBehaviour
{
    private static GameMgr Instance = null;
    private GameMgr() { }
    //
    public GameObject ControllCanvas;
    public JoyStick Joystick;
    //
    public Transform P_Trans;
    public PlayerState P_State;
    //
    public BuildingMgr B_Mgr;
    public ItemManager I_Mgr;

    public Slider PlayerSlider;
    public Slider HPBar;
    public bool IsHPBarActive;

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
        P_Trans = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void Init()
    {
        P_State.StatusInit(100, 50, 10, 8, 10);
    }
}
