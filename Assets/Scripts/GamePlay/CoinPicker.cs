using UnityEngine;
using TMPro;

// program:
// je připnutý k postavičce dinosaura
// sbírání amonitů - přičítání k už nasbíraným amonitům*

public class CoinPicker : MonoBehaviour
{
    
    private float coin = 0;             // kolik amonitů dinoš nasbírá

    int megaCoinValue;           // hodnota "velkého amonitu"

    public TextMeshProUGUI textCoins;       // text - počet amonitů ve formě stringu

    private void Start()
    {
        megaCoinValue = PlayerPrefs.GetInt("BigAmonitValue", 5);    // načtení hodnoty "velkého amonitu" z paměti, výchozí je 5
    }


    // kolize dinosaura s amonitem
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // srážka s amonitem označeným tagem "coin"
        if (collision.transform.tag == "coin")
        {
            Destroy(collision.gameObject);      // vymaže amonit z plátna
            coin ++;        // zvýší počet amonitů o 1
            textCoins.text = coin.ToString();       // vypíše aktuální počet amonitů

            CoinHalter.CoinChange ++;     // v programu CoinHalter se změna amonitů navýší o 1

        }


        // srážka s "velkým amonitem"
        if (collision.transform.tag == "megaCoin")
        {
            Destroy(collision.gameObject);      // vymaže "velký amonit"
            coin = coin + megaCoinValue;        // zvýší počet získaných amonitů o hodnotu "velkého amonitu"
            textCoins.text = coin.ToString();       // vypíše aktuální počet amonitů

            CoinHalter.CoinChange += megaCoinValue;     // v programu CoinHalter navýší změnu amonitů
        }
    }
}


//*
// Amoniti
// společně s belemnity patřili v průběhu druhohor k poměrně rozšířeným hlavonožcům.
// Největší nálezy máme z období jury, přičemž největší dosahují až 1.8 metrů.
// Živili se potravou z drobných organismů u mořského dna.
// Mezi další obyvatele moří v té době patřili mimo jiné také mlži, plži, krabi a lilijice.

//   http://www.czechfossilsandminerals.com/fossils/fossilsworld/ammonites
