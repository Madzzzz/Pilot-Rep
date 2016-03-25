using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public ParticleSystem boom;

    void Start()
    {
        boom = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    IEnumerator OnTriggerEnter(Collider coll)
    {
        boom.Play();
        if(coll.tag == "Player")
        {
            coll.GetComponent<PlayerHealth>().TakeDamage(1);
        }
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
