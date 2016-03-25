using UnityEngine;
using System.Collections;

public class BeamControll : MonoBehaviour {

    bool ecstacy = false;
    bool rage = false;
    bool fear = false;
    bool depression = false;

    public ParticleSystem particle;

	void Update()
    {
        ecstacy = Camera.main.GetComponent<Ecstacy>().ecstasyOn;
        rage = Camera.main.GetComponent<Rage>().rageOn;
        fear = Camera.main.GetComponent<Fear>().fearOn;
        depression = Camera.main.GetComponent<Depression>().depressionOn;

        if (Camera.main.GetComponent<MouseScript>().escapePressed == false && Camera.main.GetComponent<MouseScript>().powerMenu == false)
        {
            if (ecstacy == true || rage == true || fear == true || depression == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    particle.Play();
                }
            }
        }
    }
}
