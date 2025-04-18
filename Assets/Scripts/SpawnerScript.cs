using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;  // серіалізувати можна ресурси (не тільки числа)
    [SerializeField]
    private GameObject foodPrefab;

    // Реалізація таймера (періодичних подій)
    private float timeout = 5.0f;
    private float timeLeft;
    private float timeLeftFood;

    void Start()
    {
        timeLeft = 0;
        timeLeftFood = timeout / 2.0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            timeLeft = timeout;
            SpawnPipe();
        }
        timeLeftFood -= Time.deltaTime;
        if (timeLeftFood <= 0)
        {
            timeLeftFood = timeout;
            SpawnFood();
        }
    }

    private void SpawnPipe()
    {
        var pipe = GameObject.Instantiate(pipePrefab);       // ~ new pipePrefab
        pipe.transform.position = this.transform.position    // точка Spawner
            + Vector3.up * Random.Range(-1.5f, 1.5f);        // + випадкове зміщення по вертикалі
    }
    private void SpawnFood()
    {
        var food = GameObject.Instantiate(foodPrefab);       
        food.transform.position = this.transform.position + Vector3.up * Random.Range(-3f, 3f);     
        food.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0f, 360f));
    }
}
