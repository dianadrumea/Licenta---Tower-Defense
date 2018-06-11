using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public GameObject impactEffect;

    public float speed = 20f;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distancePerFrame, Space.World);
	}

    void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
