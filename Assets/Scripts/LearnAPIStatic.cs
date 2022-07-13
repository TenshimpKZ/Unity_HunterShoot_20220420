using UnityEngine;

public class LearnAPIStatic : MonoBehaviour
{
/// <summary>
/// �ǲ��R�AAPI
/// �R�A Static
/// </summary>
    private void Start()
    {
        //�R�A�ݩ�static properties
        //1. ���o get
        //�R�A�ݩʻy�k: ���O�W��.�R�A�ݩʦW��
        print("�H���Ʀr: " + (Random.value));
        print("�{�b�ù��e��: " + (Screen.width));
        print("��P�v: " + (Mathf.PI));

        //2.�]�w set (read only ����]�w)
        //�]�w�R�A�ݩʻy�k
        //���O�W��.�R�A�ݩʦW�� ���w �� ;
        Screen.brightness = 0.7f;
        Cursor.visible = false;

        //�R�A��k static methods
        //3. �ϥ�
        //���O�W��.�R�A��k�W��(�������޼�)
        float r = Random.Range(1.1f, 22.2f);
        print("�H���Ʀr: " + r);
    }

    private void Update()
    {
        bool downA = Input.GetKeyDown("a");
        print("�O�_���UA��: " + downA);
    }
}
