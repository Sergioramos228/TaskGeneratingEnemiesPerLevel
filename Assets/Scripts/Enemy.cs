using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void MoveToPoint(Vector2 point)
    {
        StartCoroutine(Moving(point));
    }

    private IEnumerator Moving(Vector2 point)
    {
        yield return null;
        Vector3 target = point;

        while(transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
            yield return null;
        }
    }
}
