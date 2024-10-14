using UnityEngine;

public class MouseLook2D_SideView : MonoBehaviour
{

    void Update()
    {
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 캐릭터와 마우스의 X 축 차이 계산
        if (mousePos.x > transform.position.x)
        {
            // 마우스가 캐릭터의 오른쪽에 있을 때 (오른쪽을 바라보게 설정)
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (mousePos.x < transform.position.x)
        {
            // 마우스가 캐릭터의 왼쪽에 있을 때 (왼쪽을 바라보게 설정)
            transform.localScale = new Vector3(-1, 1, 1);  // X축 반전
        }
    }
}
