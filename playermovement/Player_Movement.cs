using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]float playerSpeed = 1f;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sp;
    [SerializeField] GameObject AnimationManager;
    AnimationController animc;
    PlayerAnimController PAC;

    float horizontalInput = 0f;
    float verticalInput = 0f;
    Vector3 direction;






    //Player animations(should be with enums):
    const string Idle = "player_idle";
    const string move = "player_move";
    const string dizzy = "player_dizzy";
    const string drinking = "player_drinking";
    const string heartful = "player_hearthful";
    const string wave = "player_wave";


    // Start is called before the first frame update
    void Start()
    {
        PAC = GetComponent<PlayerAnimController>();
        animc = AnimationManager.GetComponent<AnimationController>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Player_Control();
    }

    private void Player_Control()
    {

        

        if (canMove())
        {


            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            direction = new Vector3(horizontalInput, verticalInput, 0);


            transform.Translate(direction * playerSpeed * Time.deltaTime);
            if (Mathf.Abs(horizontalInput) > 0.01f || Mathf.Abs(verticalInput) > 0.01f)
            {
                animc.ChangePlayerAnimState(move);

                if (horizontalInput < 0)
                {
                    sp.flipX = true;
                }
                else if (horizontalInput > 0)
                {
                    sp.flipX = false;
                }

            }
            else
            {

                
                animc.ChangePlayerAnimState(Idle);

            }
        }

       

      
        
    }

    public bool canMove() 
    {
        if (PAC.IsDrinking || PAC.IsWaving || PAC.IsHearthful || PAC.IsDizzy)
        {
            return false;
        }

        return true;
    }
}
