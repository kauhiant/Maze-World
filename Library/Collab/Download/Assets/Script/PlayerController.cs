using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public float maxForce = 5;
    public Boundary margin;
    public Text goldInfo;
    public AudioSource getGold;

    private Rigidbody2D rb;
    private int getGolds = 0;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        InfoUpdate();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizon = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 vector = new Vector2(moveHorizon, moveVertical);
        rb.AddForce(vector * speed);
        margin.InMargin(transform, rb);

        if (rb.velocity.magnitude > maxForce)
            rb.velocity = rb.velocity.normalized * maxForce;

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            Destroy(collision.gameObject);
            ++getGolds;
            InfoUpdate();
            getGold.Play();
        }
    }

    private void InfoUpdate()
    {
        goldInfo.text = string.Format("獲得金塊 : {0}", getGolds);
    }
}
