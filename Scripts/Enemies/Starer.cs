using UnityEngine;
using System.Collections;

public class Starer : MonoBehaviour {

    public Transform target;
    float distance = 21;

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if (distance < 30)
        {
            transform.LookAt(target);
        }
    }
}
