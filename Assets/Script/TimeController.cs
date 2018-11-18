using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TimeController : MonoBehaviour, IPointerClickHandler {

    public bool IsStop { get; private set; }

    public Sprite play;
    public Sprite stop;
    public KeyCode hotKey;

    private Image image;

    private void Start()
    {
        this.image = this.gameObject.GetComponent<Image>();

        SetStop(false);
    }

    public void ChangeStatus()
    {
        SetStop(!IsStop);
    }

    public void SetStop(bool isStop)
    {
        this.IsStop = isStop;

        if (isStop)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        UpdateImage();
    }

    private void UpdateImage()
    {
        if (IsStop)
            image.sprite = play;
        else
            image.sprite = stop;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeStatus();
    }

    private void Update()
    {
        if (Input.GetKeyDown(hotKey))
        {
            ChangeStatus();
        }
    }
}
