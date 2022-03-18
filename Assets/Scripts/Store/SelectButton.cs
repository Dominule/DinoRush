using UnityEngine.EventSystems; // Event data
using UnityEngine;
using TMPro;

// program po stisknutí tlačítka mění text na "Selected"

public class SelectButton : MonoBehaviour, ISelectHandler// od ISelectHandler zděděná metoda OnSelect
{
    public TextMeshProUGUI buttonText;      // tlačítko, které má být stisknuté

    // stisknutí tlačítka
    public void OnSelect(BaseEventData eventData)
    {
        buttonText.text = "Selected";       // změna textu na "Selected"
    }
}
