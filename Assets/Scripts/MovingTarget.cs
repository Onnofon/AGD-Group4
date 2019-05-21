using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour {

    public float speed = 5;
    public float waitTime = 0.3f;
    float viewAngle;
    public Transform Pathholder;

    void Start()
    {

        Vector3[] waypoints = new Vector3[Pathholder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints [i] = Pathholder.GetChild (i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        StartCoroutine(FollowPath(waypoints));
    }
    //Coroutine voor oneindig waypoints volgen
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
            }
            yield return null;
        }
    }
    //Lijntjes en balletjes tekenen in scene
    void OnDrawGizmos()
    {
        Vector3 startPosition = Pathholder.GetChild(1).position;
        Vector3 previousPosition = startPosition;
        foreach (Transform waypoint in Pathholder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);
        Gizmos.color = Color.red;
    }

}
