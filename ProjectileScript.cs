using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ProjectileScript : MonoBehaviour
{
    [Range(0,20)]
    [Tooltip("How much damage will the enemy receive")]
    public float damage; //How much damage will the enemy receive
    [Range(0, 20)]
    [Tooltip("How fast the projectile moves")]
    public float speed = 1f; //How fast the projectile moves
    
    [Tooltip("What direction the projectile is heading")]
    public Vector3 direction; //What direction the projectile is heading
    [Range(0,20)]
    [Tooltip("How long the projectile lives before self-destructing")]
    public float lifeDuration = 10f; //How long the projectile lives before self-destructing
    private Animator animator;
    private Rigidbody2D r2bd;
    public int chanceHit;
    
    
     
    void Awake() {
        chanceHit = Random.Range(0,1);

        

    }
    void Start() {
        animator = GetComponent<Animator>();
        r2bd = GetComponent<Rigidbody2D>();
        //random Range
        chanceHit = Random.Range(0,1);
    
    
    
    //Normalize the direction
    direction = direction.normalized;
    
     //Fix the rotation
    float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
    //Set the timer for self-destruction
    Destroy(gameObject, lifeDuration);

    }
    // Update the position of the projectile according to time and speed
    void FixedUpdate() {
    transform.position += direction * Time.deltaTime * speed;
    
    
    }   
void OnTriggerEnter2D() {
    Destroy(gameObject);

}

}
