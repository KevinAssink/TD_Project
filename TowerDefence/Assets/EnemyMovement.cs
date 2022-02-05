using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float enemySpeed = 10f;

	private Transform _target;
	private int _waypointIndex = 0;

	void Start()
	{
		_target = Waypoint.points[0];	
	}

	void Update()
	{
		Vector3 dir = _target.position - transform.position;
		transform.Translate(dir.normalized * enemySpeed * Time.deltaTime); // move to waypoint

		if (Vector3.Distance(transform.position, _target.position) <= 0.2f)
		{
			GetnextWaypoint();
		}

		void GetnextWaypoint() // function to find next waypoint
		{
			if (_waypointIndex >= Waypoint.points.Length - 1) // destroys the enemy after reaching last waypoint
			{
				Destroy(gameObject);
				return;
			}

			_waypointIndex++;
			_target = Waypoint.points[_waypointIndex];
		}
	}
}
