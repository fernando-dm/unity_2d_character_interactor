using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true; // es para la transicion entre un salto y correr
    public bool facingRight = true; // arranca mirando hacia la derecha
    public Transform groundCheck; // Es la location para el circulo que me dice donde estoy en la tierra

    private readonly float
        groundCheckRadius = 0.2f; //es el radio que pongo en los pies del personaje!, en este caso SÈ que es 0.2

    // Salto
    private bool grounded; // comienza en el aire, cundo toca el suelo es True
    public LayerMask groundLayer; // me dice que es para chequear lo que toc mi circulo!! en este caso la capa de tierra
    public float jumpPower; // potencia del salto

    public Animator knightAnimator;

    //Movimientos
    public float maxSpeed;
    public float move;

    //Componentes
    private Rigidbody2D myRB; // me refiero al cuerpo del personaje
    private SpriteRenderer myRenderer; // accedo a Sprite Renderer 
    public bool Right;

    // Use this for initialization, y acceso real al componente, arriba solo defino
    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>(); // GetComponent: Encuentra una sola variable! y la devuelve, en este caso mi jugador
        myRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Animator>();

        knightAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //check if grounded 
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,
            groundLayer); //draw a circle to check for ground

        //running code
        move = Input.GetAxis("Horizontal");
        Right = Input.GetKey(KeyCode.D);


        if (canMove && grounded && Input.GetAxis("Jump") > 0) // si puedo moverme y estoy en tierra, puedo saltar!
        {
            myRB.velocity = new Vector2(myRB.velocity.x, 0f); //make sure out force is the same each jump
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); //using a force to make our character jump
            grounded = false;
        }


//        if (canMove)
//        { // si me puedo mover, me muevo
        //estoy parado: Idle
        MoveKnight();

//        }
//        else //if we can't move, then don't move
//        {  // quiero ver si mi circulo esta tocando tierra, 
//            myRB.velocity = new Vector2(0, myRB.velocity.y); // si no me puedo mover seteo a 0
//            myAnim.SetFloat("MoveSpeed", 0); //mi velocidad es 0, no me puedo mover
//        }
    }

    public void MoveKnight()
    {
        if (Math.Abs(myRB.velocity.magnitude) == 0)
        {
            print("no me muevo" + myRB.velocity.x + " - " + myRB.velocity.magnitude);
//                knightAnimator.enabled = false;
//                knightAnimator.enabled = true;
            KnightIdleAnimator();
        }

        //Giro personaje
        if (move > 0 && !facingRight)
            // si presiono derecha y facing es not true
            Flip();
        else if (move < 0 && facingRight) // presiono izquierda y esta mirando a derecha
            Flip();

        RunKnight();
    }

    public void RunKnight()
    {
//Run
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y); //seteo velocidad

        if (Math.Abs(myRB.velocity.magnitude) > 0.1)
        {
            print(" me muevo" + myRB.velocity.x + " - " + myRB.velocity.magnitude);
            KnightRunAnimator();
        }
    }

    private void KnightIdleAnimator()
    {
        knightAnimator.Play("KnightIdle");
    }

    private void KnightRunAnimator()
    {
        knightAnimator.Play("KnightRun");
    }

    public void Flip() // cambia a lo opuesto
    {
        facingRight = !facingRight;
        myRenderer.flipX = !myRenderer.flipX; // cambia en el inspector el sprite renderer el X
    }

    //this function is used in an animation event
    // la llamo desde mi ventana de animation
    public void ToggleCanMove()
    {
        canMove = !canMove;
    }
}