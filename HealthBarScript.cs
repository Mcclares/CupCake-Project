using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HealthBarScript : MonoBehaviour
{
    public int maxHealth = 100; //The maximum amount of health that the player can possess
    private Image fillingImage; //The reference to "Health_Bar_Filling" Image component
    public int health ; //The current amount of health of the player
    
    private int cureAmount;
    public GameObject Panel;

    private float timer, interval = 5F;
 
    
   

    

    void Start(){
       

        health = maxHealth;
        updateHealthBar();
        Panel.SetActive(false);
        //Function to apply damage to the player
    }
    public bool ApplyDamage(int value){
        health -= value;

        if(health > 0 || health < 0 ) {
            updateHealthBar();
            return false;
        }
        //In case the player has no health left, set health to zero and return true
        health = 0;
        updateHealthBar();
        return true;


    }
    void Update(){
        if( health < (maxHealth * 30 / 100)){
        PanelOpener();
        }
       


    }
    //Function to update the Health Bar Graphic

    void updateHealthBar(){
         //Calculate the percentage (from 0% to 100%) of the current amount of health of the player
        float percentage = health * 1f;
         //Assign the percentage to the fillingAmount variable of the "Health_Bar_Filling"
        fillingImage.fillAmount = percentage;


    }
    void checkHealthBar(int cureAmount) {
        cureAmount = maxHealth - health;
        if(health > maxHealth) health = maxHealth;
    

    }
     public void PanelOpener() {
        timer += Time.deltaTime;
        if(  timer <= interval  ) {
            Panel.SetActive(true);   
        } else if( timer > interval) {
            Panel.SetActive(false);
        }
    
        
    }  
    // void FillingImageColor() {
    //     if(health >= (maxHealth * 40 /100)) {
    //         fillingImage.color = Color.green;
    //     } else if( health >= (maxHealth * 20 / 100) && health < (maxHealth * 40 /100)) {

    //         fillingImage.color = Color.yellow;
    //     } else if(health < (maxHealth * 20 / 100)) {
    //         fillingImage.color = Color.red;
    //     }

    // }

  
}
