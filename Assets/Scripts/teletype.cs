using System.Collections;
using UnityEngine;
using TMPro;

public class teletype : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    private void Start()
    {
        textUI = GetComponent<TextMeshProUGUI>();
		ShowText();
    }
    public void ShowText()
    {
        StartCoroutine("showText", textUI.text);
    }
    IEnumerator showText(string text)
    {
        int i = 0;
        while (i <= text.Length)
        {
            textUI.text = text.Substring(0, i);
            i++;

            yield return new WaitForSeconds(0.025f);
        }
    }
}