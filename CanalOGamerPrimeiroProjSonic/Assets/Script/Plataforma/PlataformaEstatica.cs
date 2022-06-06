/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Comportamento da plataforma em relacao ao player                 ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEstatica : MonoBehaviour
{
    //1.0   - Quando colidido com a tag player mudara ordem de apresentacao para tres
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }

    //1.0   - Quando sair da colisao voltar para ordem de apresentacao um
    private void OnCollisionExit2D(Collision2D collision){
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
