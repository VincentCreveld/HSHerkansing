using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelComponent {
	flyingMage, fleshKnight, spectre, darts, spikes, axe, puzzle
}

public class SetValue : MonoBehaviour {

	public LevelComponent component;
	//private LevelStorage lastSubmitted;

	private void OnEnable() {
		SetupManager.instance.scanEvent += CheckBool;
		SetupManager.instance.scanEvent();
	}

	private void OnDisable() {
		if(SetupManager.instance.currentEditableLevel != null) {
			SetupManager.instance.currentEditableLevel.SetBool(false, component);
		}
		SetupManager.instance.scanEvent -= CheckBool;
		
	}

	private void CheckBool() {
		if(SetupManager.instance.currentEditableLevel != null) {
			SetupManager.instance.currentEditableLevel.SetBool(true, component);
		}
	}
}
