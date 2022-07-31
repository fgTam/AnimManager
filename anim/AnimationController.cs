using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator animator;
    string currentState;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    public void ChangePlayerAnimState(string newState) 
    {
        
        // Stop animation to interrupting itself
        if (newState == currentState) return;

       
        animator.Play(newState);
        currentState = newState;

    }
}
