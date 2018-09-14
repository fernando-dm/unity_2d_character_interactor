using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrar : MonoBehaviour
{

    Rigidbody2D myRB;           // me refiero al cuerpo del personaje
    bool facingRight = true;    // arranca mirando hacia la derecha
    public float maxSpeed;
    SpriteRenderer myRenderer;  // accedo a Sprite Renderer 
    Animator myAnim;            // accedo a la animacion de Animator

    bool grounded = false;          // comienza en el aire, cundo toca el suelo es True
    float groundCheckRadius = 0.2f; //es el radio que pongo en los pies del personaje!, en este caso SÈ que es 0.2
    public LayerMask groundLayer;   // me dice que es para chequear lo que toc mi circulo!! en este caso la capa de tierra
    public Transform groundCheck;   // Es la location para el circulo que me dice donde estoy en la tierra
    public float jumpPower;         // potencia del salto
    private bool canMove=true;      // es para la transicion entre un salto y correr


    // Use this for initialization, y acceso real al componente, arriba solo defino
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); // GetComponent: Encuentra una sola variable! y la devuelve, en este caso mi jugador
        myRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && grounded && Input.GetAxis("Jump") > 0) // si puedo moverme y estoy en tierra, puedo saltar!
        {
            myAnim.SetBool("isGrounded", false);
            myRB.velocity = new Vector2(myRB.velocity.x, 0f);               //make sure out force is the same each jump
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);  //using a force to make our character jump
            grounded = false;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); //draw a circle to check for ground
        myAnim.SetBool("isGrounded", grounded);

        float move = Input.GetAxis("Horizontal");

        if (canMove){ // si me puedo mover, me muevo

            if (move > 0 && !facingRight)
                   // si presiono derecha y facing es not true
                Flip();
            else if (move < 0 && facingRight)   // presiono izquierda y esta mirando a derecha
                    Flip();

                myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); //seteo velocidad
                myAnim.SetFloat("MoveSpeed", Mathf.Abs(move));
            }
            else //if we can't move, then don't move
            {  // quiero ver si mi circulo esta tocando tierra, 
                myRB.velocity = new Vector2(0, myRB.velocity.y); // si no me puedo mover seteo a 0
                myAnim.SetFloat("MoveSpeed", 0); //mi velocidad es 0, no me puedo mover
            }

    }

    private void Flip() // cambia a lo opuesto
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX; // cambia en el inspector el sprite renderer el X
    }
    //this function is used in an animation event
    // la llamo desde mi ventana de animation
    public void toggleCanMove()
    {
        canMove = !canMove;
    }
}
