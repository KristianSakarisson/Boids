using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SphereFollow : MonoBehaviour {

    public GameObject toFollow;
    public List<Transform> flockObjects = new List<Transform>();

	void Update ()
    {
        transform.position = toFollow.transform.position;

        //if (toFollow.name == "BoidObject 0")
        //    Debug.Log(flockObjects.Count);
	}

    private void UpdateListOnObject()
    {
        toFollow.GetComponent<BoidBehaviour>().SetFlock(flockObjects);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != toFollow.transform && !flockObjects.Contains(other.transform) && !other.isTrigger)
        {
            flockObjects.Add(other.transform);
            UpdateListOnObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        flockObjects.Remove(other.transform);
        UpdateListOnObject();
    }
}
