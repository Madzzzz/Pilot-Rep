using UnityEngine;
using System.Collections;

public class TrapButton1 : MonoBehaviour {

	public void TrapOpen()
    {
        GameObject.Find("TrapSlide").GetComponent<SlidingDoor>().Triggerd();
        StartCoroutine(Pressd());
    }

    IEnumerator Pressd()
    {
        gameObject.transform.Translate(new Vector3(0.0f, -0.1f, 0.0f));
        yield return new WaitForSeconds(0.2f);
        gameObject.transform.Translate(new Vector3(0.0f, 0.1f, 0.0f));

    }
}
