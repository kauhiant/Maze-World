using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeenScope : MonoBehaviour {

    public Enemy master;
    private Vector3 initPosit;

    private void Start()
    {
        initPosit = this.transform.localPosition - Vector3.zero;
    }

    private void FixedUpdate()
    {
        this.transform.localPosition = initPosit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            master.FindTarget(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            master.MissTarget();
    }
    
}
