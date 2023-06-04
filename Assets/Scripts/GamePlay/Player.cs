using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float speed = 3f;
    private Vector2 moveVelocity;
    // Start is called before the first frame update

    public ObjectPool pool;
    Score hud;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        hud = GameObject.FindGameObjectWithTag("score").GetComponent<Score>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    
        // Boundss
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9.61f, 9.61f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }

    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        hud.AddPoints(1);
        //Destroy(collision.gameObject);
        pool.ReturnObjectToPool(collision.gameObject);
    }
}
