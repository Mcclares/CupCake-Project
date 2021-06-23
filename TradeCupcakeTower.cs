using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class TradeCupcakeTower : MonoBehaviour, IPointerClickHandler
{
    protected static SugarMeter sugarMeter;
    protected static CupcakeTowerScript currentActiveTower;
    // How much this tower costs when it is bought


    // Start is called before the first frame update
    void Start()
    {
         if (sugarMeter == null) {
            sugarMeter = FindObjectOfType<SugarMeter>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Increase the value of the tower;
   
        
    }
    // Static function that allows other scripts to assign the new/current selected tower
    public static void setActiveTower(CupcakeTowerScript cupcakeTower) {
        currentActiveTower = cupcakeTower;
    }
    // Abstract function triggered when one of the trading buttons is pressed, however the
    // implementation is specific for each trade operation.
    public abstract void OnPointerClick(PointerEventData eventData);


}
