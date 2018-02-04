using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStorage : MonoBehaviour {

	public int componentCount = 0;

	public bool flyingMage;
	public bool fleshKnight;
	public bool spectre;
	public bool darts;
	public bool spikes;
	public bool axe;
	public bool puzzle;

	public bool[] bools;

	/*
	 if(b && !fleshKnight)
					componentCount++;
				else if(b == false)
					componentCount--;
				if(componentCount < 4) {
					fleshKnight = b;
				}
				else if(b == false && componentCount >= 4) {
					if(fleshKnight == true) {
						fleshKnight = false;
						componentCount--;
					}
				}
	 */

	private void start() {
		bools = new bool[7];
	}

	private void OnEnable() {
		SetupManager.instance.currentEditableLevel = this;
	}

	private void OnDisable() {
		SetupManager.instance.currentEditableLevel = null;
	}

	public void SetBool(bool b, LevelComponent lc) {
		switch(lc) {
			case LevelComponent.flyingMage:
				if(b) {
					if(componentCount < 4) {
						if(flyingMage == false)
							componentCount++;
						flyingMage = true;
					}
				}
				else {
					if(flyingMage) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					flyingMage = false;
				}
				break;
			case LevelComponent.fleshKnight:
				if(b) {
					if(componentCount < 4) {
						if(fleshKnight == false)
							componentCount++;
						fleshKnight = true;
					}
				}
				else {
					if(fleshKnight) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					fleshKnight = false;
				}
				break;
			case LevelComponent.spectre:
				if(b) {
					if(componentCount < 4) {
						if(spectre == false)
							componentCount++;
						spectre = true;
					}
				}
				else {
					if(spectre) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					spectre = false;
				}
				break;
			case LevelComponent.darts:
				if(b) {
					if(componentCount < 4) {
						if(darts == false)
							componentCount++;
						darts = true;
					}
				}
				else {
					if(darts) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					darts = false;
				}
				break;
			case LevelComponent.spikes:
				if(b) {
					if(componentCount < 4) {
						if(spikes == false)
							componentCount++;
						spikes = true;
					}
				}
				else {
					if(spikes) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					spikes = false;
				}
				break;
			case LevelComponent.axe:
				if(b) {
					if(componentCount < 4) {
						if(axe == false)
							componentCount++;
						axe = true;
					}
				}
				else {
					if(axe) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					axe = false;
				}
				break;
			case LevelComponent.puzzle:
				if(b) {
					if(componentCount < 4) {
						if(puzzle == false)
							componentCount++;
						puzzle = true;
					}
				}
				else {
					if(puzzle) {
						componentCount--;
						SetupManager.instance.scanEvent();
					}
					puzzle = false;
				}
				break;
		}

	}

	public bool[] SetupBoolArray() {
		bools = new bool[7];
		bools[0] = fleshKnight;
		bools[1] = flyingMage;
		bools[2] = spectre;
		bools[3] = axe;
		bools[4] = spikes;
		bools[5] = darts;
		bools[6] = puzzle;
		return bools;
	}
}
