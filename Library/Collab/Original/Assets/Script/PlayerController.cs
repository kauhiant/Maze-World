using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed = 0.1f;
    public Text goldInfo;

    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private int getGolds = 0;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        sp = this.GetComponent<SpriteRenderer>();
        InfoUpdate();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizon = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 vector = new Vector2(moveHorizon, moveVertical);
        MoveForward(vector);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            Destroy(collision.gameObject);
            ++getGolds;
            InfoUpdate();
        }
    }

    private void InfoUpdate()
    {
        goldInfo.text = string.Format("獲得金塊 : {0}", getGolds);
    }

    private void MoveForward(Vector2 vector)
    {
        float angel = Mathf.Atan2(vector.y, vector.x);
        transform.rotation.Set(0, 0, angel,0);
        


        transform.Translate(vector * speed);
        print(vector);
    }
}
