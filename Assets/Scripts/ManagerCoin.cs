using UnityEngine;
using TMPro;

namespace KZ
{
    /// <summary>
    /// �޲z���� : ��s�����ƶq
    /// </summary>
    public class ManagerCoin : MonoBehaviour
    {
        //�����ƶq
        private TextMeshProUGUI textCoin;
        //�����`��
        private int totalCoin;

        private void Awake()
        {
            textCoin = GameObject.Find("�����ƶq").GetComponent<TextMeshProUGUI>();
        }

        //�K�[�@�Ӫ�����s����
        public void AddCoinUpdateUI()
        {
            totalCoin++;
            textCoin.text = totalCoin.ToString();
        }
    }
}

