using UnityEngine;

// program vymaže dinosaura při vstupu do jeskyně


public class Exit : MonoBehaviour
{
    public GameObject Dinosaur;     // objekt dinosaura

    // kolize dinosaura s objektem jeskyně
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dinosaur.SetActive(false);      // deaktivace dinosaura
    }
}
