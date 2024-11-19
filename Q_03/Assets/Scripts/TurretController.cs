using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;           // 1.5 잘 기입되있음
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private GameObject _target;

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        FindPlayer();
        Fire(_target.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
        FindPlayer();
    }

    // 플레이어 찾는 함수 작성
    private void FindPlayer()
    {
        _target = GameObject.FindWithTag("Player");
        // _target.transform.position;
    }
    private IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return _wait;
            
            transform.rotation = Quaternion.LookRotation(_target.transform.position);
            
            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken();
            
        }
    }

    private void Fire(Transform target)
    {
        _coroutine = StartCoroutine(FireRoutine());
    }
}
