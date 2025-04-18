using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    [SerializeField] private float forceFactor = 100.0f;    // 1.0e2
    [SerializeField] private Image healthIndicator;
    [SerializeField] private GameObject alertCanvas;
    [SerializeField] private TMPro.TextMeshProUGUI alertTitle;
    [SerializeField] private TMPro.TextMeshProUGUI triesTitle;

    private Rigidbody2D rb;
    private float health;
    private int tries;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 100f;
        alertCanvas.SetActive(false);
        tries = 3;
        triesTitle.text = tries.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * forceFactor);
        }
        health -= Time.deltaTime;
        if (health < 0 && Time.timeScale > 0f)
        {
            Loose("Програна спроба. Ви зголодніли");
        }
        else
        {
            healthIndicator.fillAmount = health / 100f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            GameObject.Destroy(collision.gameObject);
            health = Mathf.Clamp(health + 50f, 0f, 100f);
        }
        else if (collision.CompareTag("Pipe"))
        {
            Loose("Програна спроба. Ви влучили у перешкоду");
        }
        Debug.Log(collision.tag);
    }

    private void Loose(string alertMessage)
    {
        tries -= 1;
        triesTitle.text = tries.ToString();
        if (tries > 0)
        {
            alertTitle.text = alertMessage;
        }
        else
        {
            alertTitle.text = "Game Over";
        }
        alertCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnAlertButtonClick()
    {
        if (tries > 0)
        {
            // Видаляємо зі сцени всі об'єкти Pipe
            foreach (var pipe in GameObject.FindGameObjectsWithTag("Pipe"))
            {
                if (pipe.transform.parent != null)
                {
                    GameObject.Destroy(pipe.transform.parent.gameObject);
                }
                else
                {
                    GameObject.Destroy(pipe);
                }
            }
            // Видаляємо зі сцени всі об'єкти Food
            foreach (var food in GameObject.FindGameObjectsWithTag("Food"))
            {
                GameObject.Destroy(food);
            }
            // Запускаємо час, прибираємо alert
            alertCanvas.SetActive(false);
            // відновлюємо health
            health = 100f;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        Time.timeScale = 1.0f;
        // Debug.Log("OnAlertButtonClick");
    }
}
/* Реалізувати відображення кількості спроб у вигляді картинок персонажа
 * що повторюються відповідну кількість разів
 * Додати бонус, який додає додаткову спробу, генерувати його 
 * з невисокою імовірністю (один раз на 10-20 періодів)
 */
