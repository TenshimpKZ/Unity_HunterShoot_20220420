using UnityEngine;
/// <summary>
/// �ǲ� �D�R�A API
/// API���W �S�� static
/// </summary>
public class LearmAPINonStatic : MonoBehaviour
{
    public Transform traA;
    public Light lightA;
    public Transform traB;

    private void Start()
    {
        //�D�R�A�ݩ� properties
        //1.���o get
        //����:
        // - �����O�������
        // - ���骫��
        // - ���s��ӹ��骫��
        //���W��.�D�R�A�ݩʦW��
        print("A���󪺮y��: " + traA.position);

        //2.�]�w set
        //���W��.�D�R�A�ݩʦW�� ���w �� ;
        traA.position = new Vector3(0.88f, 0.5f, -8.90f);
        lightA.color = new Color(1, 0, 0);

        
    }

    private void Update()
    {
        //�D�R�A��k methods
        //3. �ϥ�
        //���O�W��.�D�R�A��k�W��(�������޼�)
        traB.Rotate(0, 10, 0);
    }
}
