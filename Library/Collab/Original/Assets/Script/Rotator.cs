﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public Vector3 angle;
    
	
	void FixedUpdate () {
        this.transform.Rotate(angle);
	}
}
