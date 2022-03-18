using UnityEngine;
using UnityEngine.UI;
using TMPro;

// program se stará o vylepšení "velkého amonitu" a ukládá jeho aktuální hodnotu

public class AmonitHalter : MonoBehaviour
{
    int steadyBigAmonitValue;       // aktuální množství zakoupených vylepšení

    int bigAmonitValue;     // aktuální hodnota "velkého amonitu"

    int moneyAmount;        // množství amonitů
    int newBigamonPrice;    // cena po zakoupení vylepšení

    public TextMeshProUGUI priceOfAmonit;       // text - cena vylepšení
    public Button buyButton;        // tlačítko - nápis Purchase


    // obrázky jednotlivých amonitů
    // jsou buď barevně vyplněné nebo bez výplně
    public GameObject Amon1;
    public GameObject Amon2;
    public GameObject Amon3;
    public GameObject Amon4;
    public GameObject Amon5;

    public GameObject MinusAmon1;
    public GameObject MinusAmon2;
    public GameObject MinusAmon3;
    public GameObject MinusAmon4;
    public GameObject MinusAmon5;

    // Start is called before the first frame update
    void Start()
    {
        steadyBigAmonitValue = PlayerPrefs.GetInt("AmonitBooster", 1);      // načte z paměti počet zakoupených vylepšení
        bigAmonitValue = PlayerPrefs.GetInt("BigAmonitValue", 5);       // načte aktuální hodnotu "velkého amonitu"
        moneyAmount = PlayerPrefs.GetInt("generalCoins", 0);        // načte množství amonitů
        newBigamonPrice = PlayerPrefs.GetInt("newBigamonPrice", 25);        // načte cenu za další vylepšení
        priceOfAmonit.text = newBigamonPrice.ToString();        // vypíše do textového pole cenu dalšího vylepšení


        // podmínkové řešení vykreslování objektů vylepšení
        if (steadyBigAmonitValue > 0)
        {
            Amon1.SetActive(true);
            MinusAmon1.SetActive(false);

            if (steadyBigAmonitValue > 1)
            {
                Amon2.SetActive(true);
                MinusAmon2.SetActive(false);

                if (steadyBigAmonitValue > 2)
                {
                    Amon3.SetActive(true);
                    MinusAmon3.SetActive(false);

                    if (steadyBigAmonitValue > 3)
                    {
                        Amon4.SetActive(true);
                        MinusAmon4.SetActive(false);

                        if (steadyBigAmonitValue > 4)
                        {
                            Amon5.SetActive(true);
                            MinusAmon5.SetActive(false);
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

        if (moneyAmount < newBigamonPrice)
        {
            buyButton.interactable = false;     // deaktivuje tlačítko
        }
    }

    public void PlusAmonit()
    {
        // zvyšuje počet zakoupených vylepšení o 1

        if (moneyAmount >= newBigamonPrice && steadyBigAmonitValue < 5)
        {
            // odečtení amonitů
            moneyAmount -= newBigamonPrice;
            PlayerPrefs.SetInt("generalCoins", moneyAmount);

            // navýšení ceny vylepšení
            newBigamonPrice = newBigamonPrice * 2;
            if (newBigamonPrice == 400) { newBigamonPrice = 500; }      // poslední vylepšení stojí 500 amonitů
            priceOfAmonit.text = newBigamonPrice.ToString();
            PlayerPrefs.SetInt("newBigamonPrice", newBigamonPrice);

            // zvýšení hodnoty "velkého amonitu"
            bigAmonitValue += 5;
            PlayerPrefs.SetInt("BigAmonitValue", bigAmonitValue);

            // přičtení vylepšení
            steadyBigAmonitValue += 1;
            PlayerPrefs.SetInt("AmonitBooster", steadyBigAmonitValue);

            Start();        // načte aktuální stav
        }

    }

}
