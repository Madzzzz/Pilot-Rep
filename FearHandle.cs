using UnityEngine;
using System.Collections;

public class FearHandle : MonoBehaviour {

	public void TransFormFear()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<FearObjects>().Fear();
        }
    }

    public void TransFormFearStop()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<FearObjects>().FearStop();
        }
    }
}
