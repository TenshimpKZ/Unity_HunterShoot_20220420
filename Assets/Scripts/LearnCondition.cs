using UnityEngine;
/// <summary>
/// �P�_��(����)
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
            print("�ڦb�P�_��if��");
        }
    }

    //�p�GopenDoor����true�N�}���A�_�h����
    private void Update()
    {
        if (openDoor)
        {
            print("�}��");
        }
        else
        {
            print("����");
        }

        if(combo < 100)
        {
            print("�����O + 0%");
        }
        else if (combo >= 200)
        {
            print("�����O + 20%");
        }
        else if (combo >= 100)
        {
            print("�����O + 10%");
        }
    }
}
