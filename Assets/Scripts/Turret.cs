using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target = null;
    public GameObject rotatePoint;
    public GameObject firePoint;
    public float range = 10f;
    public float seekSpeed = 2f;

    private float seekTimer;

    void Start()
    {
        seekTimer = seekSpeed;

    }
    void Update()
    {
        if (target == null)
        {
            seekTimer -= Time.deltaTime;
            if (seekTimer <= 0)
            {
                Debug.Log("Counter reached");
                seekTimer = seekSpeed;
                TargetUpdate();
            }
        }
        TrackEnemy();
        Shoot();
    }
    void TargetUpdate()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;

        foreach (Enemy enemy in enemies)
        {
            Debug.Log("Looping trough enemies:" + enemies);
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                Debug.Log("Distance: " + shortestDistance);
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance < range) {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        
    }

    void TrackEnemy()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();

        rotatePoint.transform.up = direction;
    }
}
