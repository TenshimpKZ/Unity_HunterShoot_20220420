using UnityEngine;

namespace KZ
{
    /// <summary>
    /// �����t�� : �����I���B���쥪�W��
    /// </summary>
    public class SystemCoin : MonoBehaviour
    {
        [SerializeField, Header("���𭸦�"), Range(0, 2)]
        private float delayFly = 1.5f;
        [SerializeField, Header("����t��"), Range(0, 10)]
        private float speed = 1.5f;
        //�����n�e������m
        private Transform traCoinFlyTo;
        //�}�l����
        private bool startFly;

        public ManagerCoin managerCoin;


        private void Awake()
        {
            Physics.IgnoreLayerCollision(6, 3);     //�����B�u�]�����I��
            Physics.IgnoreLayerCollision(6, 6);     //�����B���������I��
            Physics.IgnoreLayerCollision(6, 7);     //�����B�Ǫ������I��

            traCoinFlyTo = GameObject.Find("�����n�e������m").transform;
            managerCoin = GameObject.Find("�����޲z").GetComponent<ManagerCoin>();

            Invoke("StartFly", delayFly);
        }

        private void Update()
        {
            Fly();
        }

        private void StartFly()
        {
            startFly = true;
        }

        private void Fly()
        {
            if (!startFly) return;

            Vector3 traCoin = transform.position;
            Vector3 traCoinTo = traCoinFlyTo.position;

            traCoin = Vector3.Lerp(traCoin, traCoinTo, speed * Time.deltaTime);
            transform.position = traCoin;

            DestroyCoin();
        }

        private void DestroyCoin()
        {
            float dis = Vector3.Distance(transform.position, traCoinFlyTo.position);

            if (dis < 1.5)
            {
                managerCoin.AddCoinUpdateUI();
                Destroy(gameObject);
            }
        }
    }
}

