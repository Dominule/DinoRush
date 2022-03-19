using UnityEngine;

// program vykresluje, odčítá a přičítá životy

public class Health : MonoBehaviour
{
    public int health;              // aktuální počet životů

    // objekty vybarvených životů
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;

    // objekty obrysů srdíček
    public GameObject MinusHP1;
    public GameObject MinusHP2;
    public GameObject MinusHP3;
    public GameObject MinusHP4;
    public GameObject MinusHP5;


    public GameManager gameManager;     // třída GameManager
    
    
    void Start()
    {
        health = PlayerPrefs.GetInt("HealthPoints", 1);     // načte počet životů, se kterými se začíná

        // podmínkové řešení vykreslení životů
        if (health > 0)
        {
            HP1.SetActive(true);
            MinusHP1.SetActive(false);

            if (health > 1)
            {
                HP2.SetActive(true);
                MinusHP2.SetActive(false);

                if (health > 2)
                {
                    HP3.SetActive(true);
                    MinusHP3.SetActive(false);
                    if (health > 3)
                    {
                        HP4.SetActive(true);
                        MinusHP4.SetActive(false);

                        if (health > 4)
                        {
                            HP5.SetActive(true);
                            MinusHP5.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    // fce kontroluje, jestli dinosaurus stále může pokračovat ve hře
    void Update()
    {
        // 0 životů
        if (health < 1)
            gameManager.GameOver();     // konec hry přes GameManager
    }


    // fce přičítá život
    public void plusHP()
    {
        // životů hráč nemůže mít více než 5
        if (health < 5)
        {
            health += 1;
            RebuildHP();        // fce překreslí obrázky srdíček na plátně
        }
    }


    // fce odečítá život
    public void minusHP()
    {
        health -= 1;
        RebuildHP();        // fce překreslí obrázky srdíček na plátně
    }


    // překreslování životů na plátně
    void RebuildHP()
    {
        // podmínkové řešení vykreslování životů
        switch (health)
        {
            case 0:
                HP1.SetActive(false);
                MinusHP1.SetActive(true);
                break;
            case 1:
                HP2.SetActive(false);
                MinusHP2.SetActive(true);
                break;
            case 2:
                HP3.SetActive(false);
                MinusHP3.SetActive(true);
                HP2.SetActive(true);
                MinusHP2.SetActive(false);
                break;
            case 3:
                HP4.SetActive(false);
                MinusHP4.SetActive(true);
                HP3.SetActive(true);
                MinusHP3.SetActive(false);
                break;
            case 4:
                HP5.SetActive(false);
                MinusHP5.SetActive(true);
                HP4.SetActive(true);
                MinusHP4.SetActive(false);
                break;
            case 5:
                HP5.SetActive(true);
                MinusHP5.SetActive(false);
                break;
        }
    }
}
