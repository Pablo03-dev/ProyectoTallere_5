using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    //public static AudioClip FlippersSound;
    //public static AudioClip PartidaSound;
    //public static AudioClip ImpactObstacSound;
    //public static AudioClip HuidaSound;
    //public static AudioClip ExplosionSound;
    //public static AudioClip MuroSound;
    //public static AudioClip PandaSound;
    //public static AudioClip BotonesSound;
    //public static AudioClip PandaCorreSound;
    //public static AudioClip PowerupSound;

    static AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        //FlippersSound = Resources.Load<AudioClip>("Flippers");
        //PartidaSound = Resources.Load<AudioClip>("BolaInicia");
        //ImpactObstacSound = Resources.Load<AudioClip>("ImpactoObsta");
        //HuidaSound = Resources.Load<AudioClip>("HuidaPanda");
        //ExplosionSound = Resources.Load<AudioClip>("Explosion");
        //MuroSound = Resources.Load<AudioClip>("ImpacMuro");
        //PandaSound = Resources.Load<AudioClip>("Panda");
        //BotonesSound = Resources.Load<AudioClip>("Botones");
        //PandaCorreSound = Resources.Load<AudioClip>("Panda_pasto");
        //PowerupSound = Resources.Load<AudioClip>("ImpacObstac");

        //audioScr = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        //switch (clip)
        //{
        //    case "Flippers": audioScr.PlayOneShot(FlippersSound);
        //        break;

        //    case "BolaInicia":
        //        audioScr.PlayOneShot(PartidaSound);
        //        break;

        //    case "ImpactoObsta":
        //        audioScr.PlayOneShot(ImpactObstacSound);
        //        break;

        //    case "HuidaPanda":
        //        audioScr.PlayOneShot(HuidaSound);
        //        break;

        //    case "Explosion":
        //        audioScr.PlayOneShot(ExplosionSound);
        //        break;

        //    case "ImpacMuro":
        //        audioScr.PlayOneShot(MuroSound);
        //        break;

        //    case "Panda":
        //        audioScr.PlayOneShot(PandaSound);
        //        break;

        //    case "Botones":
        //        audioScr.PlayOneShot(BotonesSound);
        //        break;

        //    case "Panda_pasto":
        //        audioScr.PlayOneShot(PandaCorreSound);
        //        break;

        //    case "ImpacObstac":
        //        audioScr.PlayOneShot(PowerupSound);
        //        break;
        //}
    }
}
