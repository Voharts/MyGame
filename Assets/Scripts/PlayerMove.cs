using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _speedRotation = 5f;
    private Vector3 _direction;
    private float _angel = 0f;

    public int count = 0;

    public int countDoor = 0;

    private void Awake()
    {
        _direction = Vector3.zero;
    }


    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        
        if(Mathf.Approximately(_direction.magnitude, 0))
        {
            _anim.SetBool("IsWalk", false);
        }
        else 
        {
            _anim.SetBool("IsWalk", true);
        }

        _angel = Input.GetAxis("Mouse X");


    }


    void FixedUpdate()
    {
        var speed = _direction.normalized * _speed * Time.deltaTime;
        // transform.Translate(speed);

        _rb.MovePosition(transform.position + speed);
        //_rb.AddForce(speed, ForceMode.VelocityChange);

        transform.Rotate(Vector3.up * _speedRotation * Input.GetAxis("Mouse X") * Time.deltaTime);
    }


   /* public void CustomFUpdate()
    {
       
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
