using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10f;

    private Vector3 target;
    private int PathTilesIterator = 0;

    void Start()
    {
        target = PathGenerator.PathTiles[0];
    }

    void Update()
    {
        Vector3 dir = target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target) <= 0.1f)
        {
            getNextTarget();
        }
    }

    void getNextTarget()
    {
        if (PathTilesIterator >= PathGenerator.PathTiles.Count - 1)
        {
            Destroy(gameObject);
            return;
        }
        PathTilesIterator++;
        target = PathGenerator.PathTiles[PathTilesIterator];
    }
}
