using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public GameObject hitParticles;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
    public void HitEffect()
    {
        GameObject effect = Instantiate(hitParticles, transform.position, transform.rotation);
        Destroy(effect, 2f);
    }
}
