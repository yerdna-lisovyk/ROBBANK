using System;
using UnityEngine;
using UnityEngine.UI;
public class MassegeBox : MonoBehaviour
{
    private MassegeBox _instans;
    private Transform _hud;
    private GameObject _template;
    private void Awake()
    {
        _template = Resources.Load<GameObject>("Object/BackGround");
        _hud = GameObject.Find("HUD").transform;
        _instans = this;
    }
    public void ShowMassege(string text,string diraction,Action Yes, Action No)
    {
        GameObject massegeBox = Instantiate(_instans._template,_hud);
        Transform panel = massegeBox.transform.Find("MassegeBox");
        Text massegeBoxText = panel.Find("NameMessege").GetComponent<Text>();
        Text massegeBoxDirraction = panel.Find("Dirraction").GetComponent<Text>();
        Button yes = panel.Find("Yes").GetComponent<Button>();
        Button no = panel.Find("No").GetComponent<Button>();

        massegeBoxDirraction.text = diraction;
        massegeBoxText.text = text;
        yes.onClick.AddListener(()=> {
            Yes();
            Destroy(massegeBox);
        });
        no.onClick.AddListener(() => {
            No();
            Destroy(massegeBox);
        });

    }

}
