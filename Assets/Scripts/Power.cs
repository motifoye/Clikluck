using System;

public class Power
{
    public int BasePower { get; private set; }
    public float Coef { get; private set; }
    public int Current { get; private set; }
    public event Action PowerChanged;

    private GameManager gm;
    public Power(GameManager gameManager, int basePower, float coef)
    {
        gm = gameManager;
        BasePower = basePower;
        Coef = coef;
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
        Current = BasePower + (int)Math.Ceiling(Math.Pow(Coef, gm.Level.Current));
        PowerChanged?.Invoke();
    }
}
