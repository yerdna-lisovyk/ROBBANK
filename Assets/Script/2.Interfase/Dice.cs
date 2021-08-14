using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    
    private Sprite[] _diceSides;
    private Image _image;
    private int _value;
    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
        _diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }
    private IEnumerator RollTheDice()
    {
        BlockPanel.StaticShowBlockPanel();
        int randomDiceSide = 0;
        _value = 0;

        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);
            for (float f = 1; f >= -1; f -= 0.2f)
            {
                transform.localScale = new Vector3(f, transform.localScale.y, transform.localScale.z);
                if (f <= 0)
                    _image.sprite = _image.sprite = _diceSides[randomDiceSide];
                yield return new WaitForSeconds(0.02f);
            }

        }
        _value = randomDiceSide + 1;
        yield return new WaitForSeconds(1f);
        BlockPanel.StaticHideBlockPanel();
        DisePanel.StaticSetFinalValue(_value);
    }
    public void StartRoll()
    {
        StartCoroutine(RollTheDice());
    }

}
