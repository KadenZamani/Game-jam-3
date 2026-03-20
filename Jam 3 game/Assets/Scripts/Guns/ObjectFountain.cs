using UnityEngine;
using Unity.VisualScripting;

public class ObjectFountain : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    private bool canShoot = true;
    [SerializeField] private float shotDelay = 0.5f;
    [SerializeField] private float shotPower = 50f;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer > shotDelay)
            {
                canShoot = true;
                timer = 0;
            }
        }
        if(canShoot && Input.GetKey(KeyCode.Space))
        {
            canShoot = false;
            Object shot = Object.Instantiate(ammo, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().AddForce(new Vector3(0, shotPower, 0), ForceMode.Impulse);
        }
    }
}
