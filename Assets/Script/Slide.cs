using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slide : MonoBehaviour {

    public int times = 2;
    public Image front;
    public Image back;
    public Sprite[] slides;

    private int current;
    private int hundred;
    private int waitTime;

	// Use this for initialization
	void Start ()
    {
        waitTime = -100 * times;
        SetFrontBack();
	}
	
	// Update is called once per frame
	void Update ()
    {
        --hundred;

        if (hundred > 0)
        {
            front.color = new Color(1, 1, 1, hundred / 100f);
        }
        else  if (hundred == waitTime)
        {
            ChangeSlide();
        }
	}

    private void ChangeSlide()
    {
        ++current;

        if (current == slides.Length)
            current = 0;

        SetFrontBack();
    }

    private void SetFrontBack()
    {
        front.sprite = slides[current];
        front.color = Color.white;
        hundred = 100;

        int next = (current + 1) % slides.Length;
        back.sprite = slides[next];
    }
}
