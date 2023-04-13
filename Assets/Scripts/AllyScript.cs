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
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;

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
        enemy = GameObject.Find("Enemy").transform;
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

        //if (!playerInSightRange && !PlayerInAttackRange) Patroling();
        if (enemyInSightRange && !enemyInAttackRange) ChasePlayer();
        if (enemyInAttackRange && enemyInSightRange) AttackPlayer();


    }

    //private void Patroling()
    //{
    //    if (!walkPointSet) SearchWalkPoint();

    //    if (walkPointSet)
    //        agent.SetDestination(walkPoint);

    //    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //    //walkpoint reached
    //    if (distanceToWalkPoint.magnitude < 1f)
    //        walkPointSet = false;

    //}

    //private void SearchWalkPoint()
    //{
    //    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float randomX = Random.Range(-walkPointRange, walkPointRange);

    //    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //        walkPointSet = true;

    //}

    private void ChasePlayer()
    {
        agent.SetDestination(enemy.position);
    }

    private void AttackPlayer()
    {
        //asegurarse que el aliado no se mueva
        agent.SetDestination(transform.position);
        transform.LookAt(enemy);

        if (!alreadyAttacked)
        {
            //Attack code aqui
            Rigidbody rb = Instantiate(proyectile, AtackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

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
