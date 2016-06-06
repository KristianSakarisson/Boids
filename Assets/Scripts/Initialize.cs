using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects;

    private GameObject parent;

	private void Awake ()
    {
        parent = new GameObject("BoidObjects");
        SpawnObjects();
	}

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z + Random.Range(-10f, 10f));
            GameObject newObject = Instantiate(prefab, spawnLocation, Quaternion.identity) as GameObject;
            newObject.name = "BoidObject " + i;
            newObject.transform.parent = parent.transform;
        }
    }
}
