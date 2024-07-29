using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UpgradeComponent))]
[RequireComponent(typeof(Button))]
public class UpgradeView : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;

    private Button button;
    private GameManager gm;
    private UpgradeComponent uc;

    public void Awake()
    {
        gm = GameManager.Instance;
        button = GetComponent<Button>();
        uc = GetComponent<UpgradeComponent>();
        SetText();
        SetState();
    }

    public void OnEnable()
    {
        gm.Money.MoneyChanged += SetState;
        gm.Cost.CostChanged += SetText;
        uc.Clicked += SetState;
    }

    public void OnDisable()
    {
        gm.Money.MoneyChanged -= SetState;
        gm.Cost.CostChanged -= SetText;
        uc.Clicked -= SetState;
    }

    private void SetText()
    {
        costText.text = gm.Cost.Current.ToString();
    }

    public void SetState()
    {
        button.interactable = gm.Money.CanTake(gm.Cost.Current);
    }
}
