using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedGamePerSecond = 0.2f;
    [SerializeField] private float _turnSpeed = 200f;

    private int steerValue;

    void Update()
    {
        _speed += _speedGamePerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * _turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
