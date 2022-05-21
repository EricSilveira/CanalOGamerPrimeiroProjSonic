using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //
    public GameObject OQueSeguir;
    //
    public  float   delayX;
    public  float   delayY;
    public  bool    limites;
    public  Vector3 maximo;
    public  Vector3 minimo;
    private Vector2 velocidade;

    void FixedUpdate()
    {
        float posicaoX = Mathf.SmoothDamp(transform.position.x, OQueSeguir.transform.position.x, ref velocidade.x, delayX);
        float posicaoY = Mathf.SmoothDamp(transform.position.y, OQueSeguir.transform.position.y, ref velocidade.y, delayY);
        transform.position = new Vector3(posicaoX, posicaoY, transform.position.z);

        if (limites)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimo.x, maximo.x), Mathf.Clamp(transform.position.y, minimo.y, maximo.y),
                Mathf.Clamp(transform.position.z, minimo.z, maximo.z));

        }
    }
}
