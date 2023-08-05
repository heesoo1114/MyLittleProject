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
            Debug.Log("������ ���� ������ �ʾҽ��ϴ�. " +
                "���� ���� ���ο� ������ �����Ͻð� �ʹٸ� GiveUp ��ư�� ������ �ٽ� �����ּ���.");
            return;
        }

        UIManager.Instance.WhengGameStart();
        
        PlaySetting(); // ���� ������ �����ֱ� ������ �� �Ʒ� ���� ���� ���� ����Ǿ�� ��

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
