using UnityEngine;
using System.Collections;

public class BoidBehaviour : MonoBehaviour {

    private Material material;
    private Vector3 velocity = Vector3.zero;

	private void Start ()
    {
        material = GetComponent<MeshRenderer>().material;
        material.color = Color.cyan;
	}
	
	private void Update ()
    {
	
	}
}
