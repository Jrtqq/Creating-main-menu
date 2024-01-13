using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SimpleHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerCollisionManager _playerCollisionManager;
    [SerializeField] private PlayerHealth _playerHealth;

    private Image _bar;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _playerCollisionManager.Hit += ChangeBar;
        _playerCollisionManager.Healed += ChangeBar;
    }

    private void OnDisable()
    {
        _playerCollisionManager.Hit -= ChangeBar;
        _playerCollisionManager.Healed -= ChangeBar;
    }

    private void ChangeBar(float value)
    {
        _bar.fillAmount = (_playerHealth.Health + value) / _playerHealth.MaxHealth;
    }
}
