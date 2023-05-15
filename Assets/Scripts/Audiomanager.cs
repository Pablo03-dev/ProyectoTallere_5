using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static AudioClip disparoSound;
    public static AudioClip explosionSound;
    public static AudioClip usaGunSound;
    public static AudioClip UsaGranadaSound;
    public static AudioClip usaKnifeSound;
    public static AudioClip dañoSound;
    public static AudioClip cuchilloSound;
    public static AudioClip seguirSound;
    public static AudioClip atacarCorreSound;
    //public static AudioClip PowerupSound;

    static AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        disparoSound = Resources.Load<AudioClip>("Disparo");
        explosionSound = Resources.Load<AudioClip>("Explosion");
        usaGunSound = Resources.Load<AudioClip>("Usagun");
        UsaGranadaSound = Resources.Load<AudioClip>("UsaGranda");
        usaKnifeSound = Resources.Load<AudioClip>("usaKnife");
        dañoSound = Resources.Load<AudioClip>("Daño");
        cuchilloSound = Resources.Load<AudioClip>("cortocuchillo");
        seguirSound = Resources.Load<AudioClip>("Atacar");
        atacarCorreSound = Resources.Load<AudioClip>("Ataquen");
        //PowerupSound = Resources.Load<AudioClip>("ImpacObstac");

        audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Audiomanager.PlaySound("nombre/Explosion");
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Disparo": audioScr.PlayOneShot(disparoSound);
                break;

            case "Explosion":
                audioScr.PlayOneShot(explosionSound);
                break;

            case "Usagun":
                audioScr.PlayOneShot(usaGunSound);
                break;

            case "UsaGranda":
                audioScr.PlayOneShot(UsaGranadaSound);
                break;

            case "usaKnife":
                audioScr.PlayOneShot(usaKnifeSound);
                break;

            case "Daño":
                audioScr.PlayOneShot(dañoSound);
                break;

            case "cortocuchillo":
                audioScr.PlayOneShot(cuchilloSound);
                break;

            case "Atacar":
                audioScr.PlayOneShot(seguirSound);
                break;

            case "Ataquen":
                audioScr.PlayOneShot(atacarCorreSound);
                break;

        //    case "ImpacObstac":
        //        audioScr.PlayOneShot(PowerupSound);
        //        break;
        }
    }
}
