using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class Dialog{
	[SerializeField]
	public int Image_id;
	[SerializeField]
	public string Name;
	[SerializeField]
	[TextArea(15,20)]
	public string description;
}
public class DialogManager : MonoBehaviour
{
	[Header("[ Диалоги ]")]
	public Dialog[] dialogs;
	[Header("[ Компоненты ]")]
	public Image panel_icon;
	public TextMeshProUGUI panel_desc;
	public TextMeshProUGUI panel_name;
	public GameObject dialogPanel;
	public UnityEvent my_event = new UnityEvent();
	public bool event_work = false;
	public bool start_awake = false;

	public bool playeblemoment = false;
	public float speed = 1f;

	[HideInInspector]
	public int dialog_i = 0;
	[HideInInspector]
	public bool dialog_activated = false;
	void Start(){
		if(start_awake == true){
			Activate(null);
        	StartCoroutine("AutoDialog");
		}
	}
	void Update(){
		DialogMain();
	}
	void DialogMain(){
		if (Input.GetKeyDown(KeyCode.P))
		{
			Next();
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Activate(null);
        	StartCoroutine("AutoDialog");
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			if(dialog_activated){
				PlayerMovement.Instance.animator.SetBool("Move", false);
				StopScripts(false);
				PlayerMovement.Instance.rb.velocity = Vector2.zero;
			}
		}
	}
	public void Next(){
		if(dialog_activated){
			dialog_i = dialog_i + 1;
			if (dialog_i + 1 <= dialogs.Length){
				dialogPanel.SetActive(false);
				if(panel_icon != null){
					panel_icon.sprite = Resources.LoadAll<Sprite>("person/icon")[dialogs[dialog_i].Image_id];
				}
				panel_name.text = dialogs[dialog_i].Name;
				panel_desc.text = dialogs[dialog_i].description;
				dialogPanel.SetActive(true);
				panel_desc.transform.GetComponent<teletype>().ShowText();
			} else if(dialog_i + 1 > dialogs.Length){
				dialogPanel.SetActive(false);
				dialogs = null;
				dialog_activated = false;
				StopScripts(true);
        		StopCoroutine("AutoDialog");
				if(event_work == true){
					my_event.Invoke();
				}
			}
		}
	}
	public void Activate(Dialog dialog){
		if(dialog == null){
			dialog_activated = true;
			dialog_i = 0;
			dialogPanel.SetActive(true);
			if(panel_icon != null){
				panel_icon.sprite = Resources.LoadAll<Sprite>("person/icon")[dialogs[dialog_i].Image_id];
			}
			panel_name.text = dialogs[dialog_i].Name;
			panel_desc.text = dialogs[dialog_i].description;
			if(!playeblemoment){
				PlayerMovement.Instance.animator.SetBool("Move", false);
				PlayerMovement.Instance.enabled = false;
			}
		} else {
			Dialog[] temp = new Dialog[1];
			dialogs = temp;
			dialogs[0] = dialog;
			dialog_activated = true;
			dialog_i = 0;
			dialogPanel.SetActive(true);
			if(panel_icon != null){
				panel_icon.sprite = Resources.LoadAll<Sprite>("person/icon")[dialogs[dialog_i].Image_id];
			}
			panel_name.text = dialogs[dialog_i].Name;
			panel_desc.text = dialogs[dialog_i].description;
			if(!playeblemoment){
				PlayerMovement.Instance.animator.SetBool("Move", false);
			}
			StopScripts(false);
		}
	}
	void StopScripts(bool value){
		if(PlayerMovement.Instance != null){
			PlayerMovement.Instance.enabled = value;
		}
	}
	IEnumerator AutoDialog() {
		while(true){
			yield return new WaitForSeconds(speed);
			Debug.Log("sa");
			Next();
        }
	}
}
