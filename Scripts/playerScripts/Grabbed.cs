using UnityEngine;
using System.Collections;

public class Grabbed : MonoBehaviour {
    
    //supportklasse for å passe på at ting som er plukket opp ikke kan klippes igjenom eller bli brukt til å dytte andre objekter

	void OnCollisionEnter(Collision coll)
    {
        Camera.main.GetComponent<GrabbingAndDropping>().dropObject();
    }
}
