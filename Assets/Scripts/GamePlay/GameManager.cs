using UnityEngine;
using UnityEngine.SceneManagement;          // přechody mezi scénami

// program:
// zapíná GameWin a GameOver panely obsahující tlačítka a text
// stisknutím takových tlačítek přepíná na vybranou scénu

public class GameManager : MonoBehaviour
{
    public GameObject GOPanel;      // "GameOverPanel" - aktivace se na při prohrání levelu
    public GameObject GWPanel;      // "GameWinPanel" - aktivace při úspěšném dokončení levelu

    public GameObject LoseSound;          // EndGame audio

    void Start()
    {
        // definování času
        Time.timeScale = 1;     // při 1 hra ubíhá stejně jako v realitě, při 0.5 by hra běžela dvakrát pomaleji
    }


    // konec hry
    public void GameOver()
    {
        Time.timeScale = 0;     // zastavení hry (deltaTime bude 0)

        GOPanel.SetActive(true);        // zapne "GameOverPanel" + Text (GAMEOVER) - to bylo doteď neviditelné
        LoseSound.SetActive(true);      // zapne objekt s audiem
    }

    // výhra
    public void GameWin()
    {
        Time.timeScale = 0;     // zastavení hry

        GWPanel.SetActive(true);        // zapne "GameWinPanel"
        LevelManager.Unlock();          // přes program LevelManager odemkne další level
    }


    // fce přepne na scénu DinoProfil
    public void BackToProfil()
    {
        SceneManager.LoadScene("DinoProfil");
    }

    // fce restartuje hru
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");     // obnovení scény GamePlay
    }

    
}