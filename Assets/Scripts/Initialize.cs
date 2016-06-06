using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects;
    public float ObjectDistance;

    private GameObject parent;

	private void Awake ()
    {
        parent = new GameObject("BoidObjects");
        //Camera.main.transform.parent = parent;
        SpawnObjects();
	}

    private void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnLocation = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y + Random.Range(-10f, 10f), transform.position.z + Random.Range(-10f, 10f));
            GameObject newObject = Instantiate(prefab, spawnLocation, Quaternion.identity) as GameObject;
            newObject.name = "BoidObject " + i;
            newObject.transform.parent = parent.transform;
            newObject.GetComponent<BoidBehaviour>().ObjectDistance = ObjectDistance;
        }
    }
}
