using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace KZ
{
    public class SystemTurn : MonoBehaviour
    {
        #region 資料
        private SystemControl systemControl;
        private SystemSpawn systemSpawn;
        private RecycleArea recycleArea;
        //彈珠總數
        private int totalCountMarble;
        //怪物與可以吃的彈珠存活總數
        private int totalCountEnemyLive;
        //回收彈珠數量
        private int totalRecycleMarble;
        //敵人回合
        public UnityEvent onTurnEnemy;
        private bool canSpawn = true;
        private int countMarbleEat;
        [SerializeField, Header("沒有移動物件並且延遲生成的時間"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;
        //層數數字
        private TextMeshProUGUI textFloorCount;
        private int countFloor = 1;
        [SerializeField, Header("當前層數最大值"), Range(1, 100)]
        private int countFloorMax = 50;
        private bool isFloorCountMax;

        private SystemFinal systemFinal;
        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("狗勾").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("怪物生成系統").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("回收區域").GetComponent<RecycleArea>();
            textFloorCount = GameObject.Find("層數數字").GetComponent<TextMeshProUGUI>();

            recycleArea.onRecycle.AddListener(RecycleMarble);
            systemFinal = FindObjectOfType<SystemFinal>();
        }

        //回收彈珠
        private void RecycleMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotla;
            totalRecycleMarble++;
            //print("<color=yellow>彈珠回收數量 : " + totalRecycleMarble + "</color>");

            if (totalRecycleMarble == totalCountMarble)
            {
                //print("回收完畢，換敵人回合");
                onTurnEnemy.Invoke();
                //如果沒有敵人就移動結束並生成敵人與彈珠
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    Invoke("MoveEndSpawnEnemy", noMoveObjectAndDelaySpawn);
                }
            }
        }

        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;
            if (!isFloorCountMax)
            {
                canSpawn = false;
                systemSpawn.SpawnRandomEnemy();
            }

            Invoke("PlayerTurn", 1);
        }

        //玩家回合
        public void PlayerTurn()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRecycleMarble = 0;

            // 彈珠數量處裡
            systemControl.canShootMarbleTotla += countMarbleEat;
            countMarbleEat = 0;

            if (countFloor < countFloorMax)
            {
                countFloor++;
                textFloorCount.text = countFloor.ToString();
            }
            if (countFloor == countFloorMax) isFloorCountMax = true;

            if (isFloorCountMax)
            {
                if (FindObjectsOfType<SystemMove>().Length == 0)
                {
                    systemFinal.ShowFinalAndUpdateSubTitle("恭喜挑戰關卡成功");
                }
            }

        }

        public void MarbleEat()
        {
            countMarbleEat++;
        }
    }
}

