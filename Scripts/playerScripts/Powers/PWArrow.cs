using UnityEngine;
using System.Collections;

public class PWArrow : MonoBehaviour {

    Vector3 target;

    void Update()
    {
        target = Input.mousePosition;

        Vector3 targetPostition = new Vector3(target.x, target.y, transform.position.z);
        transform.LookAt(targetPostition);
    }
}
