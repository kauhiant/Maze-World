using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject target;
    private Transform targetTransform;

    private void Start()
    {
        targetTransform = target.transform;
    }

    // Update is called once per frame
    void LateUpdate () 
    {
        float x = targetTransform.position.x;
        float y = targetTransform.position.y;
        this.transform.position = new Vector3(x, y, -10);
	}
}
