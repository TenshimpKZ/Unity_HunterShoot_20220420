using UnityEngine;

namespace KZ
{
    /// <summary>
    /// 攻擊系統
    /// </summary>
    public class SystemAttack : MonoBehaviour
    {
        [SerializeField, Header("攻擊資料")]
        private DataAttack dataAttack;
        //攻擊數值
        public float valueAttack;

        private void Awake()
        {
            valueAttack = dataAttack.attack +
                Random.Range(-dataAttack.attackFloat, dataAttack.attackFloat);

            valueAttack = Mathf.Floor(valueAttack);
        }
    }
}

