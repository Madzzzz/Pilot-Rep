using UnityEngine;
using System.Collections;

public class Thrower1 : MonoBehaviour {

    public Transform target;
    public GameObject projectile;
    float distance = 21;
    
	void Start ()
    {

        StartCoroutine(Attack());
	}

    IEnumerator Attack()
    {
        if (distance < 20)
        {
            GameObject projectiletInstance;
            projectiletInstance = Instantiate(projectile, projectile.transform.position, projectile.transform.rotation) as GameObject;
            projectiletInstance.GetComponent<Rigidbody>().useGravity = false;
            projectiletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 400);
            projectiletInstance.GetComponent<Collider>().enabled = false;
            projectiletInstance.AddComponent<Projectile>();
            yield return new WaitForSeconds(0.8f);
            projectiletInstance.GetComponent<Collider>().enabled = true;
        }

        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Attack());
    }

	
	void Update ()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (distance < 30)
        {
            transform.LookAt(target);
        }  
	}
}
