using UnityEngine;

public class LearnAPIStatic : MonoBehaviour
{
/// <summary>
/// �ǲ��R�AAPI
/// �R�A Static
/// </summary>
    private void Start()
    {
        #region �m��
        
        //�R�A�ݩ�static properties
        //1. ���o get
        //�R�A�ݩʻy�k: ���O�W��.�R�A�ݩʦW��
        //print("�H���Ʀr: " + (Random.value));
        //print("�{�b�ù��e��: " + (Screen.width));
        //print("��P�v: " + (Mathf.PI));
        
        print("��v���ƶq : " + (Camera.allCamerasCount));

        print("�ثe���x : " + (Application.platform));

        //2.�]�w set (read only ����]�w)
        //�]�w�R�A�ݩʻy�k
        //���O�W��.�R�A�ݩʦW�� ���w �� ;
        //Screen.brightness = 0.7f;
        //Cursor.visible = false;

        Time.timeScale = 0.5f;


        //�R�A��k static methods
        //3. �ϥ�
        //���O�W��.�R�A��k�W��(�������޼�)
        //float r = Random.Range(1.1f, 22.2f);
        //print("�H���Ʀr: " + r);

        float f = Mathf.Floor(9.999f);
        print(f);

        Vector3 a = new Vector3(1.0f, 1.0f, 1.0f);
        Vector3 b = new Vector3(22.0f, 22.0f, 22.0f);
        float dis = Vector3.Distance(a, b);
        print("���I�Z����: " + dis);

        Application.OpenURL("https://unity.com/");
        #endregion

    }

    private void Update()
    {

        bool any = Input.anyKeyDown;
        print("�O�_��J���@����; " + any);

        float timeNow = Time.realtimeSinceStartup;
        print("�C���}�l�w�g�L�ɶ�: " + timeNow);

        bool downSpa = Input.GetKeyDown("space");
        print("�O�_���U�ť���: " + downSpa);


    }
}
