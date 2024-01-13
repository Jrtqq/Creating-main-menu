using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerCollisionManager))]

public class PlayerHealth : MonoBehaviour
{
    private float _maxHealth = 3;
    private float _health;
    private PlayerCollisionManager _collisionManager;

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
    }

    private void OnEnable()
    {
        _collisionManager.Hit += ChangeHealth;
        _collisionManager.Healed += ChangeHealth;
    }

    private void OnDisable()
    {
        _collisionManager.Hit -= ChangeHealth;
        _collisionManager.Healed -= ChangeHealth;
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
