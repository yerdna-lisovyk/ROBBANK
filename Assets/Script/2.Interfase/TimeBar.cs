using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    private Slider _slider;

    [SerializeField] private PlayerMove _button=null;

    bool _step= false;

    public bool IsStep => _step;
    public void SetStep(bool Step)
    {
        
        _step = Step;
    }
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0;
    }
    private void Update()
    {
        _slider.value += Time.deltaTime;
        if(_slider.value == _slider.maxValue)
        {
            _slider.value = 0;
            SetStep(false);
            _button.SetInteractebal(true);
        }
        if(_step)
        {
            _button.SetInteractebal(false);
        }
    }
}
