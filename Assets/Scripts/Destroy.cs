using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //variable utilisé
    public float pst = -80;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //detruire GameObjets
        if (transform.position.x < pst)
        {
            Destroy(gameObject);
        }
    }
}
