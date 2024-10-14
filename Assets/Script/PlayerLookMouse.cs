using UnityEngine;

public class MouseLook2D_SideView : MonoBehaviour
{

    void Update()
    {
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ĳ���Ϳ� ���콺�� X �� ���� ���
        if (mousePos.x > transform.position.x)
        {
            // ���콺�� ĳ������ �����ʿ� ���� �� (�������� �ٶ󺸰� ����)
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (mousePos.x < transform.position.x)
        {
            // ���콺�� ĳ������ ���ʿ� ���� �� (������ �ٶ󺸰� ����)
            transform.localScale = new Vector3(-1, 1, 1);  // X�� ����
        }
    }
}
