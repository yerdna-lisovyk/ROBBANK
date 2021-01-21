using UnityEngine;

public class SecectionPanel : MonoBehaviour
{
    private static SecectionPanel _instans;
    private int _finalValue = 0;

    public static bool IsActivate => _instans.gameObject.activeSelf == true;

    public static void StaticSetFinalValue(int NewValue)
    {
        _instans.SetFinalValue(NewValue);
    }
    public static void StaticShowSecectionPanel()
    {
        _instans.ShowSecectionPanel();
    }

    public static int GerFinalValue => _instans._finalValue;

    private void Update()
    {
        if (_finalValue != 0)
        {
            HideSecectionPanel();
        }
    }
    private void Awake()
    {
        _instans = this;
        HideSecectionPanel();
    }

    private void SetFinalValue(int NewValue)
    {
        _instans._finalValue = NewValue;
    }


    private void HideSecectionPanel()
    {
        gameObject.SetActive(false);
    }



    private void ShowSecectionPanel()
    {
        _finalValue = 0;
        gameObject.SetActive(true);
        FindObjectOfType<Dice>().StartRoll();
    }

}
