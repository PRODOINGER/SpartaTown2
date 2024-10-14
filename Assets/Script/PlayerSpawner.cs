using UnityEngine;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint;  // ĳ���Ͱ� ������ ��ġ
    public CameraFollow2D cameraFollowScript;  // ī�޶� ���󰡴� ��ũ��Ʈ
    public TMP_Text playerNameTextPrefab;  // TextMeshPro�� �ؽ�Ʈ ������

    void Start()
    {
        // GameManager���� ���õ� ĳ���� �����հ� �̸��� ������
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // ���õ� ĳ���͸� ����
            GameObject selectedCharacter = Instantiate(gameManager.GetSelectedCharacterPrefab(), spawnPoint.position, Quaternion.identity);

            // ī�޶� ������ ĳ���͸� ���󰡵��� ����
            cameraFollowScript.target = selectedCharacter.transform;

            // ������ ĳ���� ���� �̸� �ؽ�Ʈ�� ���� (selectedCharacter�� �ڽ����� ����)
            TMP_Text playerNameText = Instantiate(playerNameTextPrefab, selectedCharacter.transform);

            // �ؽ�Ʈ�� ��ġ�� ĳ������ �Ӹ� ���� ����
            playerNameText.transform.localPosition = new Vector3(0, 2, 0);  // ĳ���� ���� �ؽ�Ʈ ��ġ ����

            // GameManager���� �÷��̾� �̸��� �����ͼ� �ؽ�Ʈ ����
            playerNameText.text = gameManager.GetPlayerName();

            // ������ ĳ���Ϳ� LookAtMouse ��ũ��Ʈ�� �߰��Ͽ� ���콺�� �ٶ󺸰� ����
            selectedCharacter.AddComponent<MouseLook2D_SideView>();
        }
        else
        {
            Debug.LogError("GameManager�� ã�� �� �����ϴ�.");
        }
    }
}
