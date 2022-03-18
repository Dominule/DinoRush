using UnityEngine;
using UnityEngine.UI;
using TMPro;

// program se stará o množství životů, se kterými hráč hru začíná

public class HPHalter : MonoBehaviour
{
    int steadyHealth;       // aktuální množství zakoupených vylepšení

    int moneyAmount;        // množství amonitů
    int newHealthPrice;     // cena po zakoupení vylepšení

    public TextMeshProUGUI priceOfHealth;       // text - cena vylepšení
    public Button buyButton;        // tlačítko - nápis Purchase

    // obrázky jednotlivých životů
    // jsou buď barevně vyplněné nebo bez výplně
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;
    public GameObject HP4;
    public GameObject HP5;

    public GameObject MinusHP1;
    public GameObject MinusHP2;
    public GameObject MinusHP3;
    public GameObject MinusHP4;
    public GameObject MinusHP5;

    // Start is called before the first frame update
    void Start()
    {
        steadyHealth = PlayerPrefs.GetInt("HealthPoints", 1);       // načte z paměti počet životů
        moneyAmount = PlayerPrefs.GetInt("generalCoins", 0);        // načte množství amonitů
        newHealthPrice = PlayerPrefs.GetInt("newHealthPrice", 25);  // načte cenu za další vylepšení
        priceOfHealth.text = newHealthPrice.ToString();     // vypíše do textového pole cenu dalšího vylepšení

        // podmínkové řešení vykreslování objektů vylepšení
        if (steadyHealth > 0)
        {
            HP1.SetActive(true);
            MinusHP1.SetActive(false);

            if (steadyHealth > 1)
            {
                HP2.SetActive(true);
                MinusHP2.SetActive(false);

                if (steadyHealth > 2)
                {
                    HP3.SetActive(true);
                    MinusHP3.SetActive(false);

                    if (steadyHealth > 3)
                    {
                        HP4.SetActive(true);
                        MinusHP4.SetActive(false);

                        if (steadyHealth > 4)
                        {
                            HP5.SetActive(true);
                            MinusHP5.SetActive(false);
                        }
                    }
                }
            }
        }
    }


    private void Update()
    {
        // kontroluje, jestli je množství amonitů větší než cena vylepšení
        // pokud ne, tlačítko nebude možné stisknout

        if (moneyAmount < newHealthPrice)
        {
            buyButton.interactable = false;     // deaktivuje tlačítko
        }
    }



    public void PlusHP()
    {
        // přičítá životy při koupi vylepšení
        
        if (moneyAmount >= newHealthPrice && steadyHealth < 5)
        {
            // odečtení amonitů
            moneyAmount -= newHealthPrice;
            PlayerPrefs.SetInt("generalCoins", moneyAmount);

            // navýšení ceny vylepšení
            newHealthPrice = newHealthPrice * 2;
            if (newHealthPrice == 400) { newHealthPrice = 500; }      // poslední vylepšení stojí 500 amonitů
            priceOfHealth.text = newHealthPrice.ToString();
            PlayerPrefs.SetInt("newHealthPrice", newHealthPrice);

            // přičtení vylepšení
            steadyHealth += 1;
            PlayerPrefs.SetInt("HealthPoints", steadyHealth);
            
            Start();        // načte aktuální stav
        }
        
    }    
}
