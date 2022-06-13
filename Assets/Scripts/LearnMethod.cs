using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    private void Start()
    {
        Test();
        PrintColorText();
        PrintSizeText();

        print(ReturnTen());

        print(Calculate());

        Shoot("���y");
        Shoot("�B�y");
        Shoot("�q�y", "������");
        Shoot("���y", effect: "����");

        Attack(50);
        Attack(20, "���y");
    }

    #region ��k�m��
    private void Test()
    {
        print("konoDIOda!");
    }

    private void PrintColorText()
    {
        print("<color=#550055>�����r</color>");
    }

    private void PrintSizeText()
    {
        print("<size=50pt>�j��r</size>");
    }

    private int ReturnTen()
    {
        return 10;
    }

    public int countProduct = 10;
    public int countPrice = 99;

    private int Calculate()
    {
        return countPrice * countProduct;
    }
    #endregion

    private void ShootFire()
    {
        print("�o�g���y");
        print("���񭵮�");
    }

    private void ShootLighint()
    {
        print("�o�g�q�y");
        print("���񭵮�");
    }

    //���w�]�Ȫ��Ѽƥ�����b�̥k��
    private void Shoot(string type, string sound = "������", string effect = "����")
    {
        print("�o�g:" + type);
        print("����:" + sound);
        print("�S��:" + effect);
    }

    private void Attack(float atk)
    {
        print("��Z�������A�ˮ`��:" + atk);
    }

    private void Attack(float atk, string fireball)
    {
        print("���Z�������A�ˮ`��:" + atk);
        print("�o�g:" + fireball);
    }
}
