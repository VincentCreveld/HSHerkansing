using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectedCharacter {
	mage, warrior, dwarf
}

public delegate void ScanEvent();

public class SetupManager : MonoBehaviour{

	public static SetupManager instance;

	public bool isPlayMode = false;

	public SelectedCharacter selectedCharacter;

	public ScanEvent scanEvent;
	public LevelStorage currentEditableLevel;
	public LevelStorage l0;
	public LevelStorage l1;
	public LevelStorage l2;
	public LevelStorage l3;
	public LevelStorage l4;

	public GameObject lv0;
	public GameObject lv1;
	public GameObject lv2;
	public GameObject lv3;
	public GameObject lv4;

	private void Awake() {
		if(instance == null)
			instance = this;
		else {
			Debug.Log("More than one instance of Setupmanager. destroying.");
			DestroyImmediate(this);
		}
	}

	public void LaunchLevel(int level) {
		ClearLevel();
		switch(level) {
			case 0:
				lv0.SetActive(true);
				lv0.GetComponent<LevelBuilder>().SetupLevel(l0.SetupBoolArray());
				break;
			case 1:
				lv1.SetActive(true);
				lv1.GetComponent<LevelBuilder>().SetupLevel(l1.SetupBoolArray());
				break;
			case 2:
				lv2.SetActive(true);
				lv2.GetComponent<LevelBuilder>().SetupLevel(l2.SetupBoolArray());
				break;
			case 3:
				lv3.SetActive(true);
				lv3.GetComponent<LevelBuilder>().SetupLevel(l3.SetupBoolArray());
				break;
			case 4:
				lv4.SetActive(true);
				lv4.GetComponent<LevelBuilder>().SetupLevel(l4.SetupBoolArray());
				break;
			default:
				break;
		}
	}

	private void ClearLevel() {
		lv0.SetActive(false);
		lv1.SetActive(false);
		lv2.SetActive(false);
		lv3.SetActive(false);
		lv4.SetActive(false);
	}

	public void OnBuildMode() {
		if(isPlayMode) {
			Debug.Log("Engaged build mode!");
			isPlayMode = false;
			ClearLevel();
		}
	}

	public void OnPlayMode() {
		if(!isPlayMode) {
			Debug.Log("Engaged play mode!");
			isPlayMode = true;
		}
	}
}
