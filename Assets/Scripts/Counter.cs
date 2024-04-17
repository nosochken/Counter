using UnityEngine;
using System;
using System.Collections;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(1)] private int _value = 1;
    [SerializeField, Min(0)] private float _delay = 0.5f;

    private int _startingValue = 0;
    private int _currentValue;
    private bool _isOn;
    private WaitForSecondsRealtime _wait;

    public event Action ValueIncreased;

    public int Value => _currentValue;

    private void Awake()
    {
        _currentValue = _startingValue;

        _wait = new WaitForSecondsRealtime(_delay);
    }

    public void Interact()
    {
        _isOn = !_isOn;

        if (_isOn)
            StartCoroutine(IncreaseValueWithDelay());
        else
            StopCoroutine(IncreaseValueWithDelay());
    }

    private IEnumerator IncreaseValueWithDelay()
    {
        while (_isOn)
        {
            _currentValue += _value;

            ValueIncreased?.Invoke();

            yield return _wait;
        }
    }
}