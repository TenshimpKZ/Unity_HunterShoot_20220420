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
        Screen.brightness = 0.7f;
        Cursor.visible = false;
    }

}
