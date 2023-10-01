using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        var bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.HitEffect();
            health--;

            if (health == 0)
            {
                GameManager.instance.player.AddMoney(Random.Range(10, 25));
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
