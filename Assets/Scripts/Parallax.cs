using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _distance;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized;
        float x = Mathf.Lerp(transform.position.x, _startPosition.x + (mousePosition.x * _distance), _speed * Time.deltaTime);
        float y = Mathf.Lerp(transform.position.y, _startPosition.y + (mousePosition.y * _distance), _speed * Time.deltaTime);

        transform.position = new Vector3(x, y, 0);
    }
}
