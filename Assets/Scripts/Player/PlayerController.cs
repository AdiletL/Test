using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private float _speedMove;
    private CharacterController _characterController;
    private Vector3 _moveV;


    private void Start()
    {
        InitLink();
    }
    private void InitLink()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Control();
    }
    public void Control()
    {
        _moveV.z = _floatingJoystick.vertic();
        _moveV.x = _floatingJoystick.horizont();
        if (_moveV != Vector3.zero)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, _moveV, 2f, 1f);
            transform.rotation = Quaternion.LookRotation(direct);
            _characterController.SimpleMove(_moveV * _speedMove * 10);
        }
    }
}
