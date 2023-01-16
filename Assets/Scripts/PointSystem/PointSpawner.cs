using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private int _pointsValue = 4;

    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private int _alivePoints;

    private void Start()
    {
        //if not enouth spawn points to spawn all points
        if (_spawnPoints.Count < _pointsValue)
            _pointsValue = _spawnPoints.Count;
     
        PointsSpawn();
    }

    private void PointsSpawn()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.IsUsed = false;
        }

        for (int i = 0; i < _pointsValue; i++)
        {
            bool IsPointSpawned = false;
            int attemptsCount = 0;
            
            while (!IsPointSpawned && (attemptsCount < 10))
            {
                int randPoint = Random.Range(0, _spawnPoints.Count);

                if (!_spawnPoints[randPoint].IsUsed)
                {
                    Instantiate(_pointPrefab, _spawnPoints[randPoint].transform.position, Quaternion.identity);
                    _spawnPoints[randPoint].IsUsed = true;
                    IsPointSpawned = true;
                    Debug.Log("spawn1");
                }
                attemptsCount++;
            }

            if (IsPointSpawned)
                continue;

            //if can't get random spawn point, get the first free spawn point
            foreach (var spawnPoint in _spawnPoints)
            {
                if (!spawnPoint.IsUsed)
                {
                    Instantiate(_pointPrefab, spawnPoint.transform.position, Quaternion.identity);
                }
            }
        }

        _alivePoints = _pointsValue;
    }

    private void PointPiked()
    {
        _alivePoints--;
        if (_alivePoints <= 0)
            PointsSpawn();
    }

    private void OnEnable()
    {
        Point.OnGatePiked += PointPiked;
    }

    private void OnDisable()
    {
        Point.OnGatePiked -= PointPiked;
    }
}
