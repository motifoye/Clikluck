using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField]
    private int
        baseLevel = 0,
        baseMoney = 0,
        basePower = 1,
        baseCost = 10;

    [SerializeField]
    private float coefPower = 1.5f, coefCost = 3f;

    public int BaseLevel { get => baseLevel; }
    public int BaseMoney { get => baseMoney; }
    public int BasePower { get => basePower; }
    public int BaseCost { get => baseCost; }
    public float CoefPower { get => coefPower; }
    public float CoefCost { get => coefCost; }

    public Level Level { get; private set; }
    public Money Money { get; private set; }
    public Power Power { get; private set; }
    public Cost Cost { get; private set; }

    private int gameLevel, gameMoney;

    public GameManager()
    {
        instance = this;

        Level = new Level();
        Money = new Money();
        Power = new Power();
        Cost  = new Cost();

    }

    public void Awake()
    {
        gameLevel = PlayerPrefs.GetInt(nameof(gameLevel), BaseLevel);
        gameMoney = PlayerPrefs.GetInt(nameof(gameMoney), BaseMoney);

        Level.Set(gameLevel);
        Money.Set(gameMoney);

    }

    public void OnDestroy()
    {
        PlayerPrefs.SetInt(nameof(gameLevel), gameLevel);
        PlayerPrefs.SetInt(nameof(gameMoney), gameMoney);
    }
}
