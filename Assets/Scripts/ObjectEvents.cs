using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectEvents : MonoBehaviour{
	private static ObjectEvents _instance;
	public static ObjectEvents Instance { get { return _instance; } }
	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
	}

	public DynamicObject chosenOne;

	public void Door(int i){
		if(Input.GetKeyDown(KeyCode.E)){
			SceneManager.LoadScene(i);
		}
	}
	/*public void TV(string desc){
		if(Input.GetKeyDown(KeyCode.E)){
			chosenOne.GetComponent<Animator>().SetBool("activate", true);
			DialogManager.Instance.Activate(dialog);
		}
	}*/
	/*public void ShowDescription(Dialog dialog){
		if(Input.GetKeyDown(KeyCode.P)){
			DialogManager.Instance.Activate(dialog);
		}
	}*/
	public void OpenFlashBack(){
		SceneManager.LoadScene("flashback");
	}
	public void YouGoToBurningMan(){
		SceneManager.LoadScene("burningman");
	}
	public void OpenScene(string name){
		SceneManager.LoadScene(name);
	}
	public void ChangeChosenone(DynamicObject newChosenOne){
		chosenOne = newChosenOne;
	}
}
