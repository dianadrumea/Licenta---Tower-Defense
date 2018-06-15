using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    public int health = 100;
    public int reward = 25;

    public GameObject deathEffect;

    private Vector3 target;
    private int counter = 0;

    void Start()
    {
        target = PathGenerator.PathTiles[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    { 
        PlayerStats.money += reward;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject);
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
        if (counter >= PathGenerator.PathTiles.Count - 1)
        {
            EndPath();
            return;
        }
        counter++;
        target = PathGenerator.PathTiles[counter];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
