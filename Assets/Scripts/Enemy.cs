using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            health--;

            if (health == 0)
            {
                //EZCameraShake.CameraShaker.Instance.ShakeOnce(1f, 5f, 0, 0.2f);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

}
