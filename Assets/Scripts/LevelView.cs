using UnityEngine;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;

    private GameManager gm;

    public void Awake()
    {
        gm = GameManager.Instance;
        SetText();
    }

    public void OnEnable()
    {
        gm.Level.LevelChanged += SetText;
    }

    public void OnDisable()
    {
        gm.Level.LevelChanged -= SetText;
    }

    public void SetText()
    {
        levelText.text = gm.Level.Current.ToString();
    }


}
