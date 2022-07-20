using UnityEngine;
using System.Collections;
/// <summary>
/// 學習迴圈、協同程序 Coroutine : 等待
/// </summary>
public class LearnLoop : MonoBehaviour
{
    
    void Start()
    {
        int count = 1;

        while (count <= 5)
        {
            print("while 迴圈! " + count);
            count++;
        }

        for (int i = 1; i <= 5; i++)
        {
            print("for 迴圈! " + i);
        }

        //協同程序
        // 1. 引用命名空間  System.Collections
        // 2. 定義回傳類型為 IEnumerator 的方法
        // 3. yield return 等待
        // 4. Start Coroutine 啟動
        StartCoroutine(Test());
        StartCoroutine(Loop());
    }

    private IEnumerator Test()
    {
        print("<color=yellow>第一行</color>");
        yield return new WaitForSeconds(1);
        print("<color=yellow>第二行</color>");
    }
    
    private IEnumerator Loop()
    {
        for (int i = 1; i <= 10; i++)
        {
            print("<color=#006666>for迴圈" + i + "</color>");
            yield return new WaitForSeconds(1);
        }
    }
}
