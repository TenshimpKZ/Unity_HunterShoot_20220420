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
        print("<color=#550055>�����r</color>");
    }

    private void PrintSizeText()
    {
        print("<size=50pt>�j��r</size>");
    }
}
