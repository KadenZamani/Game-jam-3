using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float lifeSpan = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Object.Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        StatBlock block = collision.gameObject.GetComponent<StatBlock>();
        if(block != null)
        {
            block.takeDamage(damage);
            Object.Destroy(gameObject);
        }
    }
    


}
