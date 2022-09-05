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
        #region ���
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

        [SerializeField, Header("�I��|���˪�����W��")]
        private string nameHurtObject;

        [Header("���a�����ˮ`�ϰ�")]
        [SerializeField]private Vector3 v3DamageSize;
        [SerializeField]private Vector3 v3DamagePosition;

        [SerializeField, Header("�����ˮ`���ϼh")]
        private LayerMask layerDamage;
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
            systemSpawn = GameObject.Find("�Ǫ��ͦ��t��").GetComponent<SystemSpawn>();
        }

        private void Update()
        {
            CheckObjectInDamageArea();
        }

        // �ˬd����O�_�i�J���˰ϰ�
        private void CheckObjectInDamageArea()
        {
            Collider[] hits = Physics.OverlapBox(
                v3DamagePosition, v3DamageSize / 2,
                Quaternion.identity, layerDamage);

            if (hits.Length > 0)
            {
                GetDamage();
                Destroy(hits[0].gameObject);
            }
        }

        //�I���ƥ�
        private void OnCollisionEnter(Collision collision)
        {
            //print("�I���쪺���� : " + collision.gameObject);
            if (collision.gameObject.name.Contains(nameHurtObject)) GetDamage();
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

            DropCoin();
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

