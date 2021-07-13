using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turel : MonoBehaviour
{
    /*[SerializeField] private Transform _rotatePoint;
    [SerializeField] private SphereCollider _visionCollider;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;

    private Transform _player;

    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _shootPoint;

    public UnityEvent onEvent;

    // Start is called before the first frame update
    void Start()
    {
        _visionCollider.radius = _distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            GameObject bullet = Instantiate(_prefabBullet, _shootPoint.position, _shootPoint.rotation);
            bullet.transform.Translate(transform.forward * Time.deltaTime * 10f);
            bullet.tag = "bullet";

           //_rotatePoint.LookAt(_player);

            Vector3 targetDir = _player.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.position, targetDir, Time.deltaTime * 100f, 0f);

            transform.rotation = Quaternion.LookRotation(newDir);
        }
        else
            _rotatePoint.Rotate(Vector3.up * Time.deltaTime * 50f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = null;
        }
    }

   /* private void OnTriggerStay(Collider other)
    {
        
    }*/

    [SerializeField] private SphereCollider _visionCollider;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;

    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _shootPoint;

    

    void Start()
    {
        _visionCollider.radius = _distance;
    }

    public float angle;
    public float speed;

    private bool readyShoot = true;
    GameObject go;
    Vector3 targetDir;
    Vector3 newDir;


    public void Update()
    {
        

        if (_player == null)
            return;

        angle = Vector3.Angle(transform.parent.forward, _player.position);

        if (angle <= 10)
        {
            
                    targetDir = _player.position - transform.position;
                    newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0F);

                    transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.z));
                    if (readyShoot)
                    {
                        readyShoot = false;
                        go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        go.transform.position = transform.GetChild(0).position;
                        go.transform.localScale = Vector3.one * 0.2f;
                        go.transform.LookAt(_player.position);
                        go.GetComponent<Collider>().isTrigger = true;
                        go.AddComponent<Rigidbody>().useGravity = false;
                        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 20, ForceMode.Impulse);
                        StartCoroutine(TimeShoot());
                        Destroy(go, 2);
                    }
                      else
                         Debug.DrawLine(_shootPoint.position, _player.position, Color.red, Time.deltaTime);
        }
        else
        {
            Debug.DrawLine(_shootPoint.position, _player.position, Color.blue, Time.deltaTime);

            targetDir = transform.parent.forward - transform.position;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * 2 * Time.deltaTime, 0.0F);

            transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.z));
        }
    }

    IEnumerator TimeShoot()
    {
        yield return new WaitForSeconds(1.5f);
        readyShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = null;
        }
    }

}
