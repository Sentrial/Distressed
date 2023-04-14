using UnityEngine;

public class Dynamite : MonoBehaviour
{

    public float delay = 3f;

    public float blastRadius = 5f;

    public float explosionForce = 1000f;

    public GameObject explosionEffect;

    public GameObject backWall;

    float countdown;

    bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            Explode(); 
            hasExploded = true;
        }
    }

    void Explode()
    {

        Instantiate(explosionEffect, transform.position, transform.rotation);
        explosionEffect.transform.localScale = new Vector3(5f, 5f, 5f);

        Collider[] items = Physics.OverlapSphere(transform.position, blastRadius);

        foreach(Collider item in items)
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
        }

        Destroy(backWall);
        Destroy(gameObject);
    }
}
