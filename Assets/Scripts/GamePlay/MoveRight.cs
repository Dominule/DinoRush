using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// program zajišťující let meteoroidů (případně pád velkého meteoritu) a pád meteoritu

public class MoveRight : MonoBehaviour
{
    public float speed;     // rychlost meteoroidu

    public float startY;    // startovní pozice na ose Y
    public float endY;      // konečná pozice na ose Y
    public float startX;    // startovní pozice na ose X

    public GameObject Explosion;        // objekt znázorňující explozi


    // Update is called once per frame
#pragma warning disable IDE0051 // Remove unused private members
    void Update()
#pragma warning restore IDE0051 // Remove unused private members
    {
        // změna pozice na plátně
        transform.position = new Vector2(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y - speed * Time.fixedDeltaTime);
                // nutné použít Time.fixedDeltaTime, samotný deltaTime by byl na konci hry nulový a pozice by se tak nemohla změnit


        // meteoroid dorazí do endY >>> přesune se zase na začátek
        if (transform.position.y <= endY)
        {
            transform.position = new Vector2(startX, startY);
        }

        // pád asteroidu*
        if (transform.position.y <= - 4.2 && this.tag == "EndGame")      // -4.2 je pozice země na ose Y
        {
            Explosion.SetActive(true);      // aktivace animace exploze
        }
    }
}

//*
// Chicxulubský kráter se nachází na dnešním poloostrově Yucatan,
// vznikl pravděpodobně pádem asteroidu a zapříčinil tak vymírání druhů na konci křídy.
// https://en.wikipedia.org/wiki/Chicxulub_crater
