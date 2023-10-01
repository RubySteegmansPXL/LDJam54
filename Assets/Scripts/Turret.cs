using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target = null;
    public GameObject rotatePoint;
    public GameObject firePoint;
    public Bullet bulletPrefab;
    public float range = 10f;
    public float seekSpeed = 2f;
    public float shootSpeed = 1f;

    private float seekTimer;
    private float shootTimer;

    void Start()
    {
        seekTimer = seekSpeed;
        shootTimer = shootSpeed;
    }
    void Update()
    {
        if (target == null)
        {
            seekTimer -= Time.deltaTime;
            if (seekTimer <= 0)
            {
                seekTimer = seekSpeed;
                TargetUpdate();
            }
        }
        TrackEnemy();
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            shootTimer = shootSpeed;
            Shoot();
        }        
    }
    void TargetUpdate()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float shortestDistance = Mathf.Infinity;
        Enemy nearestEnemy = null;
        foreach (Enemy enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
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
        Bullet newBullet = Instantiate(bulletPrefab);
        newBullet.transform.forward = transform.forward;
        newBullet.transform.Rotate(0, -90, 0);
        newBullet.transform.position = firePoint.transform.position;
    }

    void TrackEnemy()
    {
        if (target == null) return;
        if (Vector3.Distance(transform.position, target.transform.position) > range)
        {
            target = null;
        }

        Vector3 targetPosition = target.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);

        transform.Rotate(0, 90, 0);
    }
}
