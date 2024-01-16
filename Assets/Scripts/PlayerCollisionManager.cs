using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player), typeof(Health))]

public class PlayerCollisionManager : MonoBehaviour
{
    private Health _playerHealth;
    private Player _player;

    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        _playerHealth.Died += Die;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= Die;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyMover _))
        {
            _playerHealth.HitEvent();
        }
        
        if (collision.collider.TryGetComponent(out Heal _))
        {
            _playerHealth.HealEvent();
        }

        if (collision.collider.TryGetComponent(out Coin _))
        {
            _player.AddCoinEvent();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
