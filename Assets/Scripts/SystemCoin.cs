using UnityEngine;

namespace KZ
{
    /// <summary>
    /// 金幣系統 : 忽略碰撞、飛到左上角
    /// </summary>
    public class SystemCoin : MonoBehaviour
    {
        [SerializeField, Header("延遲飛行"), Range(0, 2)]
        private float delayFly = 1.5f;
        [SerializeField, Header("飛行速度"), Range(0, 10)]
        private float speed = 1.5f;
        //金幣要前往的位置
        private Transform traCoinFlyTo;
        //開始飛行
        private bool startFly;

        public ManagerCoin managerCoin;


        private void Awake()
        {
            Physics.IgnoreLayerCollision(6, 3);     //金幣、彈珠忽略碰撞
            Physics.IgnoreLayerCollision(6, 6);     //金幣、金幣忽略碰撞
            Physics.IgnoreLayerCollision(6, 7);     //金幣、怪物忽略碰撞

            traCoinFlyTo = GameObject.Find("金幣要前往的位置").transform;
            managerCoin = GameObject.Find("金幣管理").GetComponent<ManagerCoin>();

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

