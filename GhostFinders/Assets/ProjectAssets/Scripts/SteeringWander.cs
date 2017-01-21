using UnityEngine;
using System.Collections;

public class SteeringWander : MonoBehaviour {

	public Vector3 offset = Vector3.zero;
	public float radius = 1.0f;
	public float min_update = 0.5f;
	public float max_update = 3.0f;

    public bool showGizmos = true;

    Vector3 random_point;
    NavMeshAgent agent = null;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        ChangeTarget();
	}

	// Update is called once per frame
    void Update()
    {
        
    }
    
	void ChangeTarget () 
	{
		random_point = Random.insideUnitSphere;
		random_point *= radius;
		random_point += transform.position + offset;
		random_point.y = transform.position.y;

        agent.SetDestination(random_point);

		Invoke("ChangeTarget", Random.Range(min_update, max_update));
	}

	void OnDrawGizmos() 
	{
        
	}
}
