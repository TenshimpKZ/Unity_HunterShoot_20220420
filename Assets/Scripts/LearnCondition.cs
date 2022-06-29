using UnityEngine;
/// <summary>
/// 判斷式(條件式)
/// 1.if
/// 2.switch
/// </summary>
public class LearnCondition : MonoBehaviour
{
    public bool openDoor;

    public int combo;

    public string prop;

    private void Start()
    {
        if (true)
        {
            print("我在判斷式if內");
        }
    }

    //如果openDoor等於true就開門，否則關門
    private void Update()
    {
        #region 判斷式 if
        if (openDoor)
        {
            print("開門");
        }
        else
        {
            print("關門");
        }

        if(combo < 100)
        {
            print("攻擊力 + 0%");
        }
        else if (combo >= 200)
        {
            print("攻擊力 + 20%");
        }
        else if (combo >= 100)
        {
            print("攻擊力 + 10%");
        }
        #endregion

        #region 判斷式 switch
        switch (prop)
        {
            case "紅色藥水":
                print("補血");
                break;

            case "藍色藥水":
                print("補魔");
                break;

            case "黃色藥水":
                print("補體力");
                break;

            default:
                break;
        }
        #endregion

        #region 判斷式switch結合enum
        switch (statePlayer)
        {
            case StatePlayer.Idle:
                print("等待");
                break;

            case StatePlayer.Walk:
                print("走路");
                break;

            case StatePlayer.Run:
                print("奔跑");
                break;

            case StatePlayer.hurt:
                print("受傷");
                break;

            case StatePlayer.Attack:
                print("攻擊");
                break;

            case StatePlayer.Dead:
                print("死亡");
                break;
        }
        #endregion
    }

    #region enum:
    //1.定義列舉內容
    //2.定義欄位
    public enum StatePlayer
    {
        Idle, Walk, Run, hurt, Attack, Dead
    }
    public StatePlayer statePlayer;
    #endregion
}
