using System;
using UnityEngine;

public class ClickerComponent : MonoBehaviour
{
    public event Action Down, Up;
    public Power Power { get; private set; }

    public void Awake()
    {
        Power = GameManager.Instance.Power;
    }

    private void OnMouseDown() => Down?.Invoke();

    private void OnMouseUp()
    {
        GameManager.Instance.Money.Add(Power.Current);
        Up?.Invoke();
    }

}
