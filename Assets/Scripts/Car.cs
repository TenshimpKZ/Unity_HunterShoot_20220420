using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("重量"), Range(2, 15), Tooltip("車子的重量單位為頓")]
    public int weight = 3;
    [Header("高度"), Range(1, 10), Tooltip("車子的高度單位為公尺")]
    public float height = 1.6f;
    [Header("品牌"), Tooltip("車子品牌")]
    public string brand = "特斯拉";
    [Header("是否有天窗"), Tooltip("車子是否有天窗")]
    public bool hasSkyWindow = true;

    
}
