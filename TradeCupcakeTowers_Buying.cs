using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TradeCupcakeTowers_Buying : TradeCupcakeTower
{
    /* Public variable to identify which tower this script is selling.
    * Ideally, you could have many instances of this script selling
    different
    * Cupcake towers, and the tower is specified in the Inspector */
    public  GameObject cupcakeTowerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnPointerClick(PointerEventData eventData) {
 //Rest of the code
    // Check if the player can afford to buy the tower
    int price = cupcakeTowerPrefab.GetComponent<CupcakeTowerScript>().initialCost;
    if(price <= sugarMeter.getSugarAmount()){
        sugarMeter.ChangeSugar(-price);
        
        GameObject newTower = Instantiate(cupcakeTowerPrefab);
        //The new cupcake tower is also assigned as the current selection
        currentActiveTower = newTower.GetComponent<CupcakeTowerScript>();

    }
    }


}
