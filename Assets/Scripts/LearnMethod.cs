using UnityEngine;

public class LearnMethod : MonoBehaviour
{
    private void Start()
    {
        Test();
        PrintColorText();
        PrintSizeText();
    }

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
}
