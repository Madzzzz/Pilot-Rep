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
        GameObject.Find("SpaceWalrusControll").GetComponent<PlayMovieTexture>().PauseSpaceWalrus();
        GameObject.Find("OldGameMusic").GetComponent<SoundControll>().StopSound();
        GameObject.Find("Basic_cube").GetComponent<SoundCollision>().Pause();
        saveCanvas.enabled = true;
        SaveLoad.Save();
        Time.timeScale = 0.00001f;
        yield return new WaitForSeconds(0.00002f); // wait-funksjonen kan ikke kjøre hvis timescalen er lik 0
        Time.timeScale = 1.0f;
        saveCanvas.enabled = false;
        GameObject.Find("SpaceWalrusControll").GetComponent<PlayMovieTexture>().UnPauseSpaceWalrus();
        GameObject.Find("OldGameMusic").GetComponent<SoundControll>().StartSound();
        GameObject.Find("Basic_cube").GetComponent<SoundCollision>().UnPause();
        Destroy(gameObject);
    }
}
