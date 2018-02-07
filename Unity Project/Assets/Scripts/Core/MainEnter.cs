using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnter : MonoBehaviour {
	public BaseActor player;
	// Use this for initialization
	void Start () {
		CameraManager.Instantce.SetTarget(player);
	}

	// Update is called once per frame
	void Update () {
		InputHandler.Instantce.DoUpdate();
	}
}
