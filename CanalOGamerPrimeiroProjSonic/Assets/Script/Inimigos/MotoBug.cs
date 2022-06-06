/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Morte do inimigo                                                 ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoBug : MonoBehaviour
{
    //1.0  - Para velocidade da movimentacao
    public float     velocidade;
    //2.0   - Para o audio de quando destruido
    public AudioClip efeitoSonoroInfligeDano;

    void FixedUpdate(){
        //1.0  - Para que o inimigo ande
        transform.Translate(velocidade * Time.deltaTime, 0, 0);
    }

    void Girar(){
        //1.0  - Para que va para o lado oposto que esta indo
        velocidade *= -1;
        //1.0  - Quando for na direcao oposta ira assinalar ou desassinalar o sprite renderer na plataforma unity
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX; 
    }

    private void OnTriggerEnter2D(Collider2D collision){
        ////1.0  - Quando colidir com o objeto retorna ira voltar para o lado oposto entando na funcao girar
        if (collision.gameObject.CompareTag("Retorna")){
            Girar();
        }

        //2.0   - Quando colidir com o player ira desabilitar os colliders, tocara o efeito sonoro de morte, iniciara a animacao e chamara a courotina
        if (collision.gameObject.CompareTag("Player")){
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(efeitoSonoroInfligeDano);
            GetComponent<Animator>().SetBool("Fumaca", true);
            StartCoroutine(EsperaMorte());
        }
    }

    //2.0   - Ira esperar o tempo da animacao e destruira o objeto
    IEnumerator EsperaMorte(){
        yield return new WaitForSecondsRealtime(0.6f);
        Destroy(gameObject);
    }
}
