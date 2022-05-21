using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPulo : MonoBehaviour
{
    //
    public AudioClip audioPulo;
    //sera verificado na layer solo
    public LayerMask solo;
    //
    public Transform checadorDeSolo;
    //
    private bool estaNoSolo;
    //
    private bool estaPulando;
    //
    private bool ativarAnimacao;
    //
    public float forcaDePulo;
    //
    public float anguloDeContato;

    // Update is called once per frame
    void Update()
    {
        //
        Rigidbody2D sonic = GetComponent<Rigidbody2D>();
        //
        estaNoSolo = Physics2D.OverlapCircle(checadorDeSolo.position, anguloDeContato, solo);
        //
        if (estaNoSolo)
        {
            ativarAnimacao = true;
        }
        else
        {
            ativarAnimacao = false;
        }

        if (!ativarAnimacao)
        {
            GetComponent<Animator>().SetBool("Pulando", true);
            GetComponent<Animator>().SetBool("Andando", false);

        }
        else
        {
            GetComponent<Animator>().SetBool("Pulando", false);
        }

        //
        if (Input.GetButtonDown("Jump") && estaNoSolo)
        {
            GetComponent<AudioSource>().PlayOneShot(audioPulo);
            estaPulando = true;
        }
 
        //
        if (estaPulando)
        {
            sonic.AddForce(new Vector2(0, forcaDePulo));
            estaPulando = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(checadorDeSolo.transform.position, anguloDeContato);
    }
}
