using System.Collections;

using UnityEngine;

public class AllyCannon : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public ObjectPooler ObjectPoolerAccess;
    private Vector3 _mousePos;
    private bool _canShoot = true;
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && _canShoot)
        {
            StartCoroutine(Shooting());
        }

    }

    private IEnumerator Shooting()
    {
        _canShoot = false;
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0f;
        GameObject go = ObjectPoolerAccess.SpawnFromPool("AllyMissile", transform.position, Quaternion.identity);
        go.GetComponent<Missile>().Destination = _mousePos;
        yield return new WaitForSeconds(0.5f);
        _canShoot = true;
    }
    
    
    
}
