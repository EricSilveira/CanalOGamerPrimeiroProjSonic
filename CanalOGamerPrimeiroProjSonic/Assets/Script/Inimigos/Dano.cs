/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Dano recebido                                                    ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    //1.0   - Para o audio de quando tomar dano
    public AudioClip efeitoDano;
    //1.0   - Para os aneis que o personagem tem
    public int aneis;
    //1.0   - Para a quantidade de vidas do personagem
    public int vidas;
    //1.0   - Para quando atingido pela esquerda ser impulsionado para esquerda
    public float impulsoEsquerdoX;
    //1.0   - Para quando atingido pela esquerda ser impulsionado para cima
    public float impulsoEsquerdoY;
    //1.0   - Para quando atingido pela esquerda ser impulsionado para direita
    public float impulsoDireitoX;
    //1.0   - Para quando atingido pela esquerda ser impulsionado para cima
    public float impulsoDireitoY;

    private void OnCollisionEnter2D(Collision2D collision){
        //1.0   - Quando colidir com impulso esquerdo ira desativar a movimentacao do personagem e ver se tem aneis e zerar se não tier perdera vida
        if (collision.gameObject.CompareTag("ImpulsoEsquerdo")){
            Player.interruptor = true;
            if (aneis > 0){
                aneis = 0;
            } else{
                vidas--;
            }
            GetComponent<AudioSource>().PlayOneShot(efeitoDano);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsoEsquerdoX, impulsoEsquerdoY));
            StartCoroutine(Espera());
        }

        //1.0   - Quando colidir com impulso direito ira desativar a movimentacao do personagem e ver se tem aneis e zerar se não tier perdera vida 
        if (collision.gameObject.CompareTag("ImpulsoDireito")){
            Player.interruptor = true;
            if (aneis > 0){
                aneis = 0;
            } else{ 
                vidas--;
            }
            GetComponent<AudioSource>().PlayOneShot(efeitoDano);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsoDireitoX, impulsoDireitoY));
            StartCoroutine(Espera());
        }
    }

    //1.0   - Esta corroutina serve para colocar um tempo de espera de um segundo e ativar novamente a movimentacao do personagem
    IEnumerator Espera(){
        yield return new WaitForSecondsRealtime(1);
        Player.interruptor = false;
    }
}
