using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchLevel : MonoBehaviour {

	public int levelToLoad = 0;

	private void OnEnable() {
		_LaunchLevel();
	}

	public void _LaunchLevel() {
		SetupManager.instance.LaunchLevel(levelToLoad);
	}

	
}
