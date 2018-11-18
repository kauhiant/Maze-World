using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour {

    public AudioSource sound;

    private float radius;

    private void Start()
    {
        this.radius = GetComponent<CircleCollider2D>().radius;
    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            sound.volume = 0;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Vector2 vector = collision.gameObject.transform.position - transform.position;
            float dist = vector.magnitude;

            if (dist > radius)
                sound.volume = 0;
            else
                sound.volume = (radius - dist) / radius;
        }
    }
}
