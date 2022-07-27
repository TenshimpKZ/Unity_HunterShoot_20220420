using UnityEngine;

public class LearnAPIStatic : MonoBehaviour
{
/// <summary>
/// 學習靜態API
/// 靜態 Static
/// </summary>
    private void Start()
    {
        #region 練習
        
        //靜態屬性static properties
        //1. 取得 get
        //靜態屬性語法: 類別名稱.靜態屬性名稱
        //print("隨機數字: " + (Random.value));
        //print("現在螢幕寬度: " + (Screen.width));
        //print("圓周率: " + (Mathf.PI));
        
        print("攝影機數量 : " + (Camera.allCamerasCount));

        print("目前平台 : " + (Application.platform));

        //2.設定 set (read only 不能設定)
        //設定靜態屬性語法
        //類別名稱.靜態屬性名稱 指定 值 ;
        //Screen.brightness = 0.7f;
        //Cursor.visible = false;

        Time.timeScale = 0.5f;


        //靜態方法 static methods
        //3. 使用
        //類別名稱.靜態方法名稱(對應的引數)
        //float r = Random.Range(1.1f, 22.2f);
        //print("隨機數字: " + r);

        float f = Mathf.Floor(9.999f);
        print(f);

        Vector3 a = new Vector3(1.0f, 1.0f, 1.0f);
        Vector3 b = new Vector3(22.0f, 22.0f, 22.0f);
        float dis = Vector3.Distance(a, b);
        print("兩點距離為: " + dis);

        Application.OpenURL("https://unity.com/");
        #endregion

    }

    private void Update()
    {

        bool any = Input.anyKeyDown;
        print("是否輸入任一按鍵; " + any);

        float timeNow = Time.realtimeSinceStartup;
        print("遊戲開始已經過時間: " + timeNow);

        bool downSpa = Input.GetKeyDown("space");
        print("是否按下空白鍵: " + downSpa);


    }
}
