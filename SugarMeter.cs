using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarMeter : MonoBehaviour
{
    private Text sugarMeter; //Reference to the Text component
    private int sugar; //Amount of sugar that the player possesses
    
    void Start()
    { //Get the reference to the Sugar_Meter_Text
        sugarMeter = GetComponentInChildren<Text>();
         //Update the Sugar Meter graphic
        UpdateSugarMeter();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSugar(int value) {
        //Function to increase or decrease the amount of sugar

        sugar += value;
         //Check if the amount of sugur is negative, is so set it to zero
        if ( sugar < 0) 
        {
            sugar = 0;

        }
        UpdateSugarMeter();

    }
    //Function to return the amount of sugur, since it is a private variable

    public int getSugarAmount() {
        return sugar;


    }
    //Update the Sugar Meter graphic

    void UpdateSugarMeter(){
         //Assign the amount of sugar converted to a string to the text in the Sugar Meter

         sugarMeter.text = sugar.ToString();



    }
}
