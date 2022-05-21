using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //
    public GameObject audioLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(audioLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
