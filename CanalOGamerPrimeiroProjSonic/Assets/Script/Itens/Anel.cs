/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Comportamento do anel ao ser coletado                            ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anel : MonoBehaviour
{
    //1.0   - Para audio de coleta de aneis
    public AudioClip efeitoSonoroAnel;

    private void OnTriggerStay2D(Collider2D collision) { 
        //1.0   - Quando colidir com player vai desativar o cicle clollider para não pegar mais de um
        if (collision.gameObject.CompareTag("Player")){
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(efeitoSonoroAnel);
            GetComponent<Animator>().SetBool("Coletando", true);
            StartCoroutine(Espera());
        }
    }
    
   //1.0   - Ira esperar o tempo da animacao e destruira o objeto
    IEnumerator Espera(){
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
