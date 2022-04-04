using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;

    [SerializeField] private float fireRate;
    float nextTimeToFire;

    void Update()
    {   
        if(Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shot();
        }
    }

    void Shot()
    {
        GameObject bulletIns = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        //bulletIns.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 100);
    }
}
