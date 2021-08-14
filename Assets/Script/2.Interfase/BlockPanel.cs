
using UnityEngine;

public class BlockPanel : MonoBehaviour
{
    private static BlockPanel _instans;
    private Transform _hud;
    private GameObject _panel;
    private GameObject _template;

    public static void StaticShowBlockPanel()
    {
        _instans.ShowBlockPanel();
    }

    public static void StaticHideBlockPanel()
    {
        _instans.HideBlockPanel();
    }

    private void Awake()
    {
        _panel = Resources.Load<GameObject>("Object/BlockPanel");
        _hud = GameObject.Find("HUD").transform;
        _instans = GameObject.Find("GameMeneger").GetComponent<BlockPanel>();
    }

    private void ShowBlockPanel()
    {
        if (_template == null)
        {
            _template = Instantiate(_instans._panel, _hud);
            
        }
    }
    private void HideBlockPanel()
    {
        Destroy(_template);
    }
}
