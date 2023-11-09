using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform enemyHead; // ���˵�ͷ��λ��
    public Image healthBarImage; // Ѫ��ͼƬ

    private Camera mainCamera; // �������

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // ��Ѫ��λ�ù̶��ڵ���ͷ���Ϸ�
        Vector3 worldPos = enemyHead.position + Vector3.up * -0.1f;
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);
        healthBarImage.transform.position = screenPos;
    }
}
