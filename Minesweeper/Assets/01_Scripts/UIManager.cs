using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private float time = 0;
    public bool isTimerOn = false;

    [SerializeField] private TextMeshProUGUI _secondTxt;
    [SerializeField] private TextMeshProUGUI _minuteTxt;

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

    private void Update()
    {
        if (isTimerOn)
        {
            time += Time.deltaTime;
            _secondTxt.text = ((int)time % 60).ToString();
            _minuteTxt.text = ((int)time / 60).ToString();
        }
    }

    public void StartTimer()
    {
        time = 0;
        isTimerOn = true;
    }

    public void StopTimer()
    {
        isTimerOn = false;
    }

    public void NewGameBtnPress()
    {
        GameManager.Instance.NewGame();
    }

    public void GiveUpBtnPress()
    {
        GameManager.Instance.GameOver();
    }

    public void QuitBtnPress()
    {
        GameManager.Instance.GameQuit();
    }
}
