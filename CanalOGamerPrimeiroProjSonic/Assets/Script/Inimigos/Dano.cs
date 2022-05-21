using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    //
    public AudioClip efeitoDano;
    //
    public int aneis;
    //
    public int vidas;
    //
    public float impulsoEsquerdoX;
    //
    public float impulsoEsquerdoY;
    //
    public float impulsoDireitoX;
    //
    public float impulsoDireitoY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ImpulsoEsquerdo"))
        {
            Player.interruptor = true;
            if (aneis > 0)
            {
                aneis = 0;
            }
            else
            {
                vidas--;
            }
            GetComponent<AudioSource>().PlayOneShot(efeitoDano);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsoEsquerdoX, impulsoEsquerdoY));
            StartCoroutine(Espera());
        }

        if (collision.gameObject.CompareTag("ImpulsoDireito"))
        {
            Player.interruptor = true;
            if (aneis > 0)
            {
                aneis = 0;
            }
            else
            {
                vidas--;
            }
            GetComponent<AudioSource>().PlayOneShot(efeitoDano);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsoDireitoX, impulsoDireitoY));
            StartCoroutine(Espera());
        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSecondsRealtime(1);
        Player.interruptor = false;
    }
}
