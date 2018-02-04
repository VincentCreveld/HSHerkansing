using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour {

	public SelectedCharacter character;

	private void OnEnable() {
		if(SetupManager.instance != null)
			SetupManager.instance.selectedCharacter = character;
	}
}
