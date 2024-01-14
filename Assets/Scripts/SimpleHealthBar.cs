using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class SimpleHealthBar : Bar
{
    private Image _bar;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    protected override void ChangeBar(float value)
    {
        _bar.fillAmount = (_playerHealth.Health + value) / _playerHealth.MaxHealth;
    }
}
