using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBonus;
    [SerializeField] private GameObject _prefabEmeny; // ссылка на объект который будем создавать
    [SerializeField] private Transform[] _spawpoint; // координаты
    

    private GameObject _enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, _spawpoint.Length);
         _enemy = Instantiate(_prefabEmeny, _spawpoint[0].position, _spawpoint[index].rotation);

        //Destroy(gameObject.GetComponent<EnemySpawner>());
        //gameObject.SetActive(false);

        enabled = false;

         index = Random.Range(0, _spawpoint.Length);
         Instantiate(_prefabBonus, _spawpoint[0].position, _spawpoint[index].rotation);

    }

    // Update is called once per frame
    void Update()
    {
        _enemy.transform.Translate(transform.forward * Time.deltaTime);
    }
}
