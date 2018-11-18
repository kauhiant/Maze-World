using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HyperLink : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {

    public string url;
    public Color originColor;
    public Color hintColor;
    public bool isText;

    private Image background;
    private Text text;

    // Use this for initialization
    void Start () {
        background = this.gameObject.GetComponent<Image>();
        text = this.gameObject.GetComponent<Text>();
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL(url);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isText)
            text.color = hintColor;
        else
            background.color = hintColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isText)
            text.color = originColor;
        else
            background.color = originColor;
    }

}
