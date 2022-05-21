using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //
    public float velocidade;
    //
    public int aneis;
    //
    public static bool interruptor;


    // Update is called once per frame
    void Update()
    {
        if (interruptor == false) {
            //
            Rigidbody2D sonic = GetComponent<Rigidbody2D>();
            //O Horizontal é definido na unity no caso esta colocando as teclas pressionada definidas na unity
            float horizontal = Input.GetAxis("Horizontal");
            //
            sonic.velocity = new Vector2(horizontal * velocidade,sonic.velocity.y);
            //

            if (horizontal > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetBool("Andando", true);
            }else if(horizontal < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetBool("Andando", true);
            } 
            else
            {
                GetComponent<Animator>().SetBool("Andando", false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Anel"))
        {
            aneis++;
        }
    }
}
