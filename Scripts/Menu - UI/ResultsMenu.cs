using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultsMenu : MonoBehaviour {

    public Canvas results;

	void Start ()
    {
        results.enabled = true;
	}

    public void noShow()
    {
        results.enabled = false;
    }
}
