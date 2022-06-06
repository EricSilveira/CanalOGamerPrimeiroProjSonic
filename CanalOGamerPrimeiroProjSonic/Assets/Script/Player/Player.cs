/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Movimentacao                                                     ***/
/*****                                                                        ***/
/*** 2.0   - Coleta aneis                                                     ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Para velocidade de movimentacao
    public float velocidade;
    //Para coleta de aneis
    public int aneis;
    //Para bloqueio de movimentacao
    public static bool interruptor;
    //1.0  - Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D sonic;

    void Start(){
        //1.0  - O GetComponent eh usado para pegar o objeto definido na unity
        sonic = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //1.0   - Quando tomar dano estara como verdadeiro fara isso ficara falso eh setado na classe Dano
        if (interruptor == false) {
            //1.0   - O Horizontal é definido na unity no caso esta colocando as teclas pressionada definidas na unity esta jogando para esta variavel
            float horizontal = Input.GetAxis("Horizontal");
            //1.0   - Atualizando a movimentacao com o botao de entrada vezes a velocidade setada e mantendo o eixo y como estiver
            sonic.velocity = new Vector2(horizontal * velocidade,sonic.velocity.y);

            //1.0   - Fazendo a movimentacao de quando indo para a direita e para a esquerda com o flip do sprite renderer, e ativando a animacao e quando parar desativa
            if (horizontal > 0){
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Animator>().SetBool("Andando", true);
            } else if(horizontal < 0){
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Animator>().SetBool("Andando", true);
            } else{
                GetComponent<Animator>().SetBool("Andando", false);
            }
        }
    }

    //2.0   - Para coleta de aneis
    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Anel")){
            aneis++;
        }
    }
}
