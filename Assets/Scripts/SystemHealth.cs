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

        private SystemSpawn systemSpawn;

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();
            systemSpawn = GameObject.Find("怪物生成系統").GetComponent<SystemSpawn>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            //print("碰撞到的物件 : " + collision.gameObject);
            GetDamage();
        }

        private void GetDamage()
        {
            float getDamage = 50;
            hp -= getDamage;
            textHP.text = hp.ToString();
            imgHP.fillAmount = hp / dataEnemy.hp;
            aniEnemy.SetTrigger(parDamage);
            
            Vector3 pos = transform.position + Vector3.up;
            SystemDamage tempDamage = Instantiate(goDamage, pos, Quaternion.Euler(45, 0, 0)).GetComponent<SystemDamage>();
            tempDamage.damage = getDamage;

            if (hp <= 0) Dath();
        }

        private void Dath()
        {
            //print("死亡");
            Destroy(gameObject);
            systemSpawn.totalCountEnemyLive--;
        }
    }
}

