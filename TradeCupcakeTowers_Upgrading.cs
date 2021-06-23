using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowers_Upgrading : TradeCupcakeTower
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
        //Check if the player can afford to upgrade the tower
    if(currentActiveTower.isUpgradeable && currentActiveTower.upgradingCost <=sugarMeter.getSugarAmount()) {
    //The payment is executed and the sugar removed from the player
    sugarMeter.ChangeSugar(-currentActiveTower.upgradingCost);
    //The tower is upgraded
    currentActiveTower.Upgrade();
}

    }
 

}
