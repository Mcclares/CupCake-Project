using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManagerScript gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
         //Get the mouse position
    float x = Input.mousePosition.x;
    float y = Input.mousePosition.y;
    /* Place the cupcake Tower where the mouse is, transformed in game
    coordinates
    * from the Main Camera. Since the Camera is placed at -10 and we
    want the
    * tower to be at -3, we need to use 7 as z-axis coordinate */
    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));
    //If the player clicks, the second condition checks if the current
    //position is
    //within an area where cupcake towers can be placed
    if (Input.GetMouseButtonDown(0) && gameManager.isPointerOnAllowedArea()) {
    //Enabling again the main cupcake tower script, so to make it
    //operative
    GetComponent<CupcakeTowerScript>().enabled = true;
    //Place a collider on the Cupcake tower
    gameObject.AddComponent<BoxCollider2D>();
    //Remove this script, so to not keeping the Cupcake Tower on the
    Destroy(this);
    }
            
    }
}
