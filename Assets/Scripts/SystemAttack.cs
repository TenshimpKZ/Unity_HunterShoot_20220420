using UnityEngine;

namespace KZ
{
    /// <summary>
    /// �����t��
    /// </summary>
    public class SystemAttack : MonoBehaviour
    {
        [SerializeField, Header("�������")]
        private DataAttack dataAttack;
        //�����ƭ�
        public float valueAttack;

        private void Awake()
        {
            valueAttack = dataAttack.attack +
                Random.Range(-dataAttack.attackFloat, dataAttack.attackFloat);

            valueAttack = Mathf.Floor(valueAttack);
        }
    }
}

