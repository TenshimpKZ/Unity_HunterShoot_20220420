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

    public string prop;

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
        #region �P�_�� if
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
        #endregion

        #region �P�_�� switch
        switch (prop)
        {
            case "�����Ĥ�":
                print("�ɦ�");
                break;

            case "�Ŧ��Ĥ�":
                print("���]");
                break;

            case "�����Ĥ�":
                print("����O");
                break;

            default:
                break;
        }
        #endregion

        #region �P�_��switch���Xenum
        switch (statePlayer)
        {
            case StatePlayer.Idle:
                print("����");
                break;

            case StatePlayer.Walk:
                print("����");
                break;

            case StatePlayer.Run:
                print("�b�]");
                break;

            case StatePlayer.hurt:
                print("����");
                break;

            case StatePlayer.Attack:
                print("����");
                break;

            case StatePlayer.Dead:
                print("���`");
                break;
        }
        #endregion
    }

    #region enum:
    //1.�w�q�C�|���e
    //2.�w�q���
    public enum StatePlayer
    {
        Idle, Walk, Run, hurt, Attack, Dead
    }
    public StatePlayer statePlayer;
    #endregion
}
