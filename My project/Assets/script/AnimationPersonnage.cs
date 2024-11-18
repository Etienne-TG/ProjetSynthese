using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPersonnage : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (animator != null) {

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("startRunning");

            Debug.Log("Course");
        }
        else if (Input.GetKeyUp(KeyCode.W)) {

            animator.SetTrigger("stopRunning");
            Debug.Log("Arret de la course");

        }
        if (Input.GetKeyDown(KeyCode.S)) {

            animator.SetTrigger("startRunningBackwards");
            Debug.Log("Course arrière");
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetTrigger("stopRunningBackwards");
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            animator.SetTrigger("startJump");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetTrigger("stopJump");
        }
    }
}
