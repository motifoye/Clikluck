using UnityEngine;

public class UpgradeComponent : MonoBehaviour
{
    private GameManager gm;
    public void Awake()
    {
        gm = GameManager.Instance;
    }
    public void Upgrade()
    {
        if (!gm.Money.CanTake(gm.Cost.Current))
            return;
        gm.Money.Take(gm.Cost.Current);
        gm.Level.Add();
    }
}
