using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;
    public GameObject[] trailParticles;
    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.

    private bool hasCollided = false;

    void Start()
    {
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
        projectileParticle.transform.parent = transform;
        if (muzzleParticle)
        {
            muzzleParticle = Instantiate(muzzleParticle, transform.position, transform.rotation) as GameObject;
            muzzleParticle.transform.rotation = transform.rotation * Quaternion.Euler(180, 0, 0);
            Destroy(muzzleParticle, 1.5f); // Lifetime of muzzle effect.
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (!hit.gameObject.CompareTag("Left") && !hit.gameObject.CompareTag("Right"))
        {
            if (!hasCollided)
            {
                hasCollided = true;
                //transform.DetachChildren();
                impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
                //Debug.DrawRay(hit.contacts[0].point, hit.contacts[0].normal * 1, Color.yellow);

                if (hit.gameObject.tag == "Destructible") // Projectile will destroy objects tagged as Destructible
                {
                    Destroy(hit.gameObject);
                }
                
                if (hit.gameObject.tag == "MainCamera") // Projectile will destroy objects tagged as Destructible
                {
                    FindObjectOfType<GameManager>().RemovePoints();
                }

                //yield WaitForSeconds (0.05);
                foreach (GameObject trail in trailParticles)
                {
                    GameObject curTrail = transform.Find(projectileParticle.name + "/" + trail.name).gameObject;
                    curTrail.transform.parent = null;
                    Destroy(curTrail, 3f);
                }
                Destroy(projectileParticle, 3f);
                Destroy(impactParticle, 5f);
                Destroy(gameObject);
                //projectileParticle.Stop();
            }
        }
        else
        {
            string layerName = LayerMask.LayerToName(gameObject.layer);
            gameObject.layer = LayerMask.NameToLayer(layerName.Remove(layerName.Length-1));
            FindObjectOfType<GameManager>().AddPoint(1);
        }


    }
}