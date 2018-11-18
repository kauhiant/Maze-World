using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {

    public Color enterColor;
    public GameObject hint;
    public AudioSource hint_audio;

    private Image image;
    private Color originColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = enterColor;

        if (hint != null)
            hint.SetActive(true);

        if (hint_audio != null)
            hint_audio.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = originColor;

        if (hint != null)
            hint.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        this.image = gameObject.GetComponent<Image>();
        this.originColor = image.color;
	}

}
