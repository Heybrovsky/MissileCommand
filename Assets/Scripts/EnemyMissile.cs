using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMissile : MonoBehaviour
{
    private GameObject _objectPooler;
    private float _randomAttackPosition;
    private float _step;
    private float _missileSpeed = 5f;

    private void OnEnable()
    {
        _objectPooler = GameObject.Find("ObjectPooler");
        _randomAttackPosition = Random.Range(-14f, 14f + 1f);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        _objectPooler.GetComponent<ObjectPooler>().SpawnFromPool("Explosion", transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    void Update()
    {
        EnemyMissileMovement();
    }

    void EnemyMissileMovement()
    {
        _step = _missileSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(_randomAttackPosition, -5f, 0), _step);
    }
}
