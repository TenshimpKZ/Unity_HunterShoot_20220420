using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("���q"), Range(2, 15), Tooltip("���l�����q��쬰�y")]
    public int weight = 3;
    [Header("����"), Range(1, 10), Tooltip("���l�����׳�쬰����")]
    public float height = 1.6f;
    [Header("�~�P"), Tooltip("���l�~�P")]
    public string brand = "�S����";
    [Header("�O�_���ѵ�"), Tooltip("���l�O�_���ѵ�")]
    public bool hasSkyWindow = true;

    
}
