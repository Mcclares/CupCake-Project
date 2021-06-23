using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EvilButton : HealthBarScript, IPointerClickHandler
{
    void Start() {
        

    }
    public void OnPointerClick(PointerEventData pointerEventData ) {
        Panel.SetActive(false);
       


    }

}
    
