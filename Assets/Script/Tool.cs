using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tool : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler{

    public ToolsController master;
    public GameObject buildedObj;
    public int costOfTool;

    public bool canUse;
    private Color canUse_color = new Color(1, 1, 1, 1);
    private Color cannotUse_Color = new Color(1, 1, 1, 0.5f);

    private Image image;
    private Sprite sprite;
    private Image temp;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!canUse)
            return;
        
        Time.timeScale = 0;
        temp = new GameObject().AddComponent<Image>();
        temp.transform.SetParent(this.transform.parent);
        temp.sprite = this.sprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!canUse)
            return;

        if (master.timeController.IsStop)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        Destroy(temp.gameObject);

        if (master.RectInclude(eventData.position))
            return;

        var tempObj = Instantiate(buildedObj);
        var posit = Camera.main.ScreenToWorldPoint(eventData.position);
        tempObj.transform.position = new Vector2(posit.x, posit.y);
        master.player.ConsumeCoins(this.costOfTool);

    }

    // Use this for initialization
    void Start () {
        this.image = gameObject.GetComponent<Image>();
        this.sprite = image.sprite;

        if (master.player.Coins < this.costOfTool)
            canUse = false;
        else
            canUse = true;

        UpdateImage();
	}
	
	// Update is called once per frame
	void Update () {
		if(temp != null)
        {
            temp.rectTransform.position = Input.mousePosition;
        }
	}

    private void FixedUpdate()
    {
        if(canUse && master.player.Coins < this.costOfTool)
        {
            canUse = false;
            UpdateImage();
        }
        else if(!canUse && master.player.Coins >= this.costOfTool)
        {
            canUse = true;
            UpdateImage();
        }
    }

    private void UpdateImage()
    {
        if (canUse)
            this.image.color = canUse_color;
        else
            this.image.color = cannotUse_Color;
    }
}
