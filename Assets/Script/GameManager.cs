using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;  // 이름을 입력하는 InputField
    public GameObject[] characterPrefabs;  // 선택 가능한 캐릭터 프리팹 배열
    private string playerName;  // 입력된 플레이어 이름
    private int selectedCharacterIndex = -1;  // 선택된 캐릭터 인덱스 (-1은 선택되지 않음을 의미)
    public GameObject startPanel;          // 이름 입력 패널
    public GameObject characterSelectionPanel; // 캐릭터 선택 패널

    private static GameManager instance;  // 싱글톤 패턴을 위한 인스턴스

    void Awake()
    {
        // 싱글톤 패턴: 씬 전환 시에도 GameManager가 유지되도록 설정
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // 씬이 전환되어도 오브젝트가 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);  // 이미 인스턴스가 있으면 새로 만든 오브젝트는 파괴
        }
    }

    // 캐릭터 선택 메서드 (OnClick 이벤트에 연결)
    public void SelectCharacter(int index)
    {
        selectedCharacterIndex = index;  // 캐릭터 인덱스 저장
        Debug.Log("Selected character index: " + selectedCharacterIndex);
    }

    // 게임 시작 메서드 (OnClick 이벤트에 연결)
    public void StartGame()
    {
        // 이름 입력 필드에서 이름을 가져옴
        playerName = nameInputField.text;

        // 이름이 제대로 설정되었는지 확인
        Debug.Log("Player Name at StartGame: " + playerName);

        // 이름이 입력되었고, 캐릭터가 선택되었는지 확인
        if (!string.IsNullOrEmpty(playerName) && selectedCharacterIndex >= 0)
        {
            Debug.Log("Game Started with Player Name: " + playerName);
            // 메인 게임 씬으로 전환
            SceneManager.LoadScene("MainGameScene");
        }
        else
        {
            Debug.Log("이름을 입력하고 캐릭터를 선택하세요.");
        }
    }

    // 선택한 캐릭터의 이름을 반환 (메인 씬에서 사용할 수 있음)
    public string GetPlayerName()
    {
        return playerName;
    }

    // 선택한 캐릭터의 프리팹을 반환 (메인 씬에서 사용할 수 있음)
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
        // 게임 시작 시 캐릭터 선택 패널을 비활성화
        characterSelectionPanel.SetActive(false);
        startPanel.SetActive(true);  // 시작 패널 활성화
    }

    // Join 버튼을 누르면 호출되는 메서드
    public void OnJoinButtonClicked()
    {
        // 이름 입력 필드에서 이름을 가져옴
        playerName = nameInputField.text;

        // 이름이 제대로 설정되었는지 확인
        Debug.Log("Player Name: " + playerName);

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
}
