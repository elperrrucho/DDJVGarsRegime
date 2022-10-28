using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementGars : MonoBehaviour
{
    private Vector3 mouvement;
    private Vector3 dernierMouvement;
    public float speed = 5.0f; //5 Unités par Seconde
    private Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        mouvement.z = 0.0f;
        dernierMouvement = new Vector3(0.0f, -1.0f, 0.0f);
        rig = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        mouvement.x = Input.GetAxisRaw("Horizontal");
        mouvement.y = Input.GetAxisRaw("Vertical");
        if (mouvement.magnitude > 0.001f)
        {
            dernierMouvement = mouvement;
        }
    }
    void FixedUpdate()
    {
        //Gérer le mouvement
        //transform.position = transform.position + mouvement.normalized * Time.fixedDeltaTime * speed;

        rig.velocity = mouvement.normalized * speed;
    }
    public Vector3 getDernierMouvement()
    {
        return dernierMouvement;
    }

    public int getDirection()
    {
        float petiteValeur = 0.001f;
        int direction = 0;
        if (dernierMouvement.x < -petiteValeur) // Fait face à gauche
        {
            direction = 2;
        }
        else if (dernierMouvement.y > petiteValeur) // Fait face en haut
        {
            direction = 1;
        }
        else if (dernierMouvement.y < -petiteValeur) // Fait face en bas
        {
            direction = 3;
        }
        return direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("win");
    }
}
