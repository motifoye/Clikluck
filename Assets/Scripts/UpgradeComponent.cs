using System;
using UnityEngine;

public class UpgradeComponent : MonoBehaviour
{
    public event Action Clicked;
    private GameManager gm;
    public void Awake()
    {
        gm = GameManager.Instance;
    }
    public void Upgrade()
    {
        Clicked?.Invoke();
        if (!gm.Money.CanTake(gm.Cost.Current))
            return;
        gm.Money.Take(gm.Cost.Current);
        gm.Level.Add();
    }
}
