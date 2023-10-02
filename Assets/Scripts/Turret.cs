using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target = null;
    public GameObject rotatePoint;
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public float range = 10f;
    public float seekSpeed = 2f;
    public float shootSpeed = 1f;
    public float bulletForce = 20f;
    public GameObject barrelRotationPoint;
    public float recoilAngle = 10f;
    public float recoilSpeed = 0.5f;
    public float returnSpeed = 0.25f;

    private Quaternion originalRotation;
    private float seekTimer;
    private float shootTimer;

    void Start()
    {
        seekTimer = seekSpeed;
        shootTimer = shootSpeed;
        EventManager.TowerPlaced();
        originalRotation = barrelRotationPoint.transform.localRotation;
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
        } else
        {
            TrackEnemy();
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {
                shootTimer = shootSpeed;
                Shoot();
            }
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
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        newBullet.transform.forward = firePoint.transform.forward;
        StartCoroutine(RecoilCoroutine());
        EventManager.TurtleShoots();
    }

    private IEnumerator RecoilCoroutine()
    {
        // Rotate the barrel upwards
        float recoilEndTime = Time.time + recoilSpeed;
        while (Time.time < recoilEndTime)
        {
            // Calculate the new rotation for this frame
            float step = recoilSpeed * Time.deltaTime;
            Quaternion recoilRotation = Quaternion.Euler(0, 0, -recoilAngle);
            barrelRotationPoint.transform.localRotation = Quaternion.Lerp(barrelRotationPoint.transform.localRotation, recoilRotation, step);
            yield return null;
        }

        // Gradually rotate the barrel back to its original rotation
        float returnEndTime = Time.time + returnSpeed;
        while (Time.time < returnEndTime)
        {
            // Calculate the new rotation for this frame
            float step = returnSpeed * Time.deltaTime;
            barrelRotationPoint.transform.localRotation = Quaternion.Lerp(barrelRotationPoint.transform.localRotation, originalRotation, step);
            yield return null;
        }

        // Ensure the barrel is exactly at its original rotation
        barrelRotationPoint.transform.localRotation = originalRotation;
    }
    void TrackEnemy()
    {
        if (target == null) return;
        if (Vector3.Distance(transform.position, target.transform.position) > range)
        {
            target = null;
            return;
        }

        Vector3 targetPosition = target.position;
        targetPosition.y = rotatePoint.transform.position.y;
        Quaternion desiredRotation = Quaternion.LookRotation(targetPosition - rotatePoint.transform.position);
        rotatePoint.transform.rotation = Quaternion.Lerp(rotatePoint.transform.rotation, desiredRotation, 0.4f);
    }
}
