using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EnableScriptV : MonoBehaviour {

	private Collider collider;
	public MonoBehaviour buildMode;
	public MonoBehaviour playMode;

	private void Start() {
		collider = GetComponent<Collider>();
		buildMode.enabled = false;
		playMode.enabled = false;
	}

	// Makes sure the component script can't run when tracking is not found.
	void Update () {
		if(collider.enabled == true) {
			if(SetupManager.instance.isPlayMode) {
				buildMode.enabled = false;
				playMode.enabled = true;
			}
			else {
				playMode.enabled = false;
				buildMode.enabled = true;
			}
		}
		else {
			buildMode.enabled = false;
			playMode.enabled = false;
		}
	}
}
