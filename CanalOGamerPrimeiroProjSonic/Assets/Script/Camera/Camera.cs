/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Camera segue objeto                                              ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //1.0   - Para selecionar o objeto que ira seguir neste caso o player
    public GameObject OQueSeguir;
    //1.0   - Para variaveis de definicao
    public  float   delayX;
    public  float   delayY;
    public  bool    limites;
    public  Vector3 maximo;
    public  Vector3 minimo;
    private Vector2 velocidade;

    void FixedUpdate(){
        //1.0  - Pega a posicao que esta a camera, a posicao do objeto no caso do player, a velocidade da camerapara acompanhar e o delay de tempo até alcancar o objeto no eixo X   
        float posicaoX = Mathf.SmoothDamp(transform.position.x, OQueSeguir.transform.position.x, ref velocidade.x, delayX);
        //1.0  - Pega a posicao que esta a camera, a posicao do objeto no caso do player, a velocidade da camerapara acompanhar e o delay de tempo até alcancar o objeto no eixo Y
        float posicaoY = Mathf.SmoothDamp(transform.position.y, OQueSeguir.transform.position.y, ref velocidade.y, delayY);
        //1.0  - Faz seguir usando as informacoes acima edeixando o eixo z constante coomo esta
        transform.position = new Vector3(posicaoX, posicaoY, transform.position.z);

        if (limites){
            //1.0  - Coloca um limite que a camera pode seguir
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimo.x, maximo.x), Mathf.Clamp(transform.position.y, minimo.y, maximo.y),
                Mathf.Clamp(transform.position.z, minimo.z, maximo.z));

        }
    }
}
