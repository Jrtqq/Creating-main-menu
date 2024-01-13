using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerCollisionManager _playerCollisionManager;
    [SerializeField] private PlayerHealth _playerHealth;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        ChangeText(0);
    }

    private void OnEnable()
    {
        _playerCollisionManager.Hit += ChangeText;
        _playerCollisionManager.Healed += ChangeText;
    }

    private void OnDisable()
    {
        _playerCollisionManager.Hit -= ChangeText;
        _playerCollisionManager.Healed -= ChangeText;
    }

    private void ChangeText(float value)
    {
        _text.text = $"{_playerHealth.Health + value}/{_playerHealth.MaxHealth}";
    }
}
