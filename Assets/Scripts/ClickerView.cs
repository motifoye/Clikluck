using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ClickerComponent))]
[RequireComponent(typeof(RawImage))]
public class ClickerView : MonoBehaviour
{
    [SerializeField] private Color upColor, downColor;
    [SerializeField] public GameObject buck;
    [SerializeField] public Canvas toSpawn;
    [SerializeField] public TMP_Text powerText;

    private GameManager gm;
    private ClickerComponent clicker;
    private RawImage image;

    private void Awake()
    {
        gm = GameManager.Instance;
        clicker = GetComponent<ClickerComponent>();
        image = GetComponent<RawImage>();
        SetPowerText();
    }

    private void OnEnable()
    {
        clicker.Down += OnDowd;
        clicker.Up += OnUp;
        gm.Power.PowerChanged += SetPowerText;
    }

    private void OnDisable()
    {
        clicker.Down -= OnDowd;
        clicker.Up -= OnUp;
        gm.Power.PowerChanged -= SetPowerText;
    }

    private void SetPowerText()
    {
        powerText.text = gm.Power.Current.ToString();
    }

    private void OnUp()
    {
        image.color = upColor;
        Instantiate(buck, Input.mousePosition, Quaternion.identity, toSpawn.transform);
    }

    private void OnDowd()
    {
        image.color = downColor;
    }
}
