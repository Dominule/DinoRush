using UnityEngine;

// program zajišťuje možnost otevřít jednotlivé světy

// aktuálně jsou ve hře všechny světy přístupné
// možnost rozšíření: skrze tento skript je možné dočasné zamčení světů, dokud hráč nedosáhne určité úrovně

public class MapSelection : MonoBehaviour
{
    public bool isUnlock = false;       // boolean určuje, jestli je svět hráči přístupný
    public GameObject lockGo;       // obrázek zamčeného světa
    public GameObject unlockGo;     // obrázek odemčeného světa


    private void Update()
    {
        // odemčený svět
        if (isUnlock)
        {
            unlockGo.gameObject.SetActive(true);
            lockGo.gameObject.SetActive(false);
        }
        // zamčený svět
        else
        {
            unlockGo.gameObject.SetActive(false);
            lockGo.gameObject.SetActive(true);
        }
    }
}
