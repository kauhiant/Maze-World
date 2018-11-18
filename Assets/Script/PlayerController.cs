using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public bool IsDead { get; private set; }
    public int GetGolds { get; private set; }
    public int Coins { get; private set; }
    public AudioSource pickSound;
    
    private Moving moving;

    public void ConsumeCoins(int value)
    {
        this.Coins -= value;
    }

    public void UnDead()
    {
        IsDead = false;
    }


	// Use this for initialization
	void Start () {
        moving = this.GetComponent<Moving>();

        IsDead = false;
        GetGolds = 0;
        Coins = 0;

        StartCoroutine(OneSeconds());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (IsDead)
            return;

        float moveHorizon = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 vector = new Vector2(moveHorizon, moveVertical);

        moving.MoveForward(vector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickup"))
        {
            Destroy(collision.gameObject);
            ++GetGolds;
            pickSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IsDead = true;
        }
    }

    IEnumerator OneSeconds()
    {
        while (!IsDead)
        {
            this.Coins += this.GetGolds;
            yield return new WaitForSeconds(1);
        }
    }


}
