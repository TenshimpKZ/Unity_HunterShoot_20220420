using UnityEngine;
using System.Collections;
using TMPro;

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
        [Header("彈珠生成")]
        public Transform traSpawnPoint;
        [Header("攻擊參數名稱")]
        public string parAttack = "觸發攻擊";
        [Header("彈珠發射速度"), Range(0, 5000)]
        public float speedMarble = 1000;
        [Header("彈珠發射間隔"), Range(0, 2)]
        public float intervalMarble = 0.5f;
        /// <summary>
        /// 能否發射彈珠
        /// </summary>
        public bool canShootMarble = true;
        [Header("彈珠數量")]
        public TextMeshProUGUI textMarbleCount;

        private Animator ani;
        /// <summary>
        /// 滑鼠座標攝影機
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// 座標轉換物件
        /// </summary>
        private Transform traMouse;
        #endregion

        #region 事件
        // Awake 在 Start 之前執行一次
        private void Awake()
        {
            ani = GetComponent<Animator>();

            textMarbleCount.text = "x" + canShootMarbleTotla;

            cameraMouse = GameObject.Find("滑鼠座標攝影機").GetComponent<Camera>();

            //traMouse = GameObject.Find("座標轉換物件").GetComponent<Transform>();
            traMouse = GameObject.Find("座標轉換物件").transform;
        }

        private void Update()
        {
            ShootMarble();
            TurnCharacter();
        }

        #endregion

        #region 方法
        /// <summary>
        /// 旋轉角色，讓角色面向滑鼠的位置
        /// </summary>
        private void TurnCharacter()
        {
            if (!canShootMarble) return;

            // 1. 滑鼠座標
            Vector3 posMouse = Input.mousePosition;
            //print("<color = yellow>滑鼠座標 : " + posMouse + "</color>");
            //跟攝影機的Y軸一樣
            posMouse.z = 29;

            // 2. 滑鼠座標轉為世界座標
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            //將轉換完的世界座標高度設定為角色的高度
            pos.y = 0.5f;
            // 3. 世界座標給實體物件
            traMouse.position = pos;

            // 此物件的變形.面向(座標轉換後實體物件)
            transform.LookAt(traMouse);
        }
        /// <summary>
        /// 發射彈珠，根據總數發射彈珠
        /// </summary>
        private void ShootMarble()
        {
            //如果 不能發射彈珠 就跳出
            if (!canShootMarble) return;

            //按下 滑鼠左鍵 顯示 箭頭
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }

            //放開滑鼠左鍵 放開並發射彈珠
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //不能發射彈珠
                canShootMarble = false;

                //print("放開左鍵!");
                arrow.SetActive(false);
                StartCoroutine(SpawnMarble());

                
            }
        }

        private IEnumerator SpawnMarble()
        {
            int total = canShootMarbleTotla;

            for (int i = 0; i < canShootMarbleTotla; i++)
            {
                ani.SetTrigger(parAttack);

                //Object 類別可省略
                //直接透過 Object 成員名稱使用
                //生成(彈珠);
                //Quaternion.identity 零角度
                GameObject tempMarble = Instantiate(marble, traSpawnPoint.position, Quaternion.identity);
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);
                //暫存彈珠 取得剛體元件 添加推力 (角色.前方 * 速度)
                //transform.forward 角色的前方

                total--;
                if (total > 0) textMarbleCount.text = "x" + total;
                else if (total <= 0) textMarbleCount.text = "";

                yield return new WaitForSeconds(intervalMarble);
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

