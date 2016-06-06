using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global : MonoBehaviour {

    private Vector3 centerOfMass = Vector3.zero;
    private List<GameObject> boidObjects = new List<GameObject>();

    private void Start()
    {
        GameObject[] boidObjectsArray = GameObject.FindGameObjectsWithTag("BoidObject");
        for (int i = 0; i < boidObjectsArray.Length; i++)
        {
            boidObjects.Add(boidObjectsArray[i]);
        }
    }

	private void Update ()
    {
        if (boidObjects != null)
            centerOfMass = FindCenter();
	}

    private Vector3 FindCenter()
    {
        foreach (GameObject boidObject in boidObjects)
        {
            centerOfMass += boidObject.transform.position;
        }
        centerOfMass /= boidObjects.Count;

        return centerOfMass;
    }

    public Vector3 CenterOfMass()
    {
        return centerOfMass;
    }
}
