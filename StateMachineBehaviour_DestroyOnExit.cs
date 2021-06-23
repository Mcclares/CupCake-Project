using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineBehaviour_DestroyOnExit : StateMachineBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Destroy the gameobject where the Animator is attached to
        Destroy(animator.gameObject);
        
    }
}
