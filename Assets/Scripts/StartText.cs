using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    public Text superText;//ссылка на текст

    void Start()
    {
        StartCoroutine(myText());// включиои корутин
    }
    IEnumerator myText()//создание корутина с названием майТекст
   {
       superText.gameObject.SetActive(true);//включенпие
       yield return new WaitForSeconds(2f);//задержка
       superText.gameObject.SetActive(false);
   }
}
