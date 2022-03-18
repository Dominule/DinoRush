using UnityEngine;

// program generuje překážky


public class Obstacles : MonoBehaviour
{
    float MaxTime;                          // maximální čas tvoření překážek, který nemůže být překročen
    float Timer;                            // reálný počítaný čas, kdy se nabídla minulá překážka

    // objekty překážek
    public GameObject Obstacle1;
    public GameObject Obstacle2;
    public GameObject Obstacle3;
    public GameObject Obstacle4;
    public GameObject Obstacle5;
    public GameObject Obstacle6;
    public GameObject Obstacle7;
    // menší šance na vytvoření:
    public GameObject Obstacle8;        // health
    public GameObject Obstacle9;        // "velký amonit"


    int ChooseObstacle;     // randint, "náhoda" vybírá překážku

    void Start()
    {
        MaxTime = 1f;       // nastavení MaxTime
    }

    void Update()
    {
        Timer += Time.deltaTime;        // zrychlování generování

        // vytvoření nové překážky
        if (Timer >= MaxTime)
        {
            GenerateObstacle();     //  volá fci, která vytvoří novou překážku
            Timer = 0;              // vrátí Timer zpátky na 0
        }
    }


    // funkce náhodně vybírá překážku, kterou vytvoří
    void GenerateObstacle()
    {
        ChooseObstacle = Random.Range(1, 10);       // randint 1-9


        // číslo 1-7 pro jednu z překážek
        // šance na vytvoření Obstacle1 je 1/9 (tj. 0.11111)
        if (ChooseObstacle == 1) { GameObject NewObstacle = Instantiate(Obstacle1); }
        if (ChooseObstacle == 2) { GameObject NewObstacle = Instantiate(Obstacle2); }
        if (ChooseObstacle == 3) { GameObject NewObstacle = Instantiate(Obstacle3); }
        if (ChooseObstacle == 4) { GameObject NewObstacle = Instantiate(Obstacle4); }
        if (ChooseObstacle == 5) { GameObject NewObstacle = Instantiate(Obstacle5); }
        if (ChooseObstacle == 6) { GameObject NewObstacle = Instantiate(Obstacle6); }
        if (ChooseObstacle == 7) { GameObject NewObstacle = Instantiate(Obstacle7); }


        // číslo 8 je speciální
        if (ChooseObstacle == 8)
        {
            ChooseObstacle = Random.Range(1, 4);        // další - randint 1-3

            // dvoutřetinová šance, že se vytvoří Obstacle8 (health)
            // pravděpodobnost:    1/9 * (cca) 2/3 = 2:27 že se vytvoří Obstacle8 (tj. 0.074)
            if (ChooseObstacle == 1 || ChooseObstacle == 2) { GameObject NewObstacle = Instantiate(Obstacle8); }
            if (ChooseObstacle == 3) { GenerateObstacle(); }
        }

        // číslo 9 také speciální
        if (ChooseObstacle == 9)
        {
            ChooseObstacle = Random.Range(1, 3);

            // dvoutřetinová šance, že se vytvoří Obstacle9 ("velký amonit")
            if (ChooseObstacle == 1 || ChooseObstacle == 2) { GameObject NewObstacle = Instantiate(Obstacle9); }
            if (ChooseObstacle == 3) { GenerateObstacle(); }
        }
    }
}
