using UnityEngine;

public class Missile : MonoBehaviour
{
    private GameObject _objectPooler;

    private float _missileSpeed;
    private float _speed = 10f;
    
    private Vector3 _missileDestinationPoint;
    public Vector3 Destination;
    
    void SetDestination()
    {
        _missileDestinationPoint = Destination;
        _objectPooler = GameObject.Find("ObjectPooler");
    }
    

    void Update()
    {
       Travel();
    }

    void Travel()
    {
        SetDestination();
        _missileSpeed = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,_missileDestinationPoint, _missileSpeed);
        if (transform.position == _missileDestinationPoint)
        {
            _objectPooler.GetComponent<ObjectPooler>().SpawnFromPool("Explosion", _missileDestinationPoint, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
