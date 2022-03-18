using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// program zajišťuje pohyb doleva (pohyb překážek a pozadí)

public class MoveLeft : MonoBehaviour
{
    public float speed;     // rychlost, definováno v unity (public), u překážek 8

    public float start;     // počáteční pozice na ose X
    public float end;       // koncová pozice na ose X (nižší než proměnná start)
    

    void Update()
    {
        // změna pozice objektu na základě vlastní rychlosti (speed) a rychlosti průběhu hry (deltaTime)
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        
        // objekt překročí proměnnou end
        if (transform.position.x <= end)
        {
            // objekty s určitými tagy jsou ničeny
            if (gameObject.tag == "obstacle" || gameObject.tag == "coin" || gameObject.tag == "protiptak" || gameObject.tag == "health" || gameObject.tag == "megaCoin" || gameObject.tag == "EndLevel")
            {
                Destroy(gameObject);
            }
            // pokud nejsou označeny příslušným tagem, vytvoří se nově na pozici start
            else
            {
                transform.position = new Vector2(start, transform.position.y);
            }
        }
    }
}
