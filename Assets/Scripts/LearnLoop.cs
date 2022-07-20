using UnityEngine;
using System.Collections;
/// <summary>
/// �ǲ߰j��B��P�{�� Coroutine : ����
/// </summary>
public class LearnLoop : MonoBehaviour
{
    
    void Start()
    {
        int count = 1;

        while (count <= 5)
        {
            print("while �j��! " + count);
            count++;
        }

        for (int i = 1; i <= 5; i++)
        {
            print("for �j��! " + i);
        }

        //��P�{��
        // 1. �ޥΩR�W�Ŷ�  System.Collections
        // 2. �w�q�^�������� IEnumerator ����k
        // 3. yield return ����
        // 4. Start Coroutine �Ұ�
        StartCoroutine(Test());
        StartCoroutine(Loop());
    }

    private IEnumerator Test()
    {
        print("<color=yellow>�Ĥ@��</color>");
        yield return new WaitForSeconds(1);
        print("<color=yellow>�ĤG��</color>");
    }
    
    private IEnumerator Loop()
    {
        for (int i = 1; i <= 10; i++)
        {
            print("<color=#006666>for�j��" + i + "</color>");
            yield return new WaitForSeconds(1);
        }
    }
}
