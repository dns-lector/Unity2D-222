using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // [SerializeField]
    private float speed = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        // FPS - залежність - зміна швидкості при зміні FPS
        // this.transform.Translate(Vector3.left *  speed);

        this.transform.Translate(Time.deltaTime * speed * Vector3.left, Space.World);
    }
}
