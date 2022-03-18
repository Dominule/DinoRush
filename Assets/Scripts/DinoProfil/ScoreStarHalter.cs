using UnityEngine;
using UnityEngine.UI;
using TMPro;

// program se stará o vylepšení zvyšování score při hře


public class ScoreStarHalter : MonoBehaviour
{
    int steadyStar;     // aktuální množství zakoupených vylepšení

    int moneyAmount;    // množství amonitů
    int newStarPrice;   // cena po zakoupení vylepšení

    public TextMeshProUGUI priceOfStar;     // text - cena vylepšení
    public Button buyButton;        // tlačítko - nápis Purchase


    // obrázky jednotlivých hvězdiček
    // jsou buď barevně vyplněné nebo bez výplně
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject Star4;
    public GameObject Star5;

    public GameObject MinusStar1;
    public GameObject MinusStar2;
    public GameObject MinusStar3;
    public GameObject MinusStar4;
    public GameObject MinusStar5;

    // Start is called before the first frame update
    void Start()
    {
        steadyStar = PlayerPrefs.GetInt("ScoreStars", 1);       // načte z paměti počet hvězdiček
        moneyAmount = PlayerPrefs.GetInt("generalCoins", 0);        // načte množství amonitů
        newStarPrice = PlayerPrefs.GetInt("newStarPrice", 25);      // načte cenu za další vylepšení
        priceOfStar.text = newStarPrice.ToString();     // vypíše do textového pole cenu dalšího vylepšení


        // podmínkové řešení vykreslování objektů vylepšení
        if (steadyStar > 0)
        {
            Star1.SetActive(true);
            MinusStar1.SetActive(false);

            if (steadyStar > 1)
            {
                Star2.SetActive(true);
                MinusStar2.SetActive(false);

                if (steadyStar > 2)
                {
                    Star3.SetActive(true);
                    MinusStar3.SetActive(false);
                    Debug.Log("3");

                    if (steadyStar > 3)
                    {
                        Star4.SetActive(true);
                        MinusStar4.SetActive(false);

                        if (steadyStar > 4)
                        {
                            Star5.SetActive(true);
                            MinusStar5.SetActive(false);
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

        if (moneyAmount < newStarPrice)
        {
            buyButton.interactable = false;     // deaktivuje tlačítko
        }
    }



    public void PlusScoreStar()
    {
        // přičítá hvězdičky při koupi vylepšení

        if (moneyAmount >= newStarPrice && steadyStar < 5)
        {
            // odečtení amonitů
            moneyAmount -= newStarPrice;
            PlayerPrefs.SetInt("generalCoins", moneyAmount);

            // navýšení ceny vylepšení
            newStarPrice = newStarPrice * 2;
            if (newStarPrice == 400) { newStarPrice = 500; }      // poslední vylepšení stojí 500 amonitů
            priceOfStar.text = newStarPrice.ToString();
            PlayerPrefs.SetInt("newStarPrice", newStarPrice);

            // přičtení vylepšení
            steadyStar += 1;
            PlayerPrefs.SetInt("ScoreStars", steadyStar);

            Start();        // načte aktuální stav
        }

    }
}
