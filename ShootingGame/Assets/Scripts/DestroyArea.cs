﻿using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

	void onTriggerExit2D(Collider2D c){
		Destroy (c.gameObject);
	}
}
