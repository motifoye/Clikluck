using System;

public class Level
{
    public int Current { get; private set; }
    public event Action LevelChanged;

    public void Set(int count)
    {
        Current = count;
        LevelChanged?.Invoke();
    }

    public void Add()
    {
        Current += 1;
        LevelChanged?.Invoke();
    }
}