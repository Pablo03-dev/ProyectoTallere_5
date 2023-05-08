using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //Stats
    [Range(0, 1)]
    public float bounciness;
    public bool useGravity;

    //Damage
    public int explosionDamage;

    public float explosionRange;
    public float explosionForce;

    //LifeTime
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //When to explode:
        if (collisions > maxCollisions) Explode();

        //countdown lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();

    }

    private void Explode()
    {
        //Instancia expllosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //revisa si hay enemigos
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {



            if (enemies[i].GetComponent<Rigidbody>())
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
            }

        }

        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bala")) return;

        collisions++;

        if (collision.collider.CompareTag("Enemigo") && explodeOnTouch) Explode();

        //if (collision.collider.CompareTag("Player") && explodeOnTouch) Explode();

        //if (collision.collider.CompareTag("Piso") && explodeOnTouch) Explode();

    }

    private void Setup()
    {
        //Create a new Physics material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;

        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;
        //SetGravity
        rb.useGravity = useGravity;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

}
