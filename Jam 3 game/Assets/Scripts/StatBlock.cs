using UnityEngine;
using UnityEngine.AI;

public class StatBlock : MonoBehaviour
{
    [SerializeField] private int hitPoints = 10;
    [SerializeField] private float deathForceStrength = 2;
    private Animator animator;
    public bool isDead = false;
    private Rigidbody[] bodies;
    private NavMeshAgent agent;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        bodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            isDead = true;
           
            agent.enabled = false;
            animator.enabled = false;
            Vector3 force = transform.forward * (5f* deathForceStrength) + Vector3.up * (2f*deathForceStrength);
            
            foreach (Rigidbody body in bodies)
            {
                body.AddForce(force, ForceMode.Impulse);
            }
            FindObjectOfType<ScoreManager>().AddScore(1);
            Object.Destroy(gameObject, 5f);
        }
    }
        
}
