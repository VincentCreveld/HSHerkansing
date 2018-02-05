using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBar : MonoBehaviour {

	public Transform player;
	// Use this for initialization
	void Update () {
		this.gameObject.transform.LookAt(player.transform);
	}
	
}
