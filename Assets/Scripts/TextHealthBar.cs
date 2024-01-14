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
        ChangeBar(0);
    }

    protected override void ChangeBar(float value)
    {
        _text.text = $"{_playerHealth.Health + value}/{_playerHealth.MaxHealth}";
    }
}
