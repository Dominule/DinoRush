using UnityEngine;
using TMPro;                                // TextMeshPro prvky

// veledůležitý program
// zajišťuje správné vykreslení pozadí, překážek a textů na plátně
// zajišťuje dynamický průběh hry - zrychlování; počítání score; vyhodnocení dokončení levelu >>> gameManager

public class Score : MonoBehaviour
{
    int EndScore;
    // score, při kterém skončí level
    // výchozí 100, přidává se: číslo levelu * 10
    // poslední level ignoruje

    public TextMeshProUGUI LevelNumber;     // číslo aktuálního levelu
    public TextMeshProUGUI HighScoreText;   // nejvyšší dosažené score (má smysl až v posledním - nekonečném levelu)
    int score;                              // zvyšující se score
    TextMeshProUGUI scoreText;              // text reprezentující měnící se score

    public GameManager gameManager;         // odkaz na gamemanager

    // překážky jednotlivých světů
    public GameObject obstacles1;
    public GameObject obstacles2;
    public GameObject obstacles3;
    public GameObject obstacles4;

    private GameObject obstacles;       // proměnná, do které se uloží aktuální překážky

    public GameObject exitModule;       // objekt se aktivuje při skončení levelů 1-39
    public GameObject DevastatingEnd;   // objekt se aktivuje při skončení levelu 40

    // pozadí jednotlivých světů
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;

    // zdroje hry (zrychlování, čas, score)
    float timer;
    float maxTime;          // zajišťuje zvyšování score
    int scoreBooster;       // hráč mění v obchodě, při hře zvyšuje score

    //AudioSource scoreSound;

    public static int devouredInt;        // 1 = orange, 2 = blue

    
    // Start is called before the first frame update
    void Start()
    {
        // vybírání překážek a pozadí podle čísla levelu
        if (LevelSelector.get() <= 10)  { Map1.SetActive(true);     // výběr pozadí
            obstacles = obstacles1;     // výběr překážek
            devouredInt = 1;            // výběr barvy pterodaktyla
        }
        else if (LevelSelector.get() > 10 && LevelSelector.get() <= 20) { Map2.SetActive(true);
            obstacles = obstacles2;
            Debug.Log(LevelSelector.get());
            devouredInt = 2;
        }
        else if (LevelSelector.get() > 20 && LevelSelector.get() <= 30) { Map3.SetActive(true);
            obstacles = obstacles3;
            devouredInt = 2;
        }
        else if (LevelSelector.get() > 30 && LevelSelector.get() <= 40) { Map4.SetActive(true);
            obstacles = obstacles4;
            devouredInt = 1;
        }
        
        obstacles.SetActive(true);      // aktivace překážek

        LevelNumber.text = "Level   " + LevelSelector.get().ToString();     // text - číslo levelu
        HighScoreText.text = "High score   " + PlayerPrefs.GetInt("highscore", 0).ToString("0000");     //text - highscore
        scoreText = GetComponent<TextMeshProUGUI>();        // text - score

        EndScore = 100 + (LevelSelector.get() * 10); // - LevelSelector.get();     // nastavení Endscore podle čísla levelu
        score = 0;      // nastavení výchozího score
        maxTime = 0.1f;     // každou 0.1 sekund se bude score zvyšovat o 1
        scoreBooster = PlayerPrefs.GetInt("ScoreStars", 1);     // rychlejší zvyšování score

        /////////////////////////////// "dinoName" on the race/ is running

        //scoreSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;        // rychlost deltaTime je 0.05 s

        if (timer >= maxTime)
        {
            score++;
            scoreText.text = score.ToString("0000");
            timer = 0;

            if (score <= 100)
            {
                // hra se zrychluje jen do score 100
                Time.timeScale += 0.0005f * LevelSelector.get();
            }


            if (score % 50 == 0)
            {
                // za každých 50 score se hráči naboostí score, který vylepšuje v obchodě
                score += (scoreBooster*2);

                //scoreSound.Play();
            }
        }

        if (Time.timeScale == 0)    // konec hry, zastavení dinosaura
        {
            if (score > PlayerPrefs.GetInt("highscore", 0))
            {
                // pokud hráč nabídnul nové highscore, text se aktualizuje

                PlayerPrefs.SetInt("highscore", score);     // uložení nového highscore
                HighScoreText.text = "High score " + PlayerPrefs.GetInt("highscore", 0).ToString("0000");       // změna textu
            }


            if (LevelSelector.get() == 40)
            {
                // PÁD METEORITU A VYMÍRÁNÍ DRUHŮ !!!

                DevastatingEnd.SetActive(true);
            }
        }

        if (score >= (EndScore - 50) && (LevelSelector.get() != 40))
        {
            // dokud hráč není v levelu 40, levely končí zobrazením panelu GameWin

            obstacles.SetActive(false);     // překážky se přestanou generovat
            exitModule.SetActive(true);     // aktivuje se objekt jeskyně, kam dinosaurus na konci zaběhne

            if (score >= (EndScore))
            {
                // konec levelu

                gameManager.GameWin();
                // aktivace panelu GameWin
                // odemčení dalšího levelu
                // nastavení timeScale = 0
             }
        }
    }
}
