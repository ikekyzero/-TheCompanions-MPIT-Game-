using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
	public int i = 0;
    void Update()
	{
		if(Input.GetKeyDown(KeyCode.P)){
			SceneManager.LoadScene(i+1);
		}
    }
}
