using UnityEngine;


public class LearnOperator : MonoBehaviour
{
    private float a = 10;
    private float b = 3;

    private float c = 99;
    private float d = 1;

    private int dimond = 3;
    private int hp = 100;

    private void Start()
    {
        
        print("加法:" + (a + b));  //13
        print("減法:" + (a - b));  //7
        print("乘法:" + (a * b));  //30
        print("除法:" + (a / b));  //3.3333
        print("餘法:" + (a % b));  //1

        //比較運算子的結果為布林值: true 、 false
        print("小於:" + (c < d));                  // false
        print("大於:" + (c > d));                  // true
        print("小於等於:" + (c <= d));             // false
        print("大於等於:" + (c >= d));             // true
        print("不等於:" + (c != d));               // true
        print("等於:" + (c == d));                 // false

        //並且: 兩個布林值有一個為false，結果就是false
        print("true && true :" + (true && true));               // true
        print("true && false :" + (true && false));             // false
        print("false && true :" + (false && true));             // false
        print("false && false :" + (false && false));           // false
        //或是: 兩個布林值有一個為true，結果就是true
        print("true || true :" + (true || true));               // false
        print("true || false :" + (true || false));             // true
        print("false || true :" + (false || true));             // true
        print("false || false :" + (false || false));           // true

        //遊戲範例:
        //勝利條件: 如果寶石數量大於等於3且血量大於0才能過關
        print("是否通關: " + (dimond >= 3 && hp > 0));          //true

        //顛倒運算子
        //作用: 將布林值變相反
        print("!true: " + (!true));     //false
        print("!false: " + (!false));   //true
    }
    
}
