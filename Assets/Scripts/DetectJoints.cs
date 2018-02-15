using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {

	public GameObject bodyManager;
	public JointType trackedJoint;
	public float distMultiplier = 1f;
	private BodySourceManager bodyMgr;
	private Body[] bodies;

	// Use this for initialization
	void Start () {
		if (bodyManager == null) {
			Debug.Log ("Assign body manager.");
		} else {
			bodyMgr = bodyManager.GetComponent<BodySourceManager> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (bodyMgr != null) {
			bodies = bodyMgr.GetData ();

			if (bodies != null) {
				foreach (Body body in bodies) {
					if (body != null) {
						if (body.IsTracked) {
							CameraSpacePoint pos = body.Joints [trackedJoint].Position;
							gameObject.transform.position = new Vector3 (pos.X * distMultiplier, pos.Y * distMultiplier, 0f);
						}
					}
				}
			}
		}
	}
}
