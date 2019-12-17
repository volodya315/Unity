using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody ship;
    [SerializeField] float speed;
    [SerializeField] float tilt;
    [SerializeField] float xMin, xMax, zMin, zMax;

    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //1. узнать, куда летит игрок
        var moveHorizontal = Input.GetAxis("Horizontal"); //куда игрок хочет лететь по горизонтали от -1 до +1
        var moveVertical = Input.GetAxis("Vertical");

        //2. полететь тула, куда нажата клавиша
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed; //скорость движения корабля. По оси y 0, так как мы не двигаемся по y

        //3. наклоняем корабль на поворотах
        ship.rotation = Quaternion.Euler(moveVertical * tilt, 0, -moveHorizontal * tilt);

        //4. ограничиваем движение корабля границами экрана
        var xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        var zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(xPosition,5,zPosition);
    }
}
