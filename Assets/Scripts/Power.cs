using System;

public class Power
{
    public int Current { get; private set; }
    public event Action PowerChanged;

    private GameManager gm;
    public Power()
    {
        gm = GameManager.Instance;
        SetPower();
        gm.Level.LevelChanged += OnLevelChanged;
    }

    ~Power()
    {
        gm.Level.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged()
    {
        SetPower();
    }

    private void SetPower()
    {
        Current = gm.BasePower + (int)Math.Ceiling(Math.Pow(gm.CoefPower, gm.Level.Current));
        PowerChanged?.Invoke();
    }
}
