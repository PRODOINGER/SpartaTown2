using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;  // �̸��� �Է��ϴ� InputField
    public GameObject[] characterPrefabs;  // ���� ������ ĳ���� ������ �迭
    private string playerName;  // �Էµ� �÷��̾� �̸�
    private int selectedCharacterIndex = -1;  // ���õ� ĳ���� �ε��� (-1�� ���õ��� ������ �ǹ�)
    public GameObject startPanel;          // �̸� �Է� �г�
    public GameObject characterSelectionPanel; // ĳ���� ���� �г�

    private static GameManager instance;  // �̱��� ������ ���� �ν��Ͻ�

    void Awake()
    {
        // �̱��� ����: �� ��ȯ �ÿ��� GameManager�� �����ǵ��� ����
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ���� ��ȯ�Ǿ ������Ʈ�� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject);  // �̹� �ν��Ͻ��� ������ ���� ���� ������Ʈ�� �ı�
        }
    }

    // ĳ���� ���� �޼��� (OnClick �̺�Ʈ�� ����)
    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;  // ĳ���� �ε��� ����
        Debug.Log("Selected character index: " + selectedCharacterIndex);
    }

    // ���� ���� �޼��� (OnClick �̺�Ʈ�� ����)
    public void StartGame()
    {
        // �̸� �Է� �ʵ忡�� �̸��� ������
        playerName = nameInputField.text;

        // �̸��� ����� �����Ǿ����� Ȯ��
        Debug.Log("Player Name at StartGame: " + playerName);

        // �̸��� �ԷµǾ���, ĳ���Ͱ� ���õǾ����� Ȯ��
        if (!string.IsNullOrEmpty(playerName) && selectedCharacterIndex >= 0)
        {
            Debug.Log("Game Started with Player Name: " + playerName);
            // ���� ���� ������ ��ȯ
            SceneManager.LoadScene("MainGameScene");
        }
        else
        {
            Debug.Log("�̸��� �Է��ϰ� ĳ���͸� �����ϼ���.");
        }
    }

    // ������ ĳ������ �̸��� ��ȯ (���� ������ ����� �� ����)
    public string GetPlayerName()
    {
        return playerName;
    }

    // ������ ĳ������ �������� ��ȯ (���� ������ ����� �� ����)
    public GameObject GetSelectedCharacterPrefab()
    {
        if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characterPrefabs.Length)
        {
            return characterPrefabs[selectedCharacterIndex];
        }
        return null;
    }

    void Start()
    {
        // ���� ���� �� ĳ���� ���� �г��� ��Ȱ��ȭ
        characterSelectionPanel.SetActive(false);
        startPanel.SetActive(true);  // ���� �г� Ȱ��ȭ
    }

    // Join ��ư�� ������ ȣ��Ǵ� �޼���
    public void OnJoinButtonClicked()
    {
        // �̸� �Է� �ʵ忡�� �̸��� ������
        playerName = nameInputField.text;

        // �̸��� ����� �����Ǿ����� Ȯ��
        Debug.Log("Player Name: " + playerName);

        // �̸��� �ԷµǾ����� Ȯ��
        if (!string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player Name: " + playerName);
            // ���� �г��� ��Ȱ��ȭ�ϰ� ĳ���� ���� �г��� Ȱ��ȭ
            startPanel.SetActive(false);
            characterSelectionPanel.SetActive(true);
        }
        else
        {
            Debug.Log("�̸��� �Է��ϼ���.");
        }
    }
}
