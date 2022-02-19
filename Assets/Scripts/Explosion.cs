using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private GameObject _findScore;
    private GameObject _allyBaseValue;
    private Vector3 _startingSize;
    private float _scoreCount = 50f;
    void Start()
    {
        _findScore = GameObject.Find("ScoreTxt");
        _allyBaseValue = GameObject.Find("AllyBases");
        _startingSize = transform.localScale;
    }

    void OnEnable()
    {
        StartCoroutine(SetExplosionInactive());
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Explosion" && col.gameObject.tag != "Ground")
        {
            if (col.gameObject.tag == "EnemyMissile")
            {
                _findScore.GetComponent<Score>().ScoreValue += _scoreCount;
            }else if (col.gameObject.tag == "Cannon")
            {
                _allyBaseValue.GetComponent<AllyBase>().BaseDestroyed++;
            }
            col.gameObject.SetActive(false);
        }

    }

    void Update()
    {
        ScaleUp();
    }

    void ScaleUp()
    {
        transform.localScale += new Vector3(0.2f, 0.2f, 0f) * Time.deltaTime;
    }

    private IEnumerator SetExplosionInactive()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        transform.localScale = _startingSize;
    }
}
