using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace KZ
{
    /// <summary>
    /// ��q�t�� : ��s��q�B�����P���`�B�z
    /// </summary>
    public class SystemHealth : MonoBehaviour
    {
        [SerializeField, Header("�e���ˮ`����")]
        private GameObject goDamage;
        [SerializeField, Header("�Ϥ���q")]
        private Image imgHP;
        [SerializeField, Header("��r��q")]
        private TextMeshProUGUI textHP;
        [SerializeField, Header("�Ǫ����")]
        private DataEnemy dataEnemy;
        private float hp;

        [SerializeField, Header("�ĤH�ʵe���")]
        private Animator aniEnemy;
        private string parDamage = "Ĳ�o����";

        private SystemSpawn systemSpawn;

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();
            systemSpawn = GameObject.Find("�Ǫ��ͦ��t��").GetComponent<SystemSpawn>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            //print("�I���쪺���� : " + collision.gameObject);
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
            //print("���`");
            Destroy(gameObject);
            systemSpawn.totalCountEnemyLive--;
        }
    }
}
