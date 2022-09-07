using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

namespace KZ
{
    /// <summary>
    /// 遊戲結束系統 : 勝利或失敗
    /// </summary>
    public class SystemFinal : MonoBehaviour
    {
        //遊戲結束畫面底圖
        private CanvasGroup groupFinal;
        //遊戲結束小標題
        private TextMeshProUGUI textSubTitle;
        //重新遊戲
        private Button btnReplay;
        //離開遊戲
        private Button btnQuit;

        private void Awake()
        {
            groupFinal = GameObject.Find("遊戲結束畫面底圖").GetComponent<CanvasGroup>();
            textSubTitle = GameObject.Find("遊戲結束小標題").GetComponent<TextMeshProUGUI>();
            btnReplay = GameObject.Find("重新遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("離開遊戲").GetComponent<Button>();

            btnReplay.onClick.AddListener(Replay);
            btnQuit.onClick.AddListener(Quit);
        }

        //顯示結束畫面並更新小標題
        public void ShowFinalAndUpdateSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
            StartCoroutine(ShowFinal());
        }

        //顯示介面
        private IEnumerator ShowFinal()
        {
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.03f);
            }

            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }

        //重新遊戲功能
        private void Replay()
        {
            string nameCurrent = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nameCurrent);
        }

        //離開遊戲功能
        private void Quit()
        {
            Application.Quit();
        }
    }

}
