using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombies : MonoBehaviour
{
    //Variables pour le son
    public AudioClip deathSound;
    private AudioSource playerAudio;

    //Variables pour le mouvement 
    public float speed = 10;
    private Rigidbody enemyRb;
    private GameObject player;
    public float gravityModifier = 3;

    // Start is called before the first frame update
    void Start()
    {
        //On va chercher le rigidbody du player
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        //On va chercher la source audio
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouvement de l'ennemi
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        
    }

    //Si l'ennemi entre en collision avec un projectile, il y a un effet , de son et ça invoke la fonction pour le Destroy.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Invoke("DestroyEnemy", 0.25f);
            playerAudio.PlayOneShot(deathSound, 1f);
        }
    }

    //Détruit l'ennemi
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
