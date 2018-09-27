using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // Salto
    public float JumpPower; // potencia del salto
    private bool _jump;

    //Ground
    private bool _grounded; // comienza en el aire, cundo toca el suelo es True
    public LayerMask GroundLayer; // me dice que es para chequear lo que toc mi circulo!! en este caso la capa de tierra que setee en cada piso!
    public Transform GroundCheck; // Es la location para el circulo que me dice donde estoy en la tierra
    readonly float groundCheckRadius = 0.2f; //es el radio que pongo en los pies del personaje!, en este caso SÈ que es 0.2

    //Movimientos
    public float MaxSpeed;
    public float Move;
    public bool CanMove = true; // es para la transicion entre un salto y correr

    //Componentes
    private Rigidbody2D _myRb; // me refiero al cuerpo del personaje
    private SpriteRenderer _myRenderer; // accedo a Sprite Renderer 
    private Animator _knightAnimator; // animaciones
    
    public string MovingDirection = "Idle"; // flag default en idle, luego sobreeescribo

    private Dictionary<string, Action> _actionMap = new Dictionary<string, Action>();
    
    // Use this for initialization, y acceso real al componente, arriba solo defino
    private void Start()
    {
        _myRb = GetComponent<Rigidbody2D>(); // GetComponent: Encuentra una sola variable! y la devuelve, en este caso mi jugador
        _myRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Animator>();
        _knightAnimator = GetComponent<Animator>();
        
            _actionMap.Add("Right", RightMove); 
            _actionMap.Add("Left", LeftMove);
            _actionMap.Add("Jump", JumpMove);
            _actionMap.Add("Idle", IdleMove);
    }

    // Update is called once per frame
    private void Update()
    {
        //check if grounded 
        _grounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, GroundLayer); //draw a circle to check for ground

        //Moving code
        _actionMap[MovingDirection].Invoke(); //unicamente se activa cuando tiene un Flag de Button
//        MovingByKeyBoardAndButton();
    }

    private void MovingByKeyBoardAndButton()
    {
        RightMove();
        LeftMove();
        IdleMove();
        JumpMove();
    }


    public void RightMove()
    {
//        print("derecha " +Input.touches.Length);
        if (Input.GetKey(KeyCode.D) || MovingDirection.Equals("Right"))
        {
            _myRenderer.flipX = false;
            Move = 1;
            _myRb.velocity = new Vector2(Move * MaxSpeed, _myRb.velocity.y);
//            Debug.Log("toque D o derecha " + flag + " move: " + Move + " maxspeed " + MaxSpeed);
            KnightRunAnimator();
        }
    }
    
    public void LeftMove()
    {
        if (Input.GetKey(KeyCode.A) || MovingDirection.Equals("Left"))
        {
            _myRenderer.flipX = true;
            Move = -1;
            _myRb.velocity = new Vector2(Move * MaxSpeed, _myRb.velocity.y);
            KnightRunAnimator();
        }
    }
    
    public void IdleMove()
    {
        //chequear que no este saltando
            if (_grounded && MovingDirection.Equals("Idle") && (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)))
            {
                Move = 0f;
                _myRb.velocity = new Vector2(Move * MaxSpeed, _myRb.velocity.y);
                KnightIdleAnimator();
            }
    }
    
    public void JumpMove()
    {
        _jump = Input.GetKey(KeyCode.Space);
        
        if ((CanMove && _grounded && _jump)|| (MovingDirection.Equals("Jump")&& _grounded) ) // si puedo moverme y estoy en tierra, puedo saltar!
        {
            _myRb.velocity = new Vector2(_myRb.velocity.x, 0f); //make sure out force is the same each jump
            _myRb.AddForce(new Vector2(0f, JumpPower), ForceMode2D.Impulse); //using a force to make our character jump
            _grounded = false;
        }
    }

    public void KnightIdleAnimator()
    {
        _knightAnimator.Play("KnightIdle");
    }

    public void KnightRunAnimator()
    {
        _knightAnimator.Play("KnightRun");
    }
}