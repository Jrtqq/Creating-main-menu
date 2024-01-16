using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class VampireSkill : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;

    private bool isCasting = false;
    private int _duration = 6;
    private float _time;
    private int _cooldown = 5;
    private int _radius = 5;
    private Health _player;

    private Coroutine _coroutine;

    private void Awake()
    {
        _time = _cooldown;
        _player = GetComponent<Health>();
    }

    private void Update()
    {
        if (isCasting == false)
            _time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && _time >= _cooldown)
        {
            _coroutine = StartCoroutine(Cast());
        }
    }
    
    private IEnumerator Cast()
    {
        isCasting = true;
        _time = 0;

        Health enemy = TryFindEnemy();
        var delay = new WaitForSeconds(1f);

        for (int i = 0; i < _duration; i++)
        {
            if (enemy == null)
            {
                isCasting = false;
                yield break;
            }

            enemy.HitEvent();
            _player.HealEvent();

            yield return delay;
        }

        isCasting = false;
    }

    private Health TryFindEnemy()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _enemyLayerMask);

        if (hit != null)
        {
            hit.TryGetComponent(out Health enemy);
            return enemy;
        }

        return null;
    }
}
