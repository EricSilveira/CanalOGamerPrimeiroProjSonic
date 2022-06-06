/***================== Indice do codigo para entendimento ====================***/
/*** 1.0   - Musica de fundo                                                  ***/
/*****                                                                        ***/
/**================== Fim Indice do codigo para entendimento =================***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //1.0   - Para setar a musica
    public GameObject audioLevel;

    //1.0   - Para ativar a musica
    void Start(){
        gameObject.SetActive(audioLevel);
    }
}
