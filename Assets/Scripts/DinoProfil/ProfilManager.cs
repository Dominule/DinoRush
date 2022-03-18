using UnityEngine;
using UnityEngine.SceneManagement;      // pro překlikávání mezi scénami

// program zajišťuje přepínání na další scénu

public class ProfilManager : MonoBehaviour
{
    // fce načítá scénu menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
    // fce načítá scénu mapy světů
    public void LoadMap()
    {
        SceneManager.LoadScene("Map");
    }


    // fce načítá scénu obchodu
    public void LoadStore()
    {
        SceneManager.LoadScene("Store");
    }
    
}
