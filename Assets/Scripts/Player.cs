using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerCollisionManager))]

public class Player : MonoBehaviour
{
    private int _coins = 0;
    private PlayerCollisionManager _collisionManager;

    private void Awake()
    {
        _collisionManager = GetComponent<PlayerCollisionManager>();
    }

    private void OnEnable()
    {
        _collisionManager.CoinAdded += AddCoin;
    }

    private void OnDisable()
    {
        _collisionManager.CoinAdded -= AddCoin;
    }

    private void AddCoin()
    {
        _coins++;
        Debug.Log("Coins - " + _coins);
    }
}
