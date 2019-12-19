using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody ship;
    [SerializeField] float speed; //скорость движения корабля
    [SerializeField] float tilt; //наклон корабля при поворотах
    [SerializeField] float xMin, xMax, zMin, zMax; //координаты, ограничивающие движение по сцене
    [SerializeField] GameObject Gun1;
    [SerializeField] GameObject Gun2;
    [SerializeField] GameObject LazerShot;
    [SerializeField] float ShotDelay; //задержка между выстрелами
    private float NextShot; //время следующего выстрела

    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ShootGuns();
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

    void ShootGuns()
    {
        //задаем стрельбу по нажатию кнопки
        if (Input.GetButton("Fire1") && Time.time > NextShot)
        {
            InitShots();
            NextShot = Time.time + ShotDelay;
        }

    }

    void InitShots()
    {
        //Создаем выстрел лазером из пушек 1 и 2 с нулевым поворотом
        Instantiate(LazerShot, Gun1.transform.position, Quaternion.identity);
        Instantiate(LazerShot, Gun2.transform.position, Quaternion.identity);
    }
}
