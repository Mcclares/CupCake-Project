using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TradeCupcakeTowers_Selling : TradeCupcakeTower
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnPointerClick(PointerEventData eventData) {
        //Check if there is a tower selected before to proceed
    if (currentActiveTower == null)
    return;
    //Add to the player's sugar the value of the tower
    sugarMeter.ChangeSugar(currentActiveTower.sellingValue);
    //Remove the cupcake tower from the scene
    Destroy(currentActiveTower);
    }

}
