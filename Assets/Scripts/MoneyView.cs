using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] public TMP_Text moneyText;

    private GameManager gm;

    public void Awake()
    {
        gm = GameManager.Instance;
        SetText();
    }

    public void OnEnable()
    {
        gm.Money.MoneyChanged += SetText;
    }

    public void OnDisable()
    {
        gm.Money.MoneyChanged -= SetText;
    }

    private void SetText()
    {
        moneyText.text = gm.Money.Amount.ToString();
    }
}
