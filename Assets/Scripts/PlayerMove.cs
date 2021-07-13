using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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

        _angel = Input.GetAxis("Mouse X");
    }

    private void FixedUpdate()
    {
        var speed = _direction.normalized * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);

        transform.Rotate(Vector3.up * _speedRotation * Input.GetAxis("Mouse X") * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
