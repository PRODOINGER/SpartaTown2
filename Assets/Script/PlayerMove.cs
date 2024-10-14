using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;  // Animator 추가

    Vector2 movement;

    void Update()
    {
        // W, A, S, D 입력 처리
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 애니메이터에 Speed 값 전달
        animator.SetFloat("Speed", movement.sqrMagnitude);  // 캐릭터의 이동 속도 전달
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용한 이동 처리
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
