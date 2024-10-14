using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;  // ī�޶� ���� ĳ����
    public Vector3 offset;    // ī�޶�� ĳ���� ������ �Ÿ�
    public float smoothSpeed = 0.125f;  // ī�޶� �̵��� �ε巯�� ����

    void LateUpdate()
    {
        // Ÿ��(ĳ����)�� ��ġ�� �������� ���Ͽ� ī�޶� ��ǥ ��ġ ���
        Vector3 desiredPosition = target.position + offset;

        // ���� ī�޶� ��ġ���� ��ǥ ��ġ�� �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ī�޶� ��ġ ����
        transform.position = smoothedPosition;
    }
}
