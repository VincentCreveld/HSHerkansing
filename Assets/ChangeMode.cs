using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMode : MonoBehaviour {

	public bool isPlaymode;

	private void OnEnable() {
		if(SetupManager.instance != null) {
			if(isPlaymode)
				SetupManager.instance.OnPlayMode();
			else
				SetupManager.instance.OnBuildMode();
		}
	}
}
