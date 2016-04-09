using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {

    public Canvas saveCanvas;
    public Transform target;
    float distance;

    public void LoadedRemove()
    {
        distance = Vector3.Distance(gameObject.transform.position, target.position);

        if (distance <= 5)
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
