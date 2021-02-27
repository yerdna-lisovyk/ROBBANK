using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    private static TimeBar _instans;
    private Slider _slider;
    private ProfilePlayer _player;

    [SerializeField] private PlayerMove _button = null;
    

    public void StartTimer()
    {
        _slider.value = 0;
        StartCoroutine(GlobalTimer());
    }

    private void Start()
    {
        _instans = this;
        _player = GameObject.Find("GameMeneger").GetComponent<PlayerMeneger>().GetPlayer(0);
        _slider = GetComponent<Slider>();
    }
    private IEnumerator GlobalTimer()
    {
        while (true)
        {
            _slider.value += Time.deltaTime;
            if (_slider.value == _slider.maxValue)
            {
                _slider.value = 0;
                _player.NewTurn();
            }
            if (_player.IsStep)
            {
                _button.SetInteractebal(false);
            }
            else _button.SetInteractebal(true);

            yield return null;
        }

    }
}
