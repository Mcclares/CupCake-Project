using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float health;
    private Animator animator;
    private int AnimDieHash = Animator.StringToHash("DyingTrigger");
    private int AnimExploreTriggerHash = Animator.StringToHash("ExploringTrigger");
    //private int AnimShokHash = Animator.StringToHash("ShokTrigger");
    private Rigidbody2D rb2d;
    //private static GameManagerScript gameManager;
    private int currentWayPointNumber;
    private const float changeDist = 0.001f;

    private  Waypoint gameManager;
    private int currentWaypoint;
    [SerializeField]
    private GameObject firstPunkt;
 
    
   
    

    void Start()
    {
        //Get the reference to the Animator
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
        
        if(gameManager == null) {
            gameManager = FindObjectOfType<Waypoint>();

        }
        if(firstPunkt == null) {
            Debug.Log("Put waypoint");
        }
     
        
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }
    void FixedUpdate() {
        if(currentWaypoint == gameManager.Waypoints.Length) {
            Eat();
            Destroy(this);
            return;


        }
        //float dist = Vector2.Distance(transform.position, gameManager.Waypoints[currentWaypoint]);
        MoveTowards(gameManager.Waypoints[currentWaypoint]);
        //If the waypoint is considered reached because below the threshold of
        //the constant changeDist
        //the counter of waypoints is increased, otherwise the Panda moves
        //towards the waypoint
        /*
        if(dist <= changeDist) {
            currentWaypoint++;
        }else {
            MoveTowards(gameManager.Waypoints[currentWaypoint]);
        }
        */
        
           

        
    }
    //Function that based on the speed of the Panda makes it moving toward the destination point, specified as Vector3
    void MoveTowards(Vector3 destination) {

        float step = speed * Time.fixedDeltaTime;
        rb2d.MovePosition(Vector3.MoveTowards(transform.position, destination, step));
    }

     //Function that takes as input the damage that Panda received when hit by a sprinkle.
     //After have detracted the damage to the amount of health of the Panda checks if the Panda
 //is still alive, and so play the Hit animation, or if the health goes below zero the Die animation

    private void Hit(float damage) {
        
        health -= damage;
        animator.SetBool("ShokBool", true);
  
        //Then it triggers the Die or the Hit animations based if the Panda is still alive 
        if(health <= 0) {
            animator.SetInteger(AnimDieHash, 1);
            
        } 
        Debug.Log(health);
        
    }
    //function that triggers the Eat animation
    private void Eat() {

        animator.SetTrigger(AnimExploreTriggerHash);
    }
    void OnTriggerEnter2D(Collider2D other){
        Collider2D[] colliderCircle = Physics2D.OverlapCircleAll(transform.position, 15f); 
        if(other.tag == "Projectile") {
            if(other.GetComponent<ProjectileScript>().chanceHit == 0){
            Hit(other.GetComponent<ProjectileScript>().damage);
            for(int i = 0; i < colliderCircle.Length; i++) {
                if(i > 2) {
                    animator.SetBool("ShokBool",false);
                    
                } else {
                    animator.SetBool("ShokBool",true);
                }
                Debug.Log(i);
                }
            }
            
        } else {
            Debug.Log("SetTag");
        } 
        
        if(other.tag == "Waypoint") {
            currentWaypoint++;

        }
    
        
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Vector2 first = new Vector2(firstPunkt.transform.position.x,firstPunkt.transform.position.y);
        
        Gizmos.DrawLine(transform.position, first);
       


    }
    
            
    
} 
  

 
