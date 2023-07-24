using System.Collections;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private Enemy _template;
    [SerializeField] private Path _path;

    private readonly float _spawnTime = 2;
    private void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        WaitForSeconds waitForSeconds = new(_spawnTime);

        while (_path.TryGetNextPoint(out Point point))
        {
            Enemy enemy = Instantiate(_template, point.transform.position, Quaternion.identity);
            enemy.MoveToPoint(_targetPosition);
            yield return waitForSeconds;
        }
    }
}
