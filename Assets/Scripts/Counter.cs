using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField, Min(1)] private int _value = 1;
    [SerializeField, Min(0)] private float _delay = 0.5f;
    [SerializeField] private Button _button; 

    private int _startingValue = 0;
    private int _currentValue;
    private float _elapsedTime = 0;
    private bool _isOn;
    private Coroutine _coroutine;

    public event Action ValueIncreased;

    public int Value => _currentValue;

    private void Awake()
    {
        _currentValue = _startingValue;
    }

    private void Start()
    {
        _button.onClick.AddListener(Interact);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Interact);
    }

    private void Interact()
    {
        _isOn = !_isOn;

        if (_isOn)
        {
            _coroutine = StartCoroutine(IncreaseValueWithDelay());
        }
        else
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }

    private IEnumerator IncreaseValueWithDelay()
    {
        while (_isOn)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _delay)
            {
                _elapsedTime -= _delay;
                _currentValue += _value;
                ValueIncreased?.Invoke();
            }

            yield return null;
        }
    }
}