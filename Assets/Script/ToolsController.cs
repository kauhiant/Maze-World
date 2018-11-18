using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolsController : MonoBehaviour{

	public bool IsMouseIn { get; private set; }

    public PlayerController player;
    public TimeController timeController;

    public Rect maskRect;

    private void Start()
    {
    }

    public bool RectInclude(Vector2 mousePosition)
    {
        float x = mousePosition.x;
        float y = mousePosition.y;

        // Debug.Log(string.Format("[{0},{1}] , [{2},{3}]", rect.xMin, rect.xMax, rect.yMin, rect.yMax));

        if (x < maskRect.xMin || x > maskRect.xMax || y < maskRect.yMin || y > maskRect.yMax)
            return false;
        else
            return true;
    }
}
