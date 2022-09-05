using UnityEngine;
using UnityEngine.Events;

namespace KZ
{
    public class SystemTurn : MonoBehaviour
    {
        #region 戈
        private SystemControl systemControl;
        private SystemSpawn systemSpawn;
        private RecycleArea recycleArea;
        //紆痌羆计
        private int totalCountMarble;
        //┣籔紆痌羆计
        private int totalCountEnemyLive;
        //Μ紆痌计秖
        private int totalRecycleMarble;
        //寄
        public UnityEvent onTurnEnemy;
        private bool canSpawn = true;
        private int countMarbleEat;
        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("つ").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("┣ネΘ╰参").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("Μ跋办").GetComponent<RecycleArea>();

            recycleArea.onRecycle.AddListener(RecycleMarble);
        }

        private void RecycleMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotla;
            totalRecycleMarble++;
            print("<color=yellow>紆痌Μ计秖 : " + totalRecycleMarble + "</color>");

            if (totalRecycleMarble == totalCountMarble)
            {
                print("ΜЧ拨传寄");
                onTurnEnemy.Invoke();
            }
        }

        public void MoveEndSpawnEnemy()
        {
            if (!canSpawn) return;

            canSpawn = false;

            systemSpawn.SpawnRandomEnemy();

            Invoke("PlayerTurn", 1);
        }

        //產
        public void PlayerTurn()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRecycleMarble = 0;

            // 紆痌计秖矪柑
            systemControl.canShootMarbleTotla += countMarbleEat;
            countMarbleEat = 0;
        }

        public void MarbleEat()
        {
            countMarbleEat++;
        }
    }
}

