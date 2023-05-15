using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class ShootSystem : MonoBehaviour
{
    //public Balaplayer bullet;

    public GameObject bullet;
    public float shootForce, upwardForce;

    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    //Recoil
    public Rigidbody playerrb;
    public float recoilForece;

    //Graphics
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammoDisplay;

    //private ObjectPool<Balaplayer> bulletPool;

    private void Start()
    {
        //bulletPool = new ObjectPool<Balaplayer>(() =>
        //{
        //    Balaplayer bala = Instantiate(bullet, attackPoint.position, attackPoint.rotation);
        //    bala.DesactivarBala(DesactivarBalaPool);
        //    return bala;
        //}, bala =>
        //{
        //    bala.transform.position = attackPoint.position;
        //    bala.gameObject.SetActive(true);
        //}, bala =>
        //{
        //    bala.gameObject.SetActive(false);
        //}, bala =>
        //{
        //    Destroy(bala.gameObject);
        //}, true, 5, 10);
    }

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        if (ammoDisplay != null)
            ammoDisplay.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Reload auto when trying to shot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();



        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Audiomanager.PlaySound("Disparo");
            Shoot();
        }
    }

    private void Shoot()
    {
        //bulletPool.Get();

        readyToShoot = false;

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        

        currentBullet.transform.forward = directionWithSpread.normalized;

        
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);

        //Granadas
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        

        //Instacia flash si es que tiene
        if (muzzleFlash)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;

            //Add recoil to the player
            playerrb.AddForce(-directionWithSpread.normalized * recoilForece, ForceMode.Impulse);
        }

        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    //private void DesactivarBalaPool(Balaplayer bala)
    //{
    //    bulletPool.Release(bala);
    //}

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
