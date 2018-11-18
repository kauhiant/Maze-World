using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public Vector3 angle;

    private float maxScale;
    private float minScale = 0.5f;
    private float deltaScale = -0.01f;
    private float currentScale = 1;

    private void Start()
    {
        maxScale = this.transform.localScale.x;
        currentScale = maxScale;
    }

    void FixedUpdate () {
        this.transform.Rotate(angle);
        
        currentScale += deltaScale;
        if (currentScale > maxScale || currentScale < minScale)
            deltaScale *= -1;

        this.transform.localScale = new Vector2(currentScale, currentScale);
	}
}
