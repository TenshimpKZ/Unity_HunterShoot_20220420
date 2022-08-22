using UnityEngine;

namespace KZ
{
    // ScriptableObject �}���ƪ��� : �}�����e�ܦ���Ʀs��bProject��
    // �����f�t CreateAssetMenu
    [CreateAssetMenu(menuName = "KZ/Data Enemy", fileName = "Data Enemy")]
    public class DataEnemy : ScriptableObject
    {
        [Header("��q"), Range(0, 10000)]
        public float hp;
        [Header("�ˮ`"), Range(0, 10000)]
        public float damage;
    }
}
