using UnityEngine;

// AUDIO???????

// program:
// koordinuje skákání dinosaura
// řeší kolize s překážkami a životy

public class RunJump : MonoBehaviour
{
    public GameObject Stand;        // objekt běžícího dinosaura
    public GameObject Crouch;       // objekt sklánějícího se dinosaura
    Animator m_Animator;            // animátor běhu, při skoku zastavuje animaci 

    public int ChangeOfY;       // změna pozice na ose Y

    bool IsJumping;             // boolean, jestli probíhá skok
    bool IsCrouching;           // boolean, jestli se dinoš sklání

    public Health health;       // přístup k programu Health

    Rigidbody2D rb;             // přístup k pozici objektu na plátně
    AudioSource DinoJumpSound;  // audio

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();               // načtení pozice objektu na plátně
        DinoJumpSound = GetComponent<AudioSource>();    // načtení audia
        
        IsJumping = false;          // dinosaurus neskáče
        IsCrouching = false;        // // dinosaurus se nesklání

        m_Animator = GetComponent<Animator>();      // načtení animátoru
    }

    // Update is called once per frame
    void Update()
    {
        // Skákání dinosaura
        // pokud se dinosaurus zrovna nesklání, neskáče, tak se stiskem mezerníku splní podmínka
        if (Input.GetKey("space") && IsJumping == false && IsCrouching == false)
        {
            rb.velocity = new Vector3(0, ChangeOfY, 0);     // skok - změna pozice na plátně
            IsJumping = true;           // dinoš skáče
            DinoJumpSound.Play();       //zahraje JumpSound :DDDD
        }


        // při skoku se vypne animace běhu
        if (IsJumping == true)
        {
            m_Animator.GetComponent<Animator>().enabled = false;
        }
        // pokud dinosarus neskáče, animace běhu je zapnutá
        else
        {
            m_Animator.GetComponent<Animator>().enabled = true;
        }

        


        // Sklánění dinosaura
        // při stisku šipky dolů se dinosarus skloní
        if (Input.GetKey("down") && IsJumping == false)
        {
            Crouch.SetActive(true);     // objekt sklánějícího se dinosaura se zapne
            Stand.SetActive(false);     // objekt narovnaného dinosaura se vypne
            IsCrouching = true;         // dinoš se sklání
        }
        // pokud se nesklání, tak se nesklání
        else
        {
            IsCrouching = false;
        }              
    }


    // při kolizi se logická proměnná skákání nastaví na false
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsJumping = false;
    }


    // kolize s překážkou nebo životem
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstacle" || collision.tag == "protiptak" || collision.tag == "health")
        {
            // srážka tyrannosaura nebo velociraptora (tag "devour") s pterodaktylem
            if (collision.tag == "protiptak" && this.tag == "devour")
            {
                Devouring.devour();         // volá funkci žraní pterodaktyla v programu Devouring
                Destroy(collision.gameObject);      // objekt pterodaktyla se vymaže
            }
            // srážka s jídlem
            else if (collision.tag == "health")
            {
                health.plusHP();            // volá funkci pro přičtení života v programu Health
                Destroy(collision.gameObject);      // objekt života se vymaže
            }
            // srážka s překážkou
            else
            {
                health.minusHP();           // volá funkci odečtení života v programu Health
                Destroy(collision.gameObject);      // překážka se vymaže
            }
        }
    }
}
