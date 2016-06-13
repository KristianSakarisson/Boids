using UnityEngine;
using System.Collections;

public class Initialize : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects;
    public float objectDistance;
    public float repulsion;
    public float maxSpeed;

    private GameObject parent;

	private void Awake ()
    {
        //Time.timeScale = 10;
        Application.runInBackground = true;
        parent = new GameObject("BoidObjects");
        //Camera.main.transform.parent = parent.transform;
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
            newObject.GetComponent<SphereCollider>().radius = objectDistance;
            //newObject.GetComponent<BoidBehaviour>().repulsion = repulsion;

            GameObject followSphere = new GameObject("FollowSphere " + i);
            followSphere.AddComponent<SphereCollider>().radius = 5f;
            followSphere.GetComponent<SphereCollider>().isTrigger = true;
            followSphere.AddComponent<SphereFollow>().toFollow = newObject;
        }
    }
}
