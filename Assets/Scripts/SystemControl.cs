using UnityEngine;

namespace KZ
{
    /// <summary>
    /// 玩家控制系統
    /// 物件旋轉、發射彈珠
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        private void Update()
        {
            ShootMarble();
        }

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
        [Header("彈珠生成")]
        public Transform traSpawnPoint;
        [Header("攻擊參數名稱")]
        public string parAttack = "觸發攻擊";

        public Animator ani;
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
            //放開滑鼠左鍵 放開並發射彈珠
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                print("放開左鍵!");

                //Object 類別可省略
                //直接透過 Object 成員名稱使用
                //生成(彈珠);
                //Quaternion.identity 零角度
                Instantiate(marble, traSpawnPoint.position, Quaternion.identity);
            }
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

