
using UnityEngine;

public class GunFire : MonoBehaviour
{
    //Variables utilisé pour le Gun
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    //audio
    private AudioSource playerAudio;
    public AudioClip fireSound;


    void Start()
    {
        //on va chercher l'audio source
        playerAudio = GetComponent<AudioSource>();
    }
     void Update()
    {
     //Shooting
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //dommage sur la cible
        playerAudio.PlayOneShot(fireSound, 1f);
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamege(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            //Apres un centain nombre de tir la cible est detruite
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}



