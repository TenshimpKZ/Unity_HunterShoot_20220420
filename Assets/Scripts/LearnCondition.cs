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
    }
}
