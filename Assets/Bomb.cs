using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    private void Start()
    {
        StartCoroutine(Suicide(0.1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tool"))
        {
            var coweb = collision.gameObject.GetComponent<Cobweb>();
            if (coweb != null)
                coweb.Death();

            Destroy(collision.gameObject);
        }
    }



    IEnumerator Suicide(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(this.gameObject);
    }
}
