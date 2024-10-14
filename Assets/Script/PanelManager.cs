using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public TMP_InputField nameInputField;  // �̸� �Է� �ʵ�
    public GameObject startPanel;          // �̸� �Է� �г�
    public GameObject characterSelectionPanel; // ĳ���� ���� �г�

    private string playerName;

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

    // �÷��̾� �̸��� ��ȯ
    public string GetPlayerName()
    {
        return playerName;
    }
}