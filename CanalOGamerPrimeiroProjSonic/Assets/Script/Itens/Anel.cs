using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anel : MonoBehaviour
{
    //
    public AudioClip efeitoSonoroAnel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //quando colidir com player vai desativar o cicle clollider para não pegar mais de um
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(efeitoSonoroAnel);
            GetComponent<Animator>().SetBool("Coletando", true);
            StartCoroutine(Espera());
        }
    }
    
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

}
