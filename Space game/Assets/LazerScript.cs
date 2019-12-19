using UnityEngine;

public class LazerScript : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed; //заставляем выстрел двигаться только вперед
    }

    // Update is called once per frame
    void Update()
    {

    }
}
