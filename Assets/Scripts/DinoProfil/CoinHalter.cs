using UnityEngine;
using TMPro;

// program se stará o přičítání nasbíraných amonitů

public class CoinHalter : MonoBehaviour
{
    public static int CoinChange;       // zaznamenává změnu počtu amonitů
    int CoinNumber;

    public TextMeshProUGUI textCoins;


    // Start is called before the first frame update
    void Start()
    {
        CoinNumber = CoinChange + PlayerPrefs.GetInt("generalCoins", 0);        // přičte změnu amonitů
        CoinChange = 0;         // vynuluje CoinChange
        textCoins.text = CoinNumber.ToString();         // vypíše aktuální číslo amonitů
        PlayerPrefs.SetInt("generalCoins", CoinNumber);         // uloží aktuální počet amonitů do proměnné "generalCoins"
    }

    // Update is called once per frame
    // zajišťuje, aby se hráč nedostal s amonity do minusu
    void Update()
    {
        if (CoinNumber < 0)
        {
            CoinNumber = 0;
            PlayerPrefs.SetInt("generalCoins", 0);
        }
    }

    // změna počtu nasbíraných amonitů - zěman textu
    // fce se volá z programu CoinPicker při srážce dinosaura s amonitem
    public void ChangeCoins()
    {
        CoinNumber = PlayerPrefs.GetInt("generalCoins", 0);
        textCoins.text = CoinNumber.ToString();     // změna textu na plátně
    }
}
