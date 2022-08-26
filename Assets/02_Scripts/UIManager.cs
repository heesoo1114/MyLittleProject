using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    public UnityEvent NoManaNotice;
    public UnityEvent ManaChargingNotice;
    public UnityEvent CantUseSkillNotice;
    public UnityEvent UsingSkillNotice;

    public UnityEvent InGameESC;

    public UnityEvent<int, Transform> ShowingDamagePopUp;

    public GameObject NoticePanelPrefab;
    private Vector3 CreatePoint;

    public GameObject PopUpTextPrefab;
    public bool isOn = true;

    public int a;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            InGameESC?.Invoke();
        }
    }

    public void PanelDownAnim(GameObject panel)
    {
        Sequence sequence = DOTween.Sequence()
            .Append(panel.transform.DOMoveY(transform.position.y, 0.5f))
            .OnComplete(() =>
            {
                Time.timeScale = 0;
            });
    }

    public void EscUI(GameObject ui)
    {
        ui.SetActive(isOn);
        if (isOn == true)
        {
            Time.timeScale = 0;
        }
        else if (isOn == false)
        {
            Time.timeScale = 1;
        }
        isOn = !isOn;

    }

    public void NoticePanelCreate(string str)
    {
        NoticePanelPrefab.GetComponentInChildren<Text>().text = str;
        Instantiate(NoticePanelPrefab, CreatePoint, Quaternion.identity, GameObject.Find("InGameNotice").transform);
        // 풀링으로 변경
        /*NoticePanelUI noticePanel = PoolManager.Instance.Pop(NoticePanelPrefab.name) as NoticePanelUI;
        noticePanel.transform.SetPositionAndRotation(CreatePoint, Quaternion.identity);*/
    }

    public void ShowingDamageCreate(int damage, Transform postion)
    {
        a = damage;
        Vector3 createPosition = new Vector3(postion.position.x, postion.position.y - 2f, 0);
        // Instantiate(PopUpTextPrefab, createPosition, Quaternion.identity); 
        // 풀링으로 변경
        PopUPDamageUI damageText = PoolManager.Instance.Pop(PopUpTextPrefab.name) as PopUPDamageUI; 
        damageText.transform.SetPositionAndRotation(createPosition, Quaternion.identity);
    }
}
