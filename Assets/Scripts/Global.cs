using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Global : MonoBehaviour {

    private Vector3 centerOfMass = Vector3.zero;
    private int numberOfObjects;
    private List<GameObject> boidObjects = new List<GameObject>();

    private void Start()
    {
        boidObjects = GameObject.FindGameObjectsWithTag("BoidObject").ToList();
        numberOfObjects = boidObjects.Count;
    }

	private void Update ()
    {
        //if (boidObjects != null)
        //    centerOfMass = FindCenter();
	}

    private Vector3 FindCenter()
    {
        centerOfMass = Vector3.zero;

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

    public int NumberOfObjects()
    {
        return numberOfObjects;
    }

    public List<GameObject> GetAllObjects()
    {
        return boidObjects;
    }
}
