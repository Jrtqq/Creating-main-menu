using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 3;

    private readonly string _hitTrigger = "hit";

    public UnityAction Hit;
    public UnityAction Healed;
    public UnityAction Died;

    private float _currentHealth;
    private Animator _animator;

    public float CurrentHealth
    {
        get { return _currentHealth; }
        private set
        {
            if (value > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            else
            {
                _currentHealth = value;
            }
        }
    }
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void HitEvent()
    {
        ChangeHealth(-1);
        _animator.SetTrigger(_hitTrigger);
        Hit?.Invoke();
    }

    public void HealEvent()
    {
        if (CurrentHealth < MaxHealth)
        {
            ChangeHealth(1);
            Healed?.Invoke();
        }
    }

    public void ChangeHealth(int value)
    {
        CurrentHealth += value;

        if (_currentHealth <= 0)
        {
            Died?.Invoke();
        }
    }
}
