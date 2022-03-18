using UnityEngine;
using UnityEngine.SceneManagement;          // pro překlikávání mezi scénami

// program je připnutý k hlavnímu menu
// zajišťuje přechody mezi scénami

public class MainMenu : MonoBehaviour
{    
    
    public void PlayGame()
    {
        // načte scénu GamePlay
        SceneManager.LoadScene("GamePlay");
    }
    
    public void DinoProfil()
    {
        // načte scénu profilu
        SceneManager.LoadScene("DinoProfil");
    }
    public void MapSelection()
    {
        // načte scénu mapy světů
        SceneManager.LoadScene("Map");
    }
    
    public void QuitGame()
    {
        // ukončí aplikaci
        Application.Quit();
    }
}
