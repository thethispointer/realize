using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 2;
    private Animator anim;
    private bool PlayerMoving;
    private Vector2 lastMove;
    private Rigidbody2D myrb2d;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myrb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myrb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, myrb2d.velocity.y);
            PlayerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myrb2d.velocity = new Vector2(myrb2d.velocity.x, Input.GetAxisRaw("Vertical") * speed);
            PlayerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", PlayerMoving);
        anim.SetFloat("LastY", lastMove.y);
        anim.SetFloat("LastX", lastMove.x);
        
    }
}
