using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerCollisionManager _playerCollisionManager;
    [SerializeField] private PlayerHealth _playerHealth;

    private Image _bar;
    private Coroutine _currentCoroutine = null;
    private float _speed = 2f;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _playerCollisionManager.Hit += StartChangingBar;
        _playerCollisionManager.Healed += StartChangingBar;
    }

    private void OnDisable()
    {
        _playerCollisionManager.Hit -= StartChangingBar;
        _playerCollisionManager.Healed -= StartChangingBar;
    }

    private void StartChangingBar(float value)
    {
        if (_currentCoroutine != null) 
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeBar(value));
    }

    private IEnumerator ChangeBar(float value)
    {
        float target = (_playerHealth.Health + value) / _playerHealth.MaxHealth;

        while (_bar.fillAmount != target)
        {
            _bar.fillAmount = Mathf.MoveTowards(_bar.fillAmount, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
