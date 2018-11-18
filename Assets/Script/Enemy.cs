using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Moving moving;
    private Vector3 vector;
    private Vector3 lastPosition;
    private GameObject target;


    // Use this for initialization
    void Start () {
        moving = this.GetComponent<Moving>();
        lastPosition = transform.position;
        RandomMove();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        // when stay at a space, not moving.
        if ((lastPosition - transform.position).magnitude < moving.speed / 2f)
            RandomMove();

        
        if (target != null) 
            FollowTarget();
            
        lastPosition = transform.position;
        moving.MoveForward(vector);
    }

    // 8 vectors.
    private void RandomMove()
    {
        float x = Random.Range(-1, 2); // -1, 0, 1.
        float y = Random.Range(-1, 2); // -1, 0, 1.
        vector.Set(x, y, 1);
    }

    private void FollowTarget()
    {
        vector = target.transform.position - this.transform.position;
    }



    public void FindTarget(GameObject target)
    {
        this.target = target;
    }

    public void MissTarget()
    {
        this.target = null;
    }
}
