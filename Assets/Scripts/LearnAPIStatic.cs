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
        Screen.brightness = 0.7f;
        Cursor.visible = false;
    }

}
