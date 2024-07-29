using System;

public class Money
{
    public int Amount { get; private set; }

    public event Action MoneyChanged;

    public void Set(int amount)
    {
        Amount = amount; 
        MoneyChanged?.Invoke();
    }

    public void Add(int count)
    {
        if (count <= 0) return;
        Amount += count;
        MoneyChanged?.Invoke();
    }

    public bool CanTake(int count)
    {
        if (Amount < count)
            return false;
        return true;
    }

    public void Take(int count)
    {
        if (count <= 0) return;
        Amount -= count;
        MoneyChanged?.Invoke();
    }
}
