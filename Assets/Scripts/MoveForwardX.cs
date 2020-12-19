using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    // variable pour la vitesse
    public float speed;
    public float pst = 80;

    // Update is called once per frame
    void Update()
        // Deplacement des objets forward
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z < pst)
        {
            Destroy(gameObject);
        }
}
}
