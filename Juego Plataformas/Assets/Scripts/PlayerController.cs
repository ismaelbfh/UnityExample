using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float speed = 2f;
    public float maxSpeed = 5f;
    public bool grounded;

    private Rigidbody2D rb2d;
    private Animator anim;

	// Use this for initialization
	private void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Puede dar fallos al usar fisicas 2D
	private void Update () {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
	}

    private void FixedUpdate()
    {
        float ejeHorizontal = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * speed * ejeHorizontal);

        //if(rb2d.velocity.x > maxSpeed)
        //{
        //    rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        //}

        //if (rb2d.velocity.x < -maxSpeed)
        //{
        //    rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        //}

        //Refactorizamos con una funcion que nos aplica un filtro
        //Esto es para limitar la velocidad

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if(ejeHorizontal > 0.1f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }

        if (ejeHorizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
}
