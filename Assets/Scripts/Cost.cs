using System;

public class Cost
{
    public int BaseCost { get; private set; }
    public float Coef { get; private set; }
    public int Current { get; private set; }
    public event Action CostChanged;

    private GameManager gm;

    public Cost(GameManager gameManager, int baseCost, float coef)
    {
        gm = gameManager;
        BaseCost = baseCost;
        Coef = coef;
        SetCost();
        gm.Level.LevelChanged += OnLevelChanged;
    }

    ~Cost()
    {
        gm.Level.LevelChanged -= OnLevelChanged;
    }

    private void SetCost()
    {
        Current = BaseCost + (int)Math.Round(Math.Pow(Coef, gm.Level.Current));
        CostChanged?.Invoke();
    }

    private void OnLevelChanged()
    {
        SetCost();
    }
}