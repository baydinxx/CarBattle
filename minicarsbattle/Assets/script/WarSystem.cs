using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WarSystem : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject BulletExýtPoint;
    public bool FireOn;
    float GunTýmer;
    public float GunSpeed;
    public ParticleSystem MuzzleFlash;
    AudioSource VoiceSource;
    public AudioClip FireSong;
    public float Range;
    public GameObject Bullet;
    public GameObject BulletEffectHit;


    RaycastHit hit;
    Ray ray;
    public float Player_2_healt;
    public GameObject Player_1_Healtbar;
    public GameObject Player_2_Healtbar;
    public float Player_1_Healt;
    public float NormalDamage;
    public float NovaDamage;
    public float RoketDamage;


    void Start()
    {
        VoiceSource = GetComponent<AudioSource>();
        Player_1_Healt = 100;
        Player_2_healt = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Player1Healt();
        Player2Healt();

        Shoot();


    }
    public void Player1Healt()
    {
        Player_1_Healtbar.transform.localScale = new Vector3(Player_1_Healt / 100, 1, 1);
        if (Player_1_Healt >= 100)
        {
            Player_1_Healt = 100;
        }
        if (Player_1_Healt <= 0)
        {
            Player_1_Healt = 0;
        }


    }
    public void Player2Healt()
    {
        Player_2_Healtbar.transform.localScale = new Vector3(Player_2_healt / 100, 1, 1);
        if (Player_2_healt >= 100)
        {
            Player_2_healt = 100;
        }
        if (Player_2_healt <= 0)
        {
            Player_2_healt = 0;
        }


    }

    public void FireCan()
    {
        FireOn = true;
        Instantiate(Bullet, BulletExýtPoint.transform.position, BulletExýtPoint.transform.rotation);
    }
    void Shoot()
    {
        if (FireOn==true&&Time.time>GunTýmer) 
        {
            DamageSystem();
            GunTýmer = Time.time+ GunSpeed;
            //Instantiate(BulletEffect, hit.point, Quaternion.LookRotation(hit.normal));

        }
    }


    public void DamageSystem()
    {
        Debug.Log("ateset calýsti");
        if (Physics.Raycast(BulletExýtPoint.transform.position, BulletExýtPoint.transform.forward, out hit, Range))
            {
            if(hit.collider.gameObject.tag=="Player")
            {
                Instantiate(BulletEffectHit, hit.point, Quaternion.LookRotation(hit.normal)); 
                Player_2_healt--;
            }
            
            

            Debug.Log("raycast calisti");
            MuzzleFlash.Play();
           
            
            //VoiceSource.Play();
            //VoiceSource.clip = FireSong;
            

            }

    }

    public void SkillDamage()
    {
        if (Physics.Raycast(BulletExýtPoint.transform.position, BulletExýtPoint.transform.forward, out hit, Range))
        {
            if (hit.collider.gameObject.tag == "Player")
            { Player_2_healt -=10; }

            MuzzleFlash.Play();
            //VoiceSource.Play();
            //VoiceSource.clip = FireSong;


        }

    }

    public void DontFire()
    {
        Debug.Log("ATES DURDU");
        FireOn = false;
    }

}
