using UnityEngine;
using System.Collections.Generic;   //��Ƶ��c �M�� List
using System.Linq;                  //�d�߻y��

namespace KZ
{
    /// <summary>
    /// �Ǫ��ͦ��t��
    /// </summary>
    public class SystemSpawn : MonoBehaviour
    {
        #region ���
        // [] �}�C
        // SerializeField �N�p�H������
        [Header("�Ǫ��}�C"), SerializeField]
        private GameObject[] goEnemys;
        [Header("�ͦ���l�ĤG�Ʈy��"), SerializeField]
        private Transform[] traSecondPlace;

        [SerializeField]
        private List<Transform> listSecondPlace = new List<Transform>();

        [Header("��l �u�]"), SerializeField]
        private GameObject goMarbal;

        //�Ǫ��P�i�H�Y���u�]�s���`��
        public int totalCountEnemyLive;
        #endregion

        #region �ƥ�

        private void Awake()
        {
            SpawnRandomEnemy();
        }
        #endregion

        #region ��k
        /// <summary>
        /// �ͦ��H���ĤH
        /// </summary>
        public void SpawnRandomEnemy()
        {
            int min = 2;
            int max = traSecondPlace.Length;

            int randomCount = Random.Range(min, max);
            print("�H���Ǫ����ƶq: " + randomCount);

            //�M�� = �}�C.�ର�M��]�^;
            listSecondPlace = traSecondPlace.ToList();
            // �H������
            System.Random random = new System.Random();
            // �M�� = �M�檺�Ƨ�(�C�ӲM�椺�e => �H���Ƨ�) �ର�M�� OderBy(System.Linq;)
            listSecondPlace = listSecondPlace.OrderBy(x => random.Next()).ToList();

            int sub = traSecondPlace.Length - randomCount;
            print("�ݭn�������q: " + sub);

            //�j�� �R�� �n�������ƶq
            for (int i = 0; i < sub; i++)
            {
                //�R���Ĥ@�ӲM����
                listSecondPlace.RemoveAt(0);
            }

            //�ͦ��Ҧ��Ǫ��P�u�]�@��
            for (int i = 0; i < listSecondPlace.Count; i++)
            {
                if (i == 0)
                {
                    Instantiate(goMarbal, listSecondPlace[i].position, Quaternion.identity);
                }
                else
                {
                    //�H���Ǫ�
                    int randomIndex = Random.Range(0, goEnemys.Length);
                    //�ͦ��Ǫ�
                    Instantiate(goEnemys[randomIndex], listSecondPlace[i].position, Quaternion.identity);
                }

                totalCountEnemyLive++;
                print("�Ǫ��P�u�]�ƶq : " + totalCountEnemyLive);

            }
        }
        #endregion

    }
}

