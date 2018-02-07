using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : SingletonMono<CameraManager> {

	public BaseActor lookTarget;
	public Vector3 PosOffset;
	public void SetTarget(BaseActor actor)
	{
		lookTarget = actor;
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void LateUpdate()
	{
		if(lookTarget != null)
		{
			this.transform.position = lookTarget.transform.position + PosOffset;
		}
	}
}
