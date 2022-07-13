using UnityEngine;
/// <summary>
/// 學習 非靜態 API
/// API文件上 沒有 static
/// </summary>
public class LearmAPINonStatic : MonoBehaviour
{
    public Transform traA;
    public Light lightA;
    public Transform traB;

    private void Start()
    {
        //非靜態屬性 properties
        //1.取得 get
        //條件:
        // - 該類別類型欄位
        // - 實體物件
        // - 欄位存放該實體物件
        //欄位名稱.非靜態屬性名稱
        print("A物件的座標: " + traA.position);

        //2.設定 set
        //欄位名稱.非靜態屬性名稱 指定 值 ;
        traA.position = new Vector3(0.88f, 0.5f, -8.90f);
        lightA.color = new Color(1, 0, 0);

        
    }

    private void Update()
    {
        //非靜態方法 methods
        //3. 使用
        //類別名稱.非靜態方法名稱(對應的引數)
        traB.Rotate(0, 10, 0);
    }
}
