﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

	public PlayerStats player;
	public GameObject fleshKnight;
	public GameObject flyingMage;
	public GameObject spectre;
	public GameObject axe;
	public GameObject spikes;
	public GameObject darts;
	public GameObject puzzle;

	private GameObject[] level;

	private void SetupLevelArray() {
		switch(SetupManager.instance.selectedCharacter) {
			case SelectedCharacter.mage:
				player.isNeve = true;
				player.isAsgor = false;
				player.isDarius = false;
				break;
			case SelectedCharacter.warrior:
				player.isNeve = false;
				player.isAsgor = false;
				player.isDarius = true;
				break;
			case SelectedCharacter.dwarf:
				player.isNeve = false;
				player.isAsgor = true;
				player.isDarius = false;
				break;
		}
		level = new GameObject[7];
		level[0] = fleshKnight;
		level[1] = flyingMage;
		level[2] = spectre;
		level[3] = axe;
		level[4] = spikes;
		level[5] = darts;
		level[6] = puzzle;
	}
	public void SetupLevel(bool[] bools) {
		SetupLevelArray();
		for(int i = 0; i < bools.Length; i++) {
			level[i].SetActive(bools[i]);
		}
	}
}
