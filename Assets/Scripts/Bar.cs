using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    private void OnEnable()
    {
        _health.Hit += ChangeBar;
        _health.Healed += ChangeBar;
    }

    private void OnDisable()
    {
        _health.Hit -= ChangeBar;
        _health.Healed -= ChangeBar;
    }

    protected abstract void ChangeBar();
}
