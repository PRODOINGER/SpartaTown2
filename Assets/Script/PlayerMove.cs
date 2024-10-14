using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;  // Animator �߰�

    Vector2 movement;

    void Update()
    {
        // W, A, S, D �Է� ó��
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // �ִϸ����Ϳ� Speed �� ����
        animator.SetFloat("Speed", movement.sqrMagnitude);  // ĳ������ �̵� �ӵ� ����
    }

    void FixedUpdate()
    {
        // Rigidbody2D�� ����� �̵� ó��
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
