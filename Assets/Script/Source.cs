using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    public GameObject tartePacane;
    public float limit = 6.5f;
    private float accumulerTemps = 0.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        accumulerTemps += Time.fixedDeltaTime;
        float timer = 1.0f;

        if (accumulerTemps > timer)
        {
            float hauteur = Random.Range(-limit, limit);
            Vector3 delta = new Vector3(0.0f, hauteur, 0.0f);
            Instantiate(tartePacane, transform.position + delta, Quaternion.identity);
            tartePacane.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), 90.0f);
            accumulerTemps = 0.0f;
            float ratio = (Time.time + 5.0f) / 5.0f;

            timer = Random.Range(0.3f, 1.0f);
            //L'essieux de la rotation est un vecteur qui sort de l'ecran
        }
    }
}
