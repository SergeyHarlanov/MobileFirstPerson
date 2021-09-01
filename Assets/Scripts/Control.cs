using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Rotation()
    {
        float camposx = Input.GetAxis("Mouse X") * 1;

        transform.eulerAngles -= new Vector3(0, -camposx, 0);
    }

    void Update()
    {
        float posx = Input.GetAxis("Horizontal") * _speed;//узнаем значение двжение по X
        float posy = Input.GetAxis("Vertical") * _speed;//узнаем значение двжение по Y

        Rotation();//меняем направление

        if (Input.GetKey(KeyCode.W))//вперед
        {
            transform.position += (transform.forward * _speed) + (new Vector3(posx, 0, posy) * _speed);
        }
        if (Input.GetKey(KeyCode.A))//влево
        {
            transform.position -= (transform.right * _speed) + (new Vector3(posx, 0, posy) * _speed);
        }
        if (Input.GetKey(KeyCode.D))//вправо
        {
            transform.position += (transform.right * _speed) + (new Vector3(posx, 0, posy) * _speed);
        }
        if (Input.GetKey(KeyCode.S))//назад
        {
            transform.position -= (transform.forward * _speed) + (new Vector3(posx, 0, posy) * _speed);
        }
    }
}
