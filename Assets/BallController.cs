using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _reflectionRandomization;
    private Vector2 lastRigitbodyVelosity;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallInRandomDirection();
    }

    private void SendBallInRandomDirection()
    {
        _rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), y: Random.Range(-1f, 1f)).normalized * _speed;
        lastRigitbodyVelosity = _rigidbody2D.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.velocity = (Vector2)Vector3.zero;
            _rigidbody2D.simulated = false;
            _rigidbody2D.transform.position = Vector3.zero;
            _rigidbody2D.simulated = true;
            SendBallInRandomDirection();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var reflectedVector = Vector2.Reflect()
        _rigidbody2D.velocity = Vector2.Reflect(inDirection:lastRigitbodyVelosity, other.contacts[0].normal);
        lastRigitbodyVelosity = _rigidbody2D.velocity;
    }
}
