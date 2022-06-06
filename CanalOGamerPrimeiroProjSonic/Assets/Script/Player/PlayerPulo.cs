/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Pulo                                                             ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPulo : MonoBehaviour
{
    //1.0   - Para o audio de pulo
    public AudioClip audioPulo;
    //1.0   - Para verificado na layer solo
    public LayerMask solo;
    //1.0   - Para checar se esta no chao
    public Transform checadorDeSolo;
    //1.0   - Para setar quando estiver no chao
    private bool  estaNoSolo;
    //1.0   - Para setar quando esta realizando o pulo
    private bool  estaPulando;
    //1.0   - Para configurar quando andando e quando pulando
    private bool  ativarAnimacao;
    //1.0   - Para a forca que realiza o pulo
    public  float forcaDePulo;
    //1.0   - Para dizer o tamanho do raio do circulo
    public  float  anguloDeContato;
    //1.0  - Para trabalhar no Rigidbody definido no player no caso mexer na fisica
    private Rigidbody2D sonic;

    void Start(){
        //1.0  - O GetComponent eh usado para pegar o objeto definido na unity
        sonic = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //Eh pego a posicao do checador de solo, o raio do circulo e se eh chao pela layer    
        estaNoSolo = Physics2D.OverlapCircle(checadorDeSolo.position, anguloDeContato, solo);

        //Ativa para realizar animacao quando esta o solo
        if (estaNoSolo){
            ativarAnimacao = true;
        } else{
            ativarAnimacao = false;
        }

        //Quando animacao estiver com falso realizara o animacao de pulo e desativara a de andando
        if (!ativarAnimacao){
            GetComponent<Animator>().SetBool("Pulando", true);
            GetComponent<Animator>().SetBool("Andando", false);
        } else{
            GetComponent<Animator>().SetBool("Pulando", false);
        }

        //1.0  - No momento em que apertar o botao de pulo(o getbuttondown ele só verifica se aperto e não se esta segurando o botão ou não)
        //1.0  - E verifica se esta no chao
        if (Input.GetButtonDown("Jump") && estaNoSolo){
            //Executa o audio de pulo e seta que esta pulando
            GetComponent<AudioSource>().PlayOneShot(audioPulo);
            estaPulando = true;
        }
 
        //Se pulando ele adiciona a forca do pulo
        if (estaPulando){
            sonic.AddForce(new Vector2(0, forcaDePulo));
            estaPulando = false;
        }
    }

    //Desenhar na cor magenta, uma esfera na posicao do ground com o tamanho do raio 
    private void OnDrawGizmos(){
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(checadorDeSolo.transform.position, anguloDeContato);
    }
}
