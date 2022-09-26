using UnityEngine;

namespace KZ
{
    /// <summary>
    /// ���Ĩt�� : ���Ѽ����n�����\��
    /// </summary>
    //�n�D����(����(����1)�A����(����2)�A...)
    //�M�Φ��}���ܹC������ɷ|����
    [RequireComponent(typeof(AudioSource))]
    public class SystemSound : MonoBehaviour
    {
        // �p�G��L�t�λݭn�P�����q�i�H�ϥΦ��g�k
        // �w�q�@�ӻP���}���ۦP�����]���R�A
        // �W�ٲߺD�|�� instance ����
        public static SystemSound instance;

        private AudioSource aud;

        public void Awake()
        {
            // Awake �� Start �N���������}��
            instance = this;
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        /// ���񭵮�
        /// </summary>
        /// <param name="sound">������</param>
        /// <param name="rangeVolume">���q�d��</param>
        public void Playsound(AudioClip sound, Vector2 rangeVolume)
        {
            float volume = Random.Range(rangeVolume.x, rangeVolume.y);

            aud.PlayOneShot(sound, volume);
        }
    }
}

