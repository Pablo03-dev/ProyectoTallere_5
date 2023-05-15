using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform enemy;
    public int healt;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject proyectile;
    public Transform AtackPoint;

    //States
    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemigo").transform; //Cambiar a Tag
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Revisa para alcance y ataque
        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!enemyInSightRange && !enemyInAttackRange) Patroling();
        if (enemyInSightRange && !enemyInAttackRange) ChasePlayer();
        if (enemyInAttackRange && enemyInSightRange) AttackPlayer();


    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(enemy.position);
    }

    private void AttackPlayer()
    {
        //asegurarse que el aliado no se mueva
        agent.SetDestination(transform.position);
        //Vector3 aux = new Vector3(enemy.rotation.x, transform.rotation.y, enemy.rotation.z);
        //Vector3 aux = new Vector3(transform.rotation.y, enemy.rotation.x, enemy.rotation.z); 
        transform.LookAt(enemy);

        if (!alreadyAttacked)
        {
            //Attack code aqui
            Audiomanager.PlaySound("Disparo");
            Rigidbody rb = Instantiate(proyectile, AtackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        healt -= damage;

        if (healt <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
