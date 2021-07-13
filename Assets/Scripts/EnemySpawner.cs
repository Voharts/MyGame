using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _prefabBonus;
    [SerializeField] private GameObject _prefabEmeny; // ссылка на объект который будем создавать
    [SerializeField] private Transform[] _spawnPoint; // координаты
    

    private GameObject _enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, _spawnPoint.Length);
         _enemy = Instantiate(_prefabEmeny, _spawnPoint[index].position, _spawnPoint[index].rotation);
         _enemy.GetComponent<Enemy>().SetMovePoint(_player.gameObject, _spawnPoint);

        
        //enabled = false;

         index = Random.Range(0, _spawnPoint.Length);
         Instantiate(_prefabBonus, _spawnPoint[index].position, _spawnPoint[index].rotation);

    }

    // Update is called once per frame
    void Update()
    {
        //_enemy.transform.Translate(transform.forward * Time.deltaTime);
    }
}
