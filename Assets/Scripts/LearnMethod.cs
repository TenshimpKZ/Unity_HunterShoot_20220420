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

        Shoot("火球");
        Shoot("冰球");
        Shoot("電球", "滋滋滋");
        Shoot("雪球", effect: "雪花");

        Attack(50);
        Attack(20, "火球");
    }

    #region 方法練習
    private void Test()
    {
        print("konoDIOda!");
    }

    private void PrintColorText()
    {
        print("<color=#550055>紫色文字</color>");
    }

    private void PrintSizeText()
    {
        print("<size=50pt>大文字</size>");
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
        print("發射火球");
        print("播放音效");
    }

    private void ShootLighint()
    {
        print("發射電球");
        print("播放音效");
    }

    //有預設值的參數必須放在最右邊
    private void Shoot(string type, string sound = "咻咻咻", string effect = "煙霧")
    {
        print("發射:" + type);
        print("音效:" + sound);
        print("特效:" + effect);
    }

    private void Attack(float atk)
    {
        print("近距離攻擊，傷害值:" + atk);
    }

    private void Attack(float atk, string fireball)
    {
        print("遠距離攻擊，傷害值:" + atk);
        print("發射:" + fireball);
    }
}
