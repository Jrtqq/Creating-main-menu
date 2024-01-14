using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SmoothHealthBar : Bar
{
    private Image _bar;
    private Coroutine _currentCoroutine = null;
    private float _speed = 2f;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    protected override void ChangeBar(float value)
    {
        if (_currentCoroutine != null) 
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeBarCoroutine(value));
    }

    private IEnumerator ChangeBarCoroutine(float value)
    {
        float target = (_playerHealth.Health + value) / _playerHealth.MaxHealth;

        while (_bar.fillAmount != target)
        {
            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
