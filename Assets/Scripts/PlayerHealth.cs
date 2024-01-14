using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerCollisionManager))]

public class PlayerHealth : MonoBehaviour
{
    private readonly string _hitTrigger = "hit";

    public UnityAction<float> Hit;
    public UnityAction<float> Healed;

    private float _maxHealth = 3;
    private float _health;
    private PlayerCollisionManager _collisionManager;
    private Animator _animator;

    public float Health
    {
        get { return _health; }
        private set
        {
            if (value > _maxHealth)
            {
                _health = _maxHealth;
            }
            else
            {
                _health = value;
            }
        }
    }
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _health = _maxHealth;
        _collisionManager = GetComponent<PlayerCollisionManager>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Hit += ChangeHealth;
        Healed += ChangeHealth;
    }

    private void OnDisable()
    {
        Hit -= ChangeHealth;
        Healed -= ChangeHealth;
    }

    public void HitEvent()
    {
        _animator.SetTrigger(_hitTrigger);
        Hit?.Invoke(-1);
    }

    public void HealEvent()
    {
        if (Health < MaxHealth)
        {
            Healed?.Invoke(1);
        }
    }

    public void ChangeHealth(float value)
    {
        Health += value;

        if (_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
