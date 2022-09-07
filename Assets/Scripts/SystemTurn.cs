using UnityEngine;
using UnityEngine.Events;
using TMPro;

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
        [SerializeField, Header("�S�����ʪ���åB����ͦ����ɶ�"), Range(0, 3)]
        private float noMoveObjectAndDelaySpawn = 1;
        //�h�ƼƦr
        private TextMeshProUGUI textFloorCount;
        private int countFloor = 1;
        [SerializeField, Header("��e�h�Ƴ̤j��"), Range(1, 100)]
        private int countFloorMax = 50;
        private bool isFloorCountMax;

        private SystemFinal systemFinal;
        #endregion

        private void Awake()
        {
            systemControl = GameObject.Find("����").GetComponent<SystemControl>();
            systemSpawn = GameObject.Find("�Ǫ��ͦ��t��").GetComponent<SystemSpawn>();
            recycleArea = GameObject.Find("�^���ϰ�").GetComponent<RecycleArea>();
            textFloorCount = GameObject.Find("�h�ƼƦr").GetComponent<TextMeshProUGUI>();

            recycleArea.onRecycle.AddListener(RecycleMarble);
            systemFinal = FindObjectOfType<SystemFinal>();
        }

        //�^���u�]
        private void RecycleMarble()
        {
            totalCountMarble = systemControl.canShootMarbleTotla;
            totalRecycleMarble++;
            //print("<color=yellow>�u�]�^���ƶq : " + totalRecycleMarble + "</color>");

            if (totalRecycleMarble == totalCountMarble)
            {
                //print("�^�������A���ĤH�^�X");
                onTurnEnemy.Invoke();
                //�p�G�S���ĤH�N���ʵ����åͦ��ĤH�P�u�]
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

        //���a�^�X
        public void PlayerTurn()
        {
            systemControl.canShootMarble = true;
            canSpawn = true;
            totalRecycleMarble = 0;

            // �u�]�ƶq�B��
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
                    systemFinal.ShowFinalAndUpdateSubTitle("���߬D�����d���\");
                }
            }

        }

        public void MarbleEat()
        {
            countMarbleEat++;
        }
    }
}

