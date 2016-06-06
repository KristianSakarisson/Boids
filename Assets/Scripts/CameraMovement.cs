using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private Global stats;
    private Vector3 originalPosition;

	void Start ()
    {
        stats = GameObject.Find("Scripts").GetComponent<Global>();
        originalPosition = transform.position;
	}
	
	void Update ()
    {
        transform.position = originalPosition + stats.CenterOfMass();
	}
}
