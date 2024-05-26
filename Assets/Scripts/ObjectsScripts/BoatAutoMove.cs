using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAutoMove : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    private bool arrived = true;
    private Vector3 startPoint;
    public Vector3 endPoint = new Vector3(-1f, 0, 29.77f);

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        startPoint = this.transform.position;
    }
    private void Start()
    {
        _rb.position = startPoint;
    }

    private void FixedUpdate()
    {
        AutoMove();
    }

    private void AutoMove()
    {
        if(arrived)
        {
            _rb.MovePosition(Vector3.MoveTowards(_rb.position, endPoint, speed * Time.deltaTime));

            if (Vector3.Distance(_rb.position, endPoint) < 0.1f)
            {
                arrived = false;
            } 
        }
        else
        {
            _rb.MovePosition(Vector3.MoveTowards(_rb.position, startPoint, speed * Time.deltaTime));
            if (Vector3.Distance(_rb.position, startPoint) < 0.1f)
            {
                arrived = true;
            }
        }
    }
}
