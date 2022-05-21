using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoBug : MonoBehaviour
{
    //
    public AudioClip efeitoSonoroInfligeDano;
    //
    public float velocidade;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocidade * Time.deltaTime, 0, 0);
    }

    void Girar()
    {
        //
        velocidade *= -1;
        //
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Retorna"))
        {
            Girar();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(efeitoSonoroInfligeDano);
            GetComponent<Animator>().SetBool("Fumaca", true);
            StartCoroutine(EsperaMorte());
        }
    }

    IEnumerator EsperaMorte()
    {
        yield return new WaitForSecondsRealtime(0.6f);
        Destroy(gameObject);
    }
}
