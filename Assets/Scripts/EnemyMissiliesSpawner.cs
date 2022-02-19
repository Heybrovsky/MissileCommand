using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMissiliesSpawner : MonoBehaviour
{
    private bool _canShoot = true;
    [SerializeField]
    private float _SpawnCoolDown;
    public ObjectPooler ObjectPoolerAccess;
    IEnumerator SpawnEnemyMissile()
    {
        while(_canShoot)
        {
            _canShoot = false;
            SpawnEnemyMissiles();
            yield return null;
        }
        yield return new WaitForSeconds(_SpawnCoolDown);
        _canShoot = true;

    }

    private void Update()
    {
        if (_canShoot)
        {
            StartCoroutine(SpawnEnemyMissile());
        }


    }
    void SpawnEnemyMissiles()
    {
        float spawnRange = Random.Range(-18, 18 + 1);
        ObjectPoolerAccess.SpawnFromPool("EnemyMissile", new Vector3(spawnRange, 12, 0), quaternion.identity);
    }
}
