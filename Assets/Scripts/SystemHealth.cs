using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KZ
{
    /// <summary>
    /// 血量系統 : 更新血量、介面與死亡處理
    /// </summary>
    public class SystemHealth : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("畫布傷害物件")]
        private GameObject goDamage;
        [SerializeField, Header("圖片血量")]
        private Image imgHP;
        [SerializeField, Header("文字血量")]
        private TextMeshProUGUI textHP;
        [SerializeField, Header("怪物資料")]
        private DataEnemy dataEnemy;
        private float hp;

        [SerializeField, Header("敵人動畫控制器")]
        private Animator aniEnemy;
        private string parDamage = "觸發受傷";

        [SerializeField, Header("碰到會受傷的物件名稱")]
        private string nameHurtObject;

        [Header("玩家接收傷害區域")]
        [SerializeField]private Vector3 v3DamageSize;
        [SerializeField]private Vector3 v3DamagePosition;

        [SerializeField, Header("接收傷害的圖層")]
        private LayerMask layerDamage;

        [SerializeField, Header("是否為玩家")]
        private bool isPlayer;

        [SerializeField, Header("受傷音效")]
        private AudioClip soundHurt;

        [SerializeField, Header("死亡音效")]
        private AudioClip soundDead;

        private SystemSpawn systemSpawn;
        private SystemFinal systemFinal;
        #endregion

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.2f, 1, 0.2f, 0.5f);
            Gizmos.DrawCube(v3DamagePosition, v3DamageSize);
        }

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();
            systemSpawn = GameObject.Find("怪物生成系統").GetComponent<SystemSpawn>();
            systemFinal = FindObjectOfType<SystemFinal>();
        }

        private void Update()
        {
            CheckObjectInDamageArea();
        }

        // 檢查物件是否進入受傷區域
        private void CheckObjectInDamageArea()
        {
            Collider[] hits = Physics.OverlapBox(
                v3DamagePosition, v3DamageSize / 2,
                Quaternion.identity, layerDamage);

            if (hits.Length > 0)
            {
                GetDamage(hits[0].GetComponent<SystemAttack>().valueAttack);
                Destroy(hits[0].gameObject);
            }
        }

        //碰撞事件
        private void OnCollisionEnter(Collision collision)
        {
            //print("碰撞到的物件 : " + collision.gameObject);
            if (collision.gameObject.name.Contains(nameHurtObject)) 
                GetDamage(collision.gameObject.GetComponent<SystemAttack>().valueAttack);
        }

        //受傷
        private void GetDamage(float getDamage)
        {
            
            hp -= getDamage;
            textHP.text = hp.ToString();
            imgHP.fillAmount = hp / dataEnemy.hp;
            aniEnemy.SetTrigger(parDamage);
            
            Vector3 pos = transform.position + Vector3.up;
            SystemDamage tempDamage = Instantiate(goDamage, pos, Quaternion.Euler(45, 0, 0)).GetComponent<SystemDamage>();
            tempDamage.damage = getDamage;

            SystemSound.instance.Playsound(soundHurt, new Vector2(0.7f, 1.2f));

            if (hp <= 0) Datd();
        }

        //死亡
        private void Datd()
        {
            SystemSound.instance.Playsound(soundDead, new Vector2(0.7f, 1.2f));

            if (isPlayer) systemFinal.ShowFinalAndUpdateSubTitle("挑戰關卡失敗...");
            else
            {
                Destroy(gameObject);
                systemSpawn.totalCountEnemyLive--;
                DropCoin();
            }
        }

        private void DropCoin()
        {
            int range = Random.Range(dataEnemy.v2CoinRange.x, dataEnemy.v2CoinRange.y);

            for (int i = 0; i < range; i++)
            {
                float x = Random.Range(1, -1);
                float y = Random.Range(1, -1);

                Instantiate(dataEnemy.goCoin,
                            transform.position + new Vector3(x, 2.5f, y),
                            Quaternion.Euler(90, 0, 180));
            }
        }
    }
}

