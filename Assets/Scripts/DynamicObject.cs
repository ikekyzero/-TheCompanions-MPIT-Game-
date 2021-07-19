using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class DynamicObject : MonoBehaviour
{
	public bool activeObject = false;
	public UnityEvent my_event = new UnityEvent();

	TextMeshProUGUI canvas_name;
	GameObject button_e;
	GameObject button_p;

	bool triggered;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			my_event.Invoke();
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			triggered = false;
		}
	}
}
