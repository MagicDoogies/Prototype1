using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int movementSpeed;//Controls how fast the player can move left or right.
    
    public Rigidbody2D rigibody;//References the gameobjects rigibody component.
    public Vector2 playerMovement;//Controls player movement.

    public GameManager gameManager;
    private PlayerMovment player;
    public GameObject starShine;
    private SpriteRenderer starAlpha;
    

    private float speedUpTimer; //Countdown timer.

    // Start is called before the first frame update
    void Start()
    {
        speedUpTimer = 1;
        rigibody.gravityScale = 10;
        player = this;
        starAlpha = starShine.GetComponent<SpriteRenderer>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
        playerMovement.x = Input.GetAxisRaw("Horizontal");//Player can move left/right using the WASD or arrow keys. 
        
        speedUpTimer -= 1 * Time.deltaTime;//timer starts counting down.
        if (speedUpTimer <= 0)//If the timer hits zero then-
        {
            rigibody.gravityScale += 2;//Increment the gravity scale of the object by 10
            speedUpTimer = 1;//Reset timer back to 5
            Debug.Log("The mass is " + rigibody.gravityScale);
        }

    }

    private void FixedUpdate()//ensures that the physics work correctly no matter what framerate a given computer is operating on.
    {

        rigibody.MovePosition(rigibody.position + playerMovement * movementSpeed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter2D( Collider2D other)
    {
        
        if ( other.gameObject.CompareTag("Obstacle"))//If the gameobject Player collides with is an obstacle.
        {
            var tempAlpha = starAlpha.color;
            tempAlpha.a -= .1f;
            starAlpha.color = tempAlpha;
           
            gameManager.playerHealth -= 1;//Player loses one health.
        }
        else
        if(other.gameObject.CompareTag("Points"))//If player collides with a point object.
        {
            Object.Destroy(other.gameObject);//Destroys that specific gameobject.
            var tempAlpha = starAlpha.color;//Created a temporary variable to access the Starshine gameobjects sprite alpha.
            tempAlpha.a += .1f;//Every time Player hits a point, the starshine fades in a little more.
            starAlpha.color = tempAlpha; 

            Debug.Log("The transparency is " + starAlpha.color.a);
            gameManager.playerHealth += 1;//They gain health.
            gameManager.playerScore += 1;
            
        }

        if (other.gameObject.CompareTag("Goal"))//If player hits the bottom of the stage
        {
            gameManager.playerWon = true;//Changes the playerWon script to true.
        }
    }
}
