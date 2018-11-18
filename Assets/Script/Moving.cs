using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    public float speed = 0.1f;

    public void MoveForward(Vector2 vector)
    {
        float magnitude = vector.magnitude;
        if (magnitude == 0)
            return;

        if (magnitude > 1)
            magnitude = 1;
            
        float angel = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, 0, angel);
        transform.Translate(Vector2.right * speed * magnitude);
    }
    
}
