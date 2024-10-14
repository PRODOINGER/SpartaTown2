using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public TMP_InputField nameInputField;  // 이름 입력 필드
    public GameObject startPanel;          // 이름 입력 패널
    public GameObject characterSelectionPanel; // 캐릭터 선택 패널

    private string playerName;

    void Start()
    {
        // 게임 시작 시 캐릭터 선택 패널을 비활성화
        characterSelectionPanel.SetActive(false);
        startPanel.SetActive(true);  // 시작 패널 활성화
    }

    // Join 버튼을 누르면 호출되는 메서드
    public void OnJoinButtonClicked()
    {
        // 이름 입력 필드에서 이름을 가져옴
        playerName = nameInputField.text;

        // 이름이 입력되었는지 확인
        if (!string.IsNullOrEmpty(playerName))
        {
            Debug.Log("Player Name: " + playerName);
            // 시작 패널을 비활성화하고 캐릭터 선택 패널을 활성화
            startPanel.SetActive(false);
            characterSelectionPanel.SetActive(true);
        }
        else
        {
            Debug.Log("이름을 입력하세요.");
        }
    }

    // 플레이어 이름을 반환
    public string GetPlayerName()
    {
        return playerName;
    }
}