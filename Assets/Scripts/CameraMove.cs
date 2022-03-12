using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _player;
    private Vector3 _starDistance, _moveVec, _startY;
    private const float _speed = 10;

    private void Start()
    {
        _starDistance = transform.position - _player.position;
        _startY = transform.position;
    }
    private void Update()
    {
        _moveVec = _player.position + _starDistance;
        _moveVec.y = _startY.y;
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _moveVec, _speed * Time.deltaTime);
    }
}
