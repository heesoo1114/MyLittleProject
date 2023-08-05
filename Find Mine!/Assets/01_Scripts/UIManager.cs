using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _giveUpBtn;

    #region PlaySet

    [Header("Set")]
    public int mineCnt = 10; // Áö·Ú °³¼ö

    [SerializeField] private TextMeshProUGUI _mineCountTxt;

    #endregion

    #region Timer

    [Header("Timer")]
    public bool isTimerOn = false;
    private float time = 0;

    [SerializeField] private TextMeshProUGUI _secondTxt;
    [SerializeField] private TextMeshProUGUI _minuteTxt;

    #endregion

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

    public void WhengGameStart()
    {
        StartTimer();
        _newGameBtn.interactable = false;
        _giveUpBtn.interactable = true;
    }

    public void WhenGameOver()
    {
        StopTimer();
        _newGameBtn.interactable = true;
        _giveUpBtn.interactable = false;
    }

    #region MineCnt

    public void MinePlusBtnPress()
    {
        if (mineCnt == 99) return;
        mineCnt++;
        MineCntTxtUpdate();
    }

    public void MineMinusBtnPress()
    {
        if (mineCnt == 0) return;
        mineCnt--;
        MineCntTxtUpdate();
    }

    private void MineCntTxtUpdate()
    {
        _mineCountTxt.text = mineCnt.ToString();
    }

    #endregion

    #region Timer

    public void StartTimer()
    {
        time = 0;
        isTimerOn = true;
    }

    public void StopTimer()
    {
        isTimerOn = false;
    }

    #endregion

    #region PanelBtn

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

    #endregion
}
