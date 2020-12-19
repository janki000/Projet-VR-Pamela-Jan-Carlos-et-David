using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // Variales utilisé pour le PlayerController
    public float speed;
    public float verticalInput;
    public float horizontalInput;
    public float gravity = -9.81f;
    public float jumpHeight;

    //Limite
    private float xLimit = 47f;
    private float zLimit = 40;
    private float zLimitBegin = -86;

    //PowerUp
    public GameObject powerupIndicator;
    public bool hasPowerup;
    private float powerUpStrength = 15.0f;

    //Ground
    private AudioSource playerAudio;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

   //velocity
    Vector3 velocity;

    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        //On va chercher la position du player et l'audio source
        target = transform.position;
        playerAudio = GetComponent<AudioSource>();
    }

  
    IEnumerator PowerupCountdownRoutine()
    {
        //Si 7 seconde s'écoule le powerUp tombe a faux donc se désactive
        yield return new WaitForSeconds(7);//PAUSES DE 7 SECONDE
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //PowerUp
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Player collides with" + collision.gameObject + "with power set to" + hasPowerup);
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // si la position x depasse la limite du background, on le fait ''arrêter'' en le remettant exactement à la place ou le background commence. Pareil pour l'extrémité en z
        if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        else if (transform.position.z < zLimitBegin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimitBegin);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Mouvement Horizontal avec les touches Gauche et Droite
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        powerupIndicator.transform.position = transform.position;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);

            //Demarre une décompte et crée un fonction personnalisé
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
}
