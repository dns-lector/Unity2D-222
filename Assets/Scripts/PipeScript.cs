using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        // FPS - залежність - зміна швидкості при зміні FPS
        // this.transform.Translate(Vector3.left *  speed);

        this.transform.Translate(Time.deltaTime * speed * Vector3.left);
    }
}
/* Д.З. Підібрати діапазон величин для швидкості перешкоди "speed"
 * Мінімальне та максимальне значення - у відповідності до складності
 * (але можливості) гри.
 * Прикласти відео/gif запис роботи проєкту.
 */