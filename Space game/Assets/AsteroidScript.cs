using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    [SerializeField] float rotationSpeed; //скорость вращения астероида
    [SerializeField] float minSpeed; // минимальная скорость движения астероида и соответственно максимальная
    [SerializeField] float maxSpeed;
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed; //задаем вращение стероиду

        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
