using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class ifcutscenefinal : MonoBehaviour
{
	public UnityEvent my_event = new UnityEvent();
    public bool cane = false;

    public PlayableDirector director;

    void Update(){
        if (cane == true && director.state != PlayState.Playing)
        {
			my_event.Invoke();
        }
    }
    public void Cas(){
        cane = true;
    }
}
