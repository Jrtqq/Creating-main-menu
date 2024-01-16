using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class TextHealthBar : Bar
{
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        ChangeBar();
    }

    protected override void ChangeBar()
    {
        _text.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}
