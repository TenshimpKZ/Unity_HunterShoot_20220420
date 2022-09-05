using UnityEngine;
using UnityEngine.Events;

namespace KZ
{
    public class SystemTurn : MonoBehaviour
    {
        #region ���
        private SystemControl systemControl;
        private SystemSpawn systemSpawn;
        private RecycleArea recycleArea;
        //�u�]�`��
        private int totalCountMarble;
        //�Ǫ��P�i�H�Y���u�]�s���`��
        private int totalCountEnemyLive;
        //�^���u�]�ƶq
        private int totalRecycleMarble;
        //�ĤH�^�X
        public UnityEvent onTurnEnemy;
        private bool canSpawn = true;
        private int countMarbleEat;
        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("����").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�Ǫ��ͦ��t��").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("�^���ϰ�").GetComponent<RecycleArea>();

            recycleArea.onRecycle.AddListener(RecycleMarble);
        }

        private void RecycleMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotla;
            totalRecycleMarble++;
            print("<color=yellow>�u�]�^���ƶq : " + totalRecycleMarble + "</color>");

            if (totalRecycleMarble == totalCountMarble)
            {
                print("�^�������A���ĤH�^�X");
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

        //���a�^�X
        public void PlayerTurn()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRecycleMarble = 0;

            // �u�]�ƶq�B��
            systemControl.canShootMarbleTotla += countMarbleEat;
            countMarbleEat = 0;
        }

        public void MarbleEat()
        {
            countMarbleEat++;
        }
    }
}

