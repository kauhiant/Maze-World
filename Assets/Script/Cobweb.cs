using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cobweb : MonoBehaviour {


    private float speedOffset = 5;
    private float massOffset = 10;

    private List<Moving> movings = new List<Moving>();
    private List<Rigidbody2D> rgs = new List<Rigidbody2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var mov = collision.gameObject.GetComponent<Moving>();
        var rg = collision.gameObject.GetComponent<Rigidbody2D>();

        if(mov != null)
        {
            mov.speed /= speedOffset;
            movings.Add(mov);
        }
        else if(rg != null)
        {
            rg.mass *= massOffset;
            rgs.Add(rg);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var mov = collision.gameObject.GetComponent<Moving>();
        var rg = collision.gameObject.GetComponent<Rigidbody2D>();

        if (mov != null)
        {
            mov.speed *= speedOffset;
            movings.Remove(mov);
        }
        else if (rg != null)
        {
            rg.mass /= massOffset;
            rgs.Remove(rg);
        }
    }

    public void Death()
    {
        foreach(var m in movings)
        {
            m.speed *= speedOffset;
        }

        foreach(var r in rgs)
        {
            r.mass /= massOffset;
        }

        movings.Clear();
        rgs.Clear();
    }

}
