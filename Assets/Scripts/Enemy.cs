using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _speed = 3;
    [SerializeField] private float _angle = 3;
    [SerializeField] private GameObject _player;

    private Quaternion _ang;
    private Transform[] _movePoints;
    private int _currentPoint = 0;
    private bool _isMove;
    public void SetMovePoint(GameObject player, params Transform[] movePoints)
    {
        _player = player;
        _movePoints = movePoints;
        _isMove = true;
    }

    void FixedUpdate()
    {
        if (_isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _movePoints[_currentPoint % _movePoints.Length].position, Time.fixedDeltaTime * _speed);
            if(Vector3.Distance(transform.position, _movePoints[_currentPoint % _movePoints.Length].position) < 0.2f)
            
                _currentPoint++;


            Vector3 targetDir = _movePoints[_currentPoint % _movePoints.Length].position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.position, targetDir, Time.fixedDeltaTime * 100f, 0f);

            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
}
