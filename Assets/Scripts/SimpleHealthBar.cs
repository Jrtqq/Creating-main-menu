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

    protected override void ChangeBar()
    {
        _bar.fillAmount = _health.CurrentHealth / _health.MaxHealth;
    }
}
