using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

namespace KZ
{
    /// <summary>
    /// �C�������t�� : �ӧQ�Υ���
    /// </summary>
    public class SystemFinal : MonoBehaviour
    {
        //�C�������e������
        private CanvasGroup groupFinal;
        //�C�������p���D
        private TextMeshProUGUI textSubTitle;
        //���s�C��
        private Button btnReplay;
        //���}�C��
        private Button btnQuit;

        private void Awake()
        {
            groupFinal = GameObject.Find("�C�������e������").GetComponent<CanvasGroup>();
            textSubTitle = GameObject.Find("�C�������p���D").GetComponent<TextMeshProUGUI>();
            btnReplay = GameObject.Find("���s�C��").GetComponent<Button>();
            btnQuit = GameObject.Find("���}�C��").GetComponent<Button>();

            btnReplay.onClick.AddListener(Replay);
            btnQuit.onClick.AddListener(Quit);
        }

        //��ܵ����e���ç�s�p���D
        public void ShowFinalAndUpdateSubTitle(string subTitle)
        {
            textSubTitle.text = subTitle;
            StartCoroutine(ShowFinal());
        }

        //��ܤ���
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

        //���s�C���\��
        private void Replay()
        {
            string nameCurrent = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(nameCurrent);
        }

        //���}�C���\��
        private void Quit()
        {
            Application.Quit();
        }
    }

}
