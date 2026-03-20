using UnityEngine;

public class BaseHitScanGun : MonoBehaviour
{
    
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private float shotDelay = 0.5f;
    [SerializeField] private bool fullAuto = true;
    [SerializeField] private GameObject hitLocation;
    private bool canShoot = true;
    private float timer = 0;
    [SerializeField] private int damage = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > shotDelay)
            {
                canShoot = true;
                timer = 0;
            }
        }
        //actual shot
        if ((canShoot) && (fullAuto ? Input.GetButton("Fire1") : Input.GetButtonDown("Fire1")))
        {
            canShoot = false;
            Ray shotRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(shotRay, out hit)) 
            { 
                print("Hit Something" + hit.collider.gameObject.name);
                GameObject.Instantiate(hitLocation, hit.point, Quaternion.identity);

            }
                
        }
    }
}

