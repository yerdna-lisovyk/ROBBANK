using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    /*очистка спрайтов на прозрачный цвет*/
    private void Start()
    {

        if (GetComponent<Image>().sprite == null)
        {
            var sr = transform.GetComponent<Image>();
            sr.color = new Color(1, 1, 1, 0);
        }
        else
        {
            var sr = transform.GetComponent<Image>();
            sr.color = new Color(1, 1, 1, 1f);
        }
    }

}
