using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class PlayerCollisionManager : MonoBehaviour
{
    private readonly string _hitTrigger = "hit";

    public UnityAction<float> Hit;
    public UnityAction<float> Healed;
    public UnityAction CoinAdded;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyMover _))
        {
            HitEvent();
        }
        
        if (collision.collider.TryGetComponent(out Coin _))
        {
            AddCoinEvent();
        }
        
        if (collision.collider.TryGetComponent(out Heal _))
        {
            HealEvent();
        }
    }

    public void HitEvent()
    {
        _animator.SetTrigger(_hitTrigger);
        Hit?.Invoke(-1);
    }

    public void AddCoinEvent()
    {
        CoinAdded?.Invoke();
    }

    public void HealEvent()
    {
        Healed?.Invoke(1);
    }
}
