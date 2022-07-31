using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject dogBowl;
    [SerializeField] BoxCollider2D PlayerCollider;
    [SerializeField] GameObject AnimationManager;
    Collider2D recentCollider;
    AnimationController animc;
    

    //Player animations:
    const string Idle = "player_idle";
    const string move = "player_move";
    const string dizzy = "player_dizzy";
    const string drinking = "player_drinking";
    const string heartful = "player_hearthful";
    const string wave = "player_wave";



    public bool IsDrinking = false;
    public bool IsWaving = false;
    public bool IsHearthful = false;
    public bool IsDizzy = false;

    void Start()
    {
        animc = AnimationManager.GetComponent<AnimationController>();
        
    }


    void Update()
    {
        
    }
    void FixedUpdate()
    {



        EmoteManager();
        if (recentCollider != null)
        {
            DrinkingHandler(recentCollider);
        }


    }

    

    void ResetEmotes() {

    
    IsWaving = false;
    IsHearthful = false;
    IsDizzy = false;

}
    void EmoteManager()
    {

        if (!IsDizzy && !IsWaving && !IsHearthful)
        {
            if (Input.GetKey("1"))
            {
                IsWaving = true;
                animc.ChangePlayerAnimState(wave);

                Invoke("ResetEmotes", 1f);
            }
            if (Input.GetKey("2"))
            {
                IsHearthful = true;
                animc.ChangePlayerAnimState(heartful);

                Invoke("ResetEmotes", 2f);
            }
            if (Input.GetKey("3"))
            {
                IsDizzy = true;
                animc.ChangePlayerAnimState(dizzy);

                Invoke("ResetEmotes", 2f);
            }
        }

      


    }


    private void DrinkingHandler(Collider2D recentCollider)
    {
       
        if (PlayerCollider.IsTouching(recentCollider))
        {

            if (PlayerCollider.IsTouching(recentCollider) && Input.GetKey("f") && recentCollider.tag == "DogBowl" && !IsDrinking)
            {

                IsDrinking = true;

                transform.position = new Vector3(dogBowl.transform.position.x - 1f, dogBowl.transform.position.y + 0.5f, -3f);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;

                animc.ChangePlayerAnimState(drinking);

                Invoke("FinishDrinking", 3.8f);
                
            }
           
        }

    }

    void FinishDrinking() 
    {
        IsDrinking = false;
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        recentCollider = other;
    }
}
 