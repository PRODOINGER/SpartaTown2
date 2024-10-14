using UnityEngine;
using TMPro;

public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint;  // 캐릭터가 스폰될 위치
    public CameraFollow2D cameraFollowScript;  // 카메라가 따라가는 스크립트
    public TMP_Text playerNameTextPrefab;  // TextMeshPro용 텍스트 프리팹

    void Start()
    {
        // GameManager에서 선택된 캐릭터 프리팹과 이름을 가져옴
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            // 선택된 캐릭터를 스폰
            GameObject selectedCharacter = Instantiate(gameManager.GetSelectedCharacterPrefab(), spawnPoint.position, Quaternion.identity);

            // 카메라가 스폰된 캐릭터를 따라가도록 설정
            cameraFollowScript.target = selectedCharacter.transform;

            // 스폰된 캐릭터 위에 이름 텍스트를 생성 (selectedCharacter의 자식으로 설정)
            TMP_Text playerNameText = Instantiate(playerNameTextPrefab, selectedCharacter.transform);

            // 텍스트의 위치를 캐릭터의 머리 위로 설정
            playerNameText.transform.localPosition = new Vector3(0, 2, 0);  // 캐릭터 위에 텍스트 위치 설정

            // GameManager에서 플레이어 이름을 가져와서 텍스트 설정
            playerNameText.text = gameManager.GetPlayerName();

            // 스폰된 캐릭터에 LookAtMouse 스크립트를 추가하여 마우스를 바라보게 설정
            selectedCharacter.AddComponent<MouseLook2D_SideView>();
        }
        else
        {
            Debug.LogError("GameManager를 찾을 수 없습니다.");
        }
    }
}
