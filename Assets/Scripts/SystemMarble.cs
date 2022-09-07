using UnityEngine;

namespace KZ
{
    /// <summary>
    /// 彈珠系統
    /// </summary>
    public class SystemMarble : MonoBehaviour
    {
        [SerializeField, Header("怪物圖層")]
        private LayerMask layerEnemy;
        [SerializeField, Header("幾秒沒有碰到怪物要回收"), Range(0, 10)]
        private float timeRecycle = 5;
        [SerializeField, Header("回收速度")]
        private Vector3 v3SpeedRecycle;

        private float timer;
    }
}

