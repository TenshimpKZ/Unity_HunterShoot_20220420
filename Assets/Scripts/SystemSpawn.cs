using UnityEngine;
using System.Collections.Generic;   //資料結構 清單 List
using System.Linq;                  //查詢語言

namespace KZ
{
    /// <summary>
    /// 怪物生成系統
    /// </summary>
    public class SystemSpawn : MonoBehaviour
    {
        #region 資料
        // [] 陣列
        // SerializeField 將私人欄位顯示
        [Header("怪物陣列"), SerializeField]
        private GameObject[] goEnemys;
        [Header("生成格子第二排座標"), SerializeField]
        private Transform[] traSecondPlace;

        [SerializeField]
        private List<Transform> listSecondPlace = new List<Transform>();

        [Header("格子 彈珠"), SerializeField]
        private GameObject goMarbal;

        //怪物與可以吃的彈珠存活總數
        public int totalCountEnemyLive;
        #endregion

        #region 事件

        private void Awake()
        {
            SpawnRandomEnemy();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 生成隨機敵人
        /// </summary>
        public void SpawnRandomEnemy()
        {
            int min = 2;
            int max = traSecondPlace.Length;

            int randomCount = Random.Range(min, max);
            print("隨機怪物的數量: " + randomCount);

            //清單 = 陣列.轉為清單（）;
            listSecondPlace = traSecondPlace.ToList();
            // 隨機物件
            System.Random random = new System.Random();
            // 清單 = 清單的排序(每個清單內容 => 隨機排序) 轉為清單 OderBy(System.Linq;)
            listSecondPlace = listSecondPlace.OrderBy(x => random.Next()).ToList();

            int sub = traSecondPlace.Length - randomCount;
            print("需要扣除的量: " + sub);

            //迴圈 刪除 要扣除的數量
            for (int i = 0; i < sub; i++)
            {
                //刪除第一個清單資料
                listSecondPlace.RemoveAt(0);
            }

            //生成所有怪物與彈珠一顆
            for (int i = 0; i < listSecondPlace.Count; i++)
            {
                if (i == 0)
                {
                    Instantiate(goMarbal, listSecondPlace[i].position, Quaternion.identity);
                }
                else
                {
                    //隨機怪物
                    int randomIndex = Random.Range(0, goEnemys.Length);
                    //生成怪物
                    Instantiate(goEnemys[randomIndex], listSecondPlace[i].position, Quaternion.identity);
                }

                totalCountEnemyLive++;
                print("怪物與彈珠數量 : " + totalCountEnemyLive);

            }
        }
        #endregion

    }
}

