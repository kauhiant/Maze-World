using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBox : MonoBehaviour {

    public Text message;

	public void ShowMessage(string message)
    {
        this.gameObject.SetActive(true);
        StopCoroutine("UpdateText");
        StartCoroutine(UpdateText(message));
    }

    public void SetMessage(string message)
    {
        this.gameObject.SetActive(true);
        this.message.text = message;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        StopCoroutine("UpdateText");
    }

    IEnumerator UpdateText(string text)
    {
        int count = 0;
        message.text = "";
        while (count != text.Length)
        {
            message.text += text[count++];
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
