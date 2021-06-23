using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Vector3[] Waypoints;

   
    
    void Start()
    {
        Waypoints = new Vector3[transform.childCount];
        for(int i = 0; i < Waypoints.Length; i++) {
            Waypoints[i] = transform.GetChild(i).position;

        }
       
    }
    

    // Update is called once per frame
    void Update()
    {
        
       
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Waypoints = new Vector3[transform.childCount];
        for(int i = 0; i < Waypoints.Length; i++) {
            Waypoints[i] = transform.GetChild(i).position;

        }
        for(int i = 1; i < Waypoints.Length; i++) {
            Gizmos.DrawLine(Waypoints[i-1],Waypoints[i]);

        }

    }
   
}
