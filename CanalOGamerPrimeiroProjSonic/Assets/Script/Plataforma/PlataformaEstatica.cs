using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEstatica : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
