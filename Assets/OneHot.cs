using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHot : MonoBehaviour {

    public GameObject[] list;
    
    public void SetActive(bool active)
    {
        this.gameObject.SetActive(active);
    }
	
	public void SetOneHot(int index)
    {
        if(index >= list.Length)
        {
            Debug.Log("index too large!");
            return;
        }

        for (int i = 0; i < list.Length; ++i)
        {
            if (i == index)
                list[i].SetActive(true);
            else
                list[i].SetActive(false);
        }

    }
}
