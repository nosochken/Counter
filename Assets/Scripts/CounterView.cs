using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueView;
    [SerializeField] private Counter _counter;

    private int _value;

    private void Awake()
    {
        _valueView.color = Color.green;
    }

    private void OnEnable()
    {
        _counter.ValueIncreased += DisplayCounterValue;
    }

    private void OnDisable()
    {
        _counter.ValueIncreased -= DisplayCounterValue;
    }

    private void DisplayCounterValue()
    {
        _value = _counter.Value;
        _valueView.text = _value.ToString();
    }
}