using System.Collections;
using System.Collections.Generic;
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

    public UnityEvent<int, Transform> ShowingDamagePopUp;

    public GameObject NoticePanelPrefab;
    private Vector3 CreatePoint;

    public GameObject PopUpTextPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void NoticePanelCreate(string str)
    {
        NoticePanelPrefab.GetComponentInChildren<Text>().text = str;
        // Instantiate(NoticePanelPrefab, CreatePoint, Quaternion.identity, GameObject.Find("InGameNotice").transform);
        // 풀링으로 변경
        NoticePanelUI noticePanel = PoolManager.Instance.Pop(NoticePanelPrefab.name) as NoticePanelUI;
        noticePanel.transform.SetPositionAndRotation(CreatePoint, Quaternion.identity);
    }

    public void ShowingDamageCreate(int damage, Transform postion)
    {
        PopUpTextPrefab.GetComponent<TextMeshPro>().text = damage.ToString();
        Vector3 createPosition = new Vector3(postion.position.x, postion.position.y - 0.8f, 0);
        // Instantiate(PopUpTextPrefab, createPosition, Quaternion.identity); 
        // 풀링으로 변경
        PopUPDamageUI damageText = PoolManager.Instance.Pop(PopUpTextPrefab.name) as PopUPDamageUI;
        damageText.transform.SetPositionAndRotation(createPosition, Quaternion.identity);
    }
    //GameObject.Find("Canvas").transform
}
