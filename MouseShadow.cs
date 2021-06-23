using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MouseShadow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  


    private Shadow shadow;
    private Text text;
    private int shad;
   
    void  Start() {

        shadow = GetComponent<Shadow>();
        text = GetComponent<Text>();
        
       
        
    }
    void Update() {

    
        

    }
  
    public void OnPointerEnter(PointerEventData eventData) {
        
        if(eventData.position.y < 280 & eventData.position.y > 260 & eventData.position.x > 400 & eventData.position.x < 500) {
            shadow.effectDistance = new Vector2(0,-25);

        }
        else if(eventData.position.y > 210  & eventData.position.y < 220 & eventData.position.x > 400 & eventData.position.x < 500) {
            shadow.effectDistance = new Vector2(0,25);
        }
        if(eventData.position.x < 400) {
            shadow.effectDistance = new Vector2(-5,0);
        }else if(eventData.position.x > 500) {
            shadow.effectDistance = new Vector2(5,0);
        }
        
       
        Debug.Log(eventData.position);
      

    }
    public void OnPointerExit(PointerEventData eventData) {
    
        shadow.effectDistance = new Vector2(0,0);

    }
    
    
    // void OnGUI() {
    //     Event e;
    //     e = Event.current;
      
    //     if (e.mousePosition.y > 286.0F )
    //     {
    //        Cursor.SetCursor(text1,hotSpot,cursorMode);
    //     }
    //     else{
    //         Cursor.SetCursor(null,hotSpot,cursorMode);
    //     }
    //     if(e.mousePosition != null) {
    //         Debug.Log(e.mousePosition);
    //     }

    // }
 }
