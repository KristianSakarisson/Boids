using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BoidBehaviour : MonoBehaviour {

    private Material material;
    private Vector3 velocity;
    private Vector3 perceivedCenterOfMass;
    private Vector3 perceivedFlockCenter;
    private Global stats;
    private Vector3 currentVelocity;
    private List<Transform> closeObjects = new List<Transform>();
    private List<Transform> flockObjects = new List<Transform>();
    private float maxSpeed;
    private float repulsion;

	private void Start ()
    {
        stats = GameObject.Find("Scripts").GetComponent<Global>();
        material = GetComponent<MeshRenderer>().material;
        material.color = Color.cyan;
        maxSpeed = GameObject.Find("Scripts").GetComponent<Initialize>().maxSpeed;
        repulsion = GameObject.Find("Scripts").GetComponent<Initialize>().repulsion;
    }
	
	private void FixedUpdate ()
    {
        ResetVelocity();
        FindCenter();

        //Boids rules
        GravitateTowardsCenter(); // Rule 1
        KeepDistance(); // Rule 2
        MatchVelocity(); // Rule 3

        ClampVelocity();

        MoveObject();
	}

    private void ResetVelocity()
    {
        velocity = Vector3.zero;
    }

    private void GravitateTowardsCenter()
    {
        //velocity += -transform.position / 4;
        velocity += (perceivedCenterOfMass - transform.position) / 10;
        velocity += perceivedFlockCenter - transform.position;
    }

    private void KeepDistance()
    {
        Vector3 c = Vector3.zero;

        foreach(Transform otherTransform in closeObjects)
        {
            c -= (otherTransform.position - this.transform.position) * repulsion;
        }

        velocity += c;
    }

    private void MatchVelocity()
    {
        Vector3 pv = Vector3.zero; // Perceived velocity

        foreach(GameObject otherObject in stats.GetAllObjects())
        {
            if(otherObject != this.gameObject)
            {
                pv += otherObject.GetComponent<Rigidbody>().velocity * 8;
            }

            pv /= stats.GetAllObjects().Count - 1;
        }

        velocity += pv;
    }

    private void MoveObject()
    {
        if(velocity.magnitude < 1000)
            GetComponent<Rigidbody>().AddForce(velocity);
    }

    private void FindCenter()
    {
        perceivedCenterOfMass = Vector3.zero;

        foreach (GameObject boidObject in stats.GetAllObjects())
        {
            if(boidObject != this.gameObject) //Find center of all boid objects that aren't this object
                perceivedCenterOfMass += boidObject.transform.position;
        }

        perceivedCenterOfMass /= stats.GetAllObjects().Count - 1;

        perceivedFlockCenter = Vector3.zero;

        foreach (Transform boidObject in flockObjects)
        {
            if (boidObject != this.gameObject) //Find center of all boid objects that aren't this object
                perceivedFlockCenter += boidObject.transform.position;
        }

        perceivedFlockCenter /= flockObjects.Count - 1;
    }

    private void ClampVelocity()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(gameObject.GetComponent<Rigidbody>().velocity, maxSpeed);
    }

    public void SetFlock(List<Transform> input)
    {
        flockObjects = input;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != this.transform && !closeObjects.Contains(other.transform) && !other.isTrigger)
        {
            closeObjects.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        closeObjects.Remove(other.transform);
    }
}
