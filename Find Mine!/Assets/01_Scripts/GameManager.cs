using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Board _board;

    public bool isOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void PlaySetting()
    {
        _board.mineCount = UIManager.Instance.mineCnt;
    }

    public void NewGame()
    {
        if (!isOver)
        {
            Debug.Log("게임이 아직 끝나지 않았습니다. " +
                "지금 당장 새로운 게임을 시작하시고 싶다면 GiveUp 버튼을 눌르고 다시 눌러주세요.");
            return;
        }

        UIManager.Instance.WhengGameStart();
        
        PlaySetting(); // 지뢰 개수를 보내주기 때문에 꼭 아래 보드 설정 전에 실행되어야 함

        _board.openCount = 0;
        _board.RemoveBoard();
        _board.InitBoard();
        _board.InstantiateBoard();
        
        isOver = false;
    }

    public void GameOver()
    {
        UIManager.Instance.WhenGameOver();

        isOver = true;
        
        _board.OpenBoard();
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif     
    }
}
