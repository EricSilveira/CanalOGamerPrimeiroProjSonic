using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    private float velocidade = 1.5f;

    private void FixedUpdate()
    {
        transform.Translate(velocidade * Time.deltaTime,0 ,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RetornaCrab1"))
        {
            velocidade = 0;
            StartCoroutine(Espera1());
        }


        if (collision.gameObject.CompareTag("RetornaCrab2"))
        {
            velocidade = 0;
            StartCoroutine(Espera2());
        }
    }

    IEnumerator Espera1()
    {
        StartCoroutine(EsperaAtaque());
        yield return new WaitForSecondsRealtime(3);
        velocidade = 1.5f;
    }

    IEnumerator Espera2()
    {
        StartCoroutine(EsperaAtaque());
        yield return new WaitForSecondsRealtime(3);
        velocidade = - 1.5f;
    }

    IEnumerator EsperaAtaque()
    {
        yield return new WaitForSecondsRealtime(1);
        GetComponent<Animator>().SetBool("AtaqueCrab", true);
        yield return new WaitForSecondsRealtime(1);
        GetComponent<Animator>().SetBool("AtaqueCrab", false);
    }

}
