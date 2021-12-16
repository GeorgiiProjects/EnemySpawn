using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;

    private Transform[] _points;
    private int _currentPoint;

    private bool _isWorking = true;

    private void Awake()
    {
        StartCoroutine(SpawnEnemy());

        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(2f);

        while (_isWorking)
        {
            yield return waitForSeconds;

            var cloneEnemy = Instantiate(_enemy, _points[_currentPoint].position, transform.rotation);
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}