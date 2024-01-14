using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player), typeof(PlayerHealth))]

public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerHealth _health;
    private Player _player;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
        _player = GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyMover _))
        {
            _health.HitEvent();
        }
        
        if (collision.collider.TryGetComponent(out Heal _))
        {
            _health.HealEvent();
        }

        if (collision.collider.TryGetComponent(out Coin _))
        {
            _player.AddCoinEvent();
        }
    }
}
