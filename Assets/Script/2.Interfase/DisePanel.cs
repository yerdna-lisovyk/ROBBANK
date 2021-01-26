using UnityEngine;

public class DisePanel : MonoBehaviour
{
    private static DisePanel _instans;
    private int _finalValue = 0;

    public static bool IsActivate => _instans.gameObject.activeSelf == true;
    public static int GetFinalValue => _instans._finalValue;


    public static void StaticSetFinalValue(int NewValue)
    {
        _instans.SetFinalValue(NewValue);
    }
    public static void StaticShowDisce()
    {
        _instans.ShowDise();
    }

    private void Update()
    {
        if (_finalValue != 0)
        {
            HideDise();
        }
    }
    private void Awake()
    {
        _instans = this;
        HideDise();
    }

    private void SetFinalValue(int NewValue)
    {
        _instans._finalValue = NewValue;
    }


    private void HideDise()
    {
        gameObject.SetActive(false);
    }

    private void ShowDise()
    {
        _finalValue = 0;
        gameObject.SetActive(true);
        FindObjectOfType<Dice>().StartRoll();
    }

}
