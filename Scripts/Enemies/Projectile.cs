using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public ParticleSystem boom;

    void Start()
    {
        boom = gameObject.GetComponentInChildren<ParticleSystem>();
        StartCoroutine(SelfDestruct());
    }

    IEnumerator OnTriggerEnter()
    {
        boom.Play();
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
