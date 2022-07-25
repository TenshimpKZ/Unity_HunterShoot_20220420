using UnityEngine;
using System.Collections;
using TMPro;

namespace KZ
{
    /// <summary>
    /// ���a����t��
    /// �������B�o�g�u�]
    /// </summary>
    public class SystemControl : MonoBehaviour
    {
        
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
        /// <summary>
        /// ��_�o�g�u�]
        /// </summary>
        public bool canShootMarble = true;
        [Header("�u�]�ƶq")]
        public TextMeshProUGUI textMarbleCount;

        private Animator ani;
        /// <summary>
        /// �ƹ��y����v��
        /// </summary>
        private Camera cameraMouse;
        /// <summary>
        /// �y���ഫ����
        /// </summary>
        private Transform traMouse;
        #endregion

        #region �ƥ�
        // Awake �b Start ���e����@��
        private void Awake()
        {
            ani = GetComponent<Animator>();

            textMarbleCount.text = "x" + canShootMarbleTotla;

            cameraMouse = GameObject.Find("�ƹ��y����v��").GetComponent<Camera>();

            //traMouse = GameObject.Find("�y���ഫ����").GetComponent<Transform>();
            traMouse = GameObject.Find("�y���ഫ����").transform;
        }

        private void Update()
        {
            ShootMarble();
            TurnCharacter();
        }

        #endregion

        #region ��k
        /// <summary>
        /// ���ਤ��A�����⭱�V�ƹ�����m
        /// </summary>
        private void TurnCharacter()
        {
            if (!canShootMarble) return;

            // 1. �ƹ��y��
            Vector3 posMouse = Input.mousePosition;
            //print("<color = yellow>�ƹ��y�� : " + posMouse + "</color>");
            //����v����Y�b�@��
            posMouse.z = 29;

            // 2. �ƹ��y���ର�@�ɮy��
            Vector3 pos = cameraMouse.ScreenToWorldPoint(posMouse);
            //�N�ഫ�����@�ɮy�а��׳]�w�����⪺����
            pos.y = 0.5f;
            // 3. �@�ɮy�е����骫��
            traMouse.position = pos;

            // �������ܧ�.���V(�y���ഫ����骫��)
            transform.LookAt(traMouse);
        }
        /// <summary>
        /// �o�g�u�]�A�ھ��`�Ƶo�g�u�]
        /// </summary>
        private void ShootMarble()
        {
            //�p�G ����o�g�u�] �N���X
            if (!canShootMarble) return;

            //���U �ƹ����� ��� �b�Y
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                arrow.SetActive(true);
            }

            //��}�ƹ����� ��}�õo�g�u�]
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //����o�g�u�]
                canShootMarble = false;

                //print("��}����!");
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

                //Object ���O�i�ٲ�
                //�����z�L Object �����W�٨ϥ�
                //�ͦ�(�u�]);
                //Quaternion.identity �s����
                GameObject tempMarble = Instantiate(marble, traSpawnPoint.position, Quaternion.identity);
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);
                //�Ȧs�u�] ���o���餸�� �K�[���O (����.�e�� * �t��)
                //transform.forward ���⪺�e��

                total--;
                if (total > 0) textMarbleCount.text = "x" + total;
                else if (total <= 0) textMarbleCount.text = "";

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

