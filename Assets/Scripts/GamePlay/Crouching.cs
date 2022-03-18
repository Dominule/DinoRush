using UnityEngine;

// program se stará o sklánění postavičky dinosaura

public class Crouching : MonoBehaviour
{
    public GameObject Stand;        // objekt běžícího dinosaura
    public GameObject Crouch;       // objekt sklánějícího se dinosaura

    public Health health;           // přístup k životům

    void Update()
    {
        // při puštění šipky dolů na klávesnici
        if (Input.GetKeyUp("down"))
        {
            Crouch.SetActive(false);        // vypne objekt sklánějícího se dinosaura
            Stand.SetActive(true);          // zapne objekt narovnaného dinosaura
        }
    }


    // kolize
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // při srážce s překážkou
        if (collision.tag == "obstacle")
        {
            health.minusHP();       // odečtení životu
        }
    }
}
