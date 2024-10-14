using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target;  // 카메라가 따라갈 캐릭터
    public Vector3 offset;    // 카메라와 캐릭터 사이의 거리
    public float smoothSpeed = 0.125f;  // 카메라 이동의 부드러움 정도

    void LateUpdate()
    {
        // 타겟(캐릭터)의 위치에 오프셋을 더하여 카메라 목표 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 현재 카메라 위치에서 목표 위치로 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라 위치 설정
        transform.position = smoothedPosition;
    }
}
