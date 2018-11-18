using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standin : MonoBehaviour {

    private SpriteRenderer sp;
    private float deathRate = 0.02f;
    private float alpha = 1;

	// Use this for initialization
	void Start () {
        sp = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(OneSecond());
	}
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            deathRate *= 10;
    }

    IEnumerator OneSecond()
    {
        while(alpha > 0)
        {
            alpha -= deathRate;
            sp.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(1);
        }

        Destroy(this.gameObject);
    }
}
