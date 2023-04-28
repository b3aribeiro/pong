using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Paddle_V2 : MonoBehaviour
{
    public float speed = 20;
    public string axis = "Vertical";

    public Rigidbody2D ball;
    public new Rigidbody2D rigidbody;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    
    /**
    void FixedUpdate()
    {  
        if (this.ball.velocity.x > 0f)
        {
            // Move the paddle in the direction of the ball to track it
            if ((this.ball.position.y - this.GetComponent<Rigidbody2D>().position.y) > 2)
            {
                this.GetComponent<Rigidbody2D>().velocity = (Vector2.up * this.speed);
            }
            else if ((this.ball.position.x - this.GetComponent<Rigidbody2D>().position.x) < -2)
            {
                this.GetComponent<Rigidbody2D>().velocity = (Vector2.down * this.speed);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity *= 0;
            }
        }
        else
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            if (this.GetComponent<Rigidbody2D>().position.y > 0.2f)
            {
                this.GetComponent<Rigidbody2D>().velocity = (Vector2.down * this.speed / 2);
            }
            else if (this.GetComponent<Rigidbody2D>().position.y < -0.2f)
            {
                this.GetComponent<Rigidbody2D>().velocity = (Vector2.up * this.speed / 2);
            }
            else
            {
                this.GetComponent<Rigidbody2D>().velocity *= 0;
            }
        }
    }
    **/ 

    void FixedUpdate()
    {
        Vector2 newPosition;

        if (this.ball.velocity.x > 0f)
        {
            // Move the paddle in the direction of the ball to track it
            newPosition = this.transform.position + (Vector3.up * (this.ball.position.y - this.transform.position.y)).normalized * this.speed * Time.fixedDeltaTime;
            print(newPosition);
        }
        else
        {
            // Move towards the center of the field and idle there until the
            // ball starts coming towards the paddle again
            newPosition = this.transform.position + (Vector3.up * Mathf.Clamp(0f - this.transform.position.y, -0.5f, 0.5f)) * this.speed * Time.fixedDeltaTime / 2;
        }

        // Limit the paddle's movement to within the bounds of the game
        newPosition.y = Mathf.Clamp(newPosition.y, -11f, 11f);

        // Move the paddle to the new position using MovePosition
        this.GetComponent<Rigidbody2D>().MovePosition(newPosition);
    }
    
}
