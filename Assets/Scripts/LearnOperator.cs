using UnityEngine;


public class LearnOperator : MonoBehaviour
{
    private float a = 10;
    private float b = 3;

    private float c = 99;
    private float d = 1;

    private int dimond = 3;
    private int hp = 100;

    private void Start()
    {
        
        print("�[�k:" + (a + b));  //13
        print("��k:" + (a - b));  //7
        print("���k:" + (a * b));  //30
        print("���k:" + (a / b));  //3.3333
        print("�l�k:" + (a % b));  //1

        //����B��l�����G�����L��: true �B false
        print("�p��:" + (c < d));                  // false
        print("�j��:" + (c > d));                  // true
        print("�p�󵥩�:" + (c <= d));             // false
        print("�j�󵥩�:" + (c >= d));             // true
        print("������:" + (c != d));               // true
        print("����:" + (c == d));                 // false

        //�åB: ��ӥ��L�Ȧ��@�Ӭ�false�A���G�N�Ofalse
        print("true && true :" + (true && true));               // true
        print("true && false :" + (true && false));             // false
        print("false && true :" + (false && true));             // false
        print("false && false :" + (false && false));           // false
        //�άO: ��ӥ��L�Ȧ��@�Ӭ�true�A���G�N�Otrue
        print("true || true :" + (true || true));               // false
        print("true || false :" + (true || false));             // true
        print("false || true :" + (false || true));             // true
        print("false || false :" + (false || false));           // true

        //�C���d��:
        //�ӧQ����: �p�G�_�ۼƶq�j�󵥩�3�B��q�j��0�~��L��
        print("�O�_�q��: " + (dimond >= 3 && hp > 0));          //true

        //�A�˹B��l
        //�@��: �N���L���ܬۤ�
        print("!true: " + (!true));     //false
        print("!false: " + (!false));   //true
    }
    
}
