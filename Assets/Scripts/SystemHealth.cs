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

        private void Awake()
        {
            hp = dataEnemy.hp;
            textHP.text = hp.ToString();
        }

        private void OnCollisionEnter(Collision collision)
        {
            //print("�I���쪺���� : " + collision.gameObject);
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
            print("���`");
        }
    }
}

