using System;

public class Cost
{
    public int Current { get; private set; }
    public event Action CostChanged;

    private GameManager gm;

    public Cost()
    {
        gm = GameManager.Instance;
        SetCost();
        gm.Level.LevelChanged += OnLevelChanged;
    }

    ~Cost()
    {
        gm.Level.LevelChanged -= OnLevelChanged;
    }

    private void SetCost()
    {
        Current = gm.BaseCost + (int)Math.Round(Math.Pow(gm.CoefCost, gm.Level.Current));
        CostChanged?.Invoke();
    }

    private void OnLevelChanged()
    {
        SetCost();
    }
}