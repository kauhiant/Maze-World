using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundController : MonoBehaviour,IPointerClickHandler {

    public Sprite sound;
    public Sprite mute;
    public AudioSource[] audioSource;

    private Image image;
    private bool isMute = false;

    private void Start()
    {
        this.image = this.gameObject.GetComponent<Image>();
        UpdateImage();
    }

    public void ChangeStatue()
    {
        isMute = !isMute;

        foreach(var e in audioSource)
            e.mute = isMute;
        UpdateImage();
    }

    private void UpdateImage()
    {
        if (isMute)
            image.sprite = mute;
        else
            image.sprite = sound;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeStatue();
    }
}
