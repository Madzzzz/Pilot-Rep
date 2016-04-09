using UnityEngine;
using System.Collections;

public class PlatformRemove : MonoBehaviour {

	public void DeleteChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<PlatformTrigger>().LoadedRemove();
        }
    }
}
