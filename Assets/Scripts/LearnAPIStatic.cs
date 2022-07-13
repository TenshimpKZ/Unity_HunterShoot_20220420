using UnityEngine;

public class LearnAPIStatic : MonoBehaviour
{
/// <summary>
/// 學習靜態API
/// 靜態 Static
/// </summary>
    private void Start()
    {
        //靜態屬性static properties
        //1. 取得 get
        //靜態屬性語法: 類別名稱.靜態屬性名稱
        print("隨機數字: " + (Random.value));
        print("現在螢幕寬度: " + (Screen.width));
        print("圓周率: " + (Mathf.PI));

        //2.設定 set (read only 不能設定)
        //設定靜態屬性語法
        //類別名稱.靜態屬性名稱 指定 值 ;
        Screen.brightness = 0.7f;
        Cursor.visible = false;

        //靜態方法 static methods
        //3. 使用
        //類別名稱.靜態方法名稱(對應的引數)
        float r = Random.Range(1.1f, 22.2f);
        print("隨機數字: " + r);
    }

    private void Update()
    {
        bool downA = Input.GetKeyDown("a");
        print("是否按下A鍵: " + downA);
    }
}
