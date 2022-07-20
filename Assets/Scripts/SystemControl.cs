using UnityEngine;
using System.Collections;

namespace KZ
{
    /// <summary>
    /// ���a����t��
    /// �������B�o�g�u�]
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        private void Update()
        {
            ShootMarble();
        }

        #region ���
        //GameObject �C������
        //�s�񶥼h���O���αM�פ�������
        [Header("�b�Y")]
        public GameObject arrow;
        [Header("����t��")]
        [Range(0, 500)]
        public float speedTurn = 10.5f;
        [Header("�u�]�w�m��")]
        public GameObject marble;
        [Header("�i�o�g���u�]�`��")]
        [Range(0, 100)]
        public int canShootMarbleTotla = 15;
        [Header("�u�]�ͦ�")]
        public Transform traSpawnPoint;
        [Header("�����ѼƦW��")]
        public string parAttack = "Ĳ�o����";
        [Header("�u�]�o�g�t��"), Range(0, 5000)]
        public float speedMarble = 1000;
        [Header("�u�]�o�g���j"), Range(0, 2)]
        public float intervalMarble = 0.5f;

        public Animator ani;
        #endregion

        #region �ƥ�
        // Awake �b Start ���e����@��
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }
        #endregion

        #region ��k
        /// <summary>
        /// ���ਤ��A�����⭱�V�ƹ�����m
        /// </summary>
        private void TurnCharacter()
        {

        }
        /// <summary>
        /// �o�g�u�]�A�ھ��`�Ƶo�g�u�]
        /// </summary>
        private void ShootMarble()
        {
            //���U �ƹ����� ��� �b�Y
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }

            //��}�ƹ����� ��}�õo�g�u�]
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //print("��}����!");
                arrow.SetActive(false);
                StartCoroutine(SpawnMarble());
            }
        }

        private IEnumerator SpawnMarble()
        {
            for (int i = 0; i < canShootMarbleTotla; i++)
            {
                ani.SetTrigger(parAttack);

                //Object ���O�i�ٲ�
                //�����z�L Object �����W�٨ϥ�
                //�ͦ�(�u�]);
                //Quaternion.identity �s����
                GameObject tempMarble = Instantiate(marble, traSpawnPoint.position, Quaternion.identity);
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);
                //�Ȧs�u�] ���o���餸�� �K�[���O (����.�e�� * �t��)
                //transform.forward ���⪺�e��

                yield return new WaitForSeconds(intervalMarble);
            }
        }
        /// <summary>
        /// �^���u�]
        /// </summary>
        private void ReCycleMarble()
        {

        }
        #endregion

    }

}

