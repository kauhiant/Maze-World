using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public Vector3 angle;
    
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(angle);
	}
}
