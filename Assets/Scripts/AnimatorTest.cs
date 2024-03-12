using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    public string triggerToPlay = "Fly";

    //public string boolToPlay = "Fly_bool";

    public KeyCode keyToTrigger = KeyCode.A;
    public KeyCode keyToExist = KeyCode.S;

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyToTrigger))
        {
            //animator.SetTrigger(triggerToPlay);
            //animator.SetBool(triggerToPlay, true);
            animator.SetBool(triggerToPlay, !animator.GetBool(triggerToPlay)); // ! no começo inverte variavel
        } 
        
        /*else if (Input.GetKeyDown(keyToExist))
        {
            animator.SetBool(triggerToPlay, false);
        }*/
    }
}
