using UnityEngine;
using TMPro;

namespace KZ
{
    /// <summary>
    /// 管理金幣 : 更新金幣數量
    /// </summary>
    public class ManagerCoin : MonoBehaviour
    {
        //金幣數量
        private TextMeshProUGUI textCoin;
        //金幣總數
        private int totalCoin;

        private void Awake()
        {
            textCoin = GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
        }

        //添加一個金幣更新介面
        public void AddCoinUpdateUI()
        {
            totalCoin++;
            textCoin.text = totalCoin.ToString();
        }
    }
}

