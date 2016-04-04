using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {

    public Canvas saveCanvas;
    public Transform target;
    float distance;

    void Start()
    {
        distance = Vector3.Distance(transform.position, target.position);

        if(distance <= 5)
            if (GameObject.Find("OldBubbaManager").GetComponent<BubbaManager>().loaded == true)
                Destroy(gameObject);
    }

	void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
            StartCoroutine(SaveGame());
    }

    IEnumerator SaveGame()
    {
        saveCanvas.enabled = true;
        SaveLoad.Save();
        Time.timeScale = 0.00001f;
        yield return new WaitForSeconds(0.00002f);
        Time.timeScale = 1.0f;
        saveCanvas.enabled = false;
        Destroy(gameObject);
    }
}
