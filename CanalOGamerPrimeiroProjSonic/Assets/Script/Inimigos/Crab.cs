/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Animacao de ataque                                               ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    //1.0  - Para velocidade da movimentacao
    private float velocidade = 1.5f;

    private void FixedUpdate(){
        //1.0  - Para que o inimigo ande
        transform.Translate(velocidade * Time.deltaTime,0 ,0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        //1.0  - Quando colidir com o objeto setado na unity ira para e ir no metodo mencionado
        if (collision.gameObject.CompareTag("RetornaCrab1")){
            velocidade = 0;
            StartCoroutine(Espera1());
        }

        //1.0  - Quando colidir com o objeto setado na unity ira para e ir no metodo mencionado 
        if (collision.gameObject.CompareTag("RetornaCrab2")){
            velocidade = 0;
            StartCoroutine(Espera2());
        }
    }

    IEnumerator Espera1(){
        //2.0  - Chamara de corotina para executar uma açao por determinado tempo   
        StartCoroutine(EsperaAtaque());
        //1.0  - Aguarda 3 segundo                                                  
        yield return new WaitForSecondsRealtime(3);
        //1.0  - Coloca a velocidade positiva para ir para a direita                       
        velocidade = 1.5f;
    }

    IEnumerator Espera2(){
        //1.0  - Chamara de corotina para executar uma açao por determinado tempo   
        StartCoroutine(EsperaAtaque());
        //1.0  - Aguarda 3 segundo   
        yield return new WaitForSecondsRealtime(3);
        //1.0  - Coloca a velocidade negativa para ir para a esquerda  
        velocidade = - 1.5f;
    }

    //2.0  - Faz a animação de ataque
    IEnumerator EsperaAtaque(){
        yield return new WaitForSecondsRealtime(1);
        GetComponent<Animator>().SetBool("AtaqueCrab", true);
        yield return new WaitForSecondsRealtime(1);
        GetComponent<Animator>().SetBool("AtaqueCrab", false);
    }
}
