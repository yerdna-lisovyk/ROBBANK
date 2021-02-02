using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class MassegeBox : MonoBehaviour
{
    private static MassegeBox _instans;
    private Transform _hud;
    private GameObject _template;
    private void Awake()
    {
        _template = Resources.Load<GameObject>("Object/BackGround");
        _hud = GameObject.Find("HUD").transform;
        _instans = GameObject.Find("GameMeneger").GetComponent<MassegeBox>();
    }
    public static void StaticShowMassege(string text, string diraction, Action Yes, Action No, bool IsExit = false, IEnumerator Rob = null)
    {
        _instans.ShowMassege(text, diraction, Yes, No , IsExit , Rob);
    }
    private void ShowMassege(string text, string diraction, Action Yes, Action No,bool IsExit= false , IEnumerator Rob = null)
    {
        GameObject massegeBox = Instantiate(_instans._template, _hud);
        Transform panel = massegeBox.transform.Find("MassegeBox");
        Text massegeBoxText = panel.Find("Border").GetChild(0).GetComponent<Text>();
        Text massegeBoxDirraction = panel.Find("Backgraund").GetChild(0).GetComponent<Text>();
        Button yes = panel.Find("Yes").GetComponent<Button>();
        Button no = panel.Find("No").GetComponent<Button>();
        Button Exit = panel.Find("Exit").GetComponent<Button>();
        Button ButtonRob = panel.Find("Rob").GetComponent<Button>();

        if (IsExit)
        {
            Exit.onClick.AddListener(() =>
            {
                Destroy(massegeBox);
            });
        }
        else Exit.gameObject.SetActive(false);

        if (Rob !=null)
        {
            ButtonRob.onClick.AddListener(() =>
            {
                StartCoroutine(Rob);
                Destroy(massegeBox);
            });
        }
        else ButtonRob.gameObject.SetActive(false);

        massegeBoxDirraction.text = diraction;
        massegeBoxText.text = text;
        yes.onClick.AddListener(() =>
        {
            Yes();
            Destroy(massegeBox);
        });
        no.onClick.AddListener(() =>
        {
            if(No!=null)
                No();
            Destroy(massegeBox);
        });

    }

}
