using UnityEngine;

namespace KZ
{
    /// <summary>
    /// 玩家控制系統
    /// 物件旋轉、發射彈珠
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        
        #region 資料
        //GameObject 遊戲物件
        //存放階層面板內或專案內的物件
        [Header("箭頭")]
        public GameObject arrow;
        [Header("旋轉速度")]
        [Range(0, 500)]
        public float speedTurn = 10.5f;
        [Header("彈珠預置物")]
        public GameObject marble;
        [Header("可發射的彈珠總數")]
        [Range(0, 100)]
        public int canShootMarbleTotla = 15;
        #endregion

        #region 事件
        #endregion

        #region 方法
        /// <summary>
        /// 旋轉角色，讓角色面向滑鼠的位置
        /// </summary>
        private void TurnCharacter()
        {

        }
        /// <summary>
        /// 發射彈珠，根據總數發射彈珠
        /// </summary>
        private void ShootMarble()
        {

        }
        /// <summary>
        /// 回收彈珠
        /// </summary>
        private void ReCycleMarble()
        {

        }
        #endregion

    }

}

