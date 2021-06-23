using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Vector3[] waypoints;
    public Waypoint firstWaypoint;
    private BoxCollider2D  boxCol;
    //Private variable to check if the mouse is hovering an area where
    //Cupcake tower can be placed
    private bool _isPointerOnAllowedArea = true;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Function that returns true if the mouse is hovering an area where a
//Cupcake tower can be placed
    public bool isPointerOnAllowedArea() {
    return _isPointerOnAllowedArea;
    }
    //Function which is called when the mouse enters in one of the
//colliders of the Game Manager
    void OnMouseEnter() {
 //Set that the mouse is now hovering an area where placing Cupcake
 //towers is allowed
    _isPointerOnAllowedArea = true;
    }
//Function which is called when the mouse exits from one of the
//colliders of the Game Manager
    void OnMouseExit() {
 //Set that the mouse is not hovering anymore an area where placing
 //Cupcake towers is allowed
    _isPointerOnAllowedArea = false;
    }
    void OnDrawGizmos() {
        boxCol = GetComponent<BoxCollider2D>();
        Color colorClean = new Color(1,1,1,0.75F);
     
        Gizmos.color = colorClean;
        
    
       
        Gizmos.DrawCube( new Vector2(transform.position.x,transform.position.y), new Vector2(boxCol.size.x,boxCol.size.y)); 

    }

}
