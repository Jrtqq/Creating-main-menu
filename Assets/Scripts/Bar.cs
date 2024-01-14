using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected PlayerHealth _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Hit += ChangeBar;
        _playerHealth.Healed += ChangeBar;
    }

    private void OnDisable()
    {
        _playerHealth.Hit -= ChangeBar;
        _playerHealth.Healed -= ChangeBar;
    }

    protected abstract void ChangeBar(float value);
}
