using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private Enemy enemyComponent;

    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[0];
        enemyComponent = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.Normalize();

        transform.position = transform.position + direction * speed * Time.deltaTime;

        Vector3 targetPosition = target.position;
        transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
        {
            GetNextWaypoint();
        } 
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            GameManager.instance.player.TakeDamage(enemyComponent.damage);
            return;
        }

        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }
}
