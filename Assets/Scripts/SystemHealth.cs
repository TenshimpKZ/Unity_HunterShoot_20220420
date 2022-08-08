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

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();
        }

        private void OnCollisionEnter(Collision collision)
        {
            //print("碰撞到的物件 : " + collision.gameObject);
            GetDamage();
        }

        private void GetDamage()
        {
            hp -= 50;
            textHP.text = hp.ToString();
            imgHP.fillAmount = hp / dataEnemy.hp;

            if (hp <= 0) Dath();
        }

        private void Dath()
        {
            print("死亡");
        }
    }
}

