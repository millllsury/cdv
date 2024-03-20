using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private string _horisontalAxisName;
    [SerializeField] private string _verticalAxisName;

    // Start is called before the first frame update
    

    [SerializeField] private float _speed = 1f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        print(message:"Hello from the start.");

    }

    // Update is called once per frame
    void Update()
    {

        float xAxis = Input.GetAxis(_horisontalAxisName);
        float yAxis = Input.GetAxis(_verticalAxisName);

        _rigidbody2D.velocity = new Vector2(xAxis, yAxis) * _speed;
        
    }
}
