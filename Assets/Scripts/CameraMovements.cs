using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField] private float _sensivity;
    [SerializeField] Inventory  _invent;
    // Update is called once per frame
    void Update()
    {
        float camposy = Input.GetAxis("Mouse Y") * _sensivity;//измением направление по y потому что по X уже меняет персонаж потому что мы дочерние от него

        transform.eulerAngles -= new Vector3(camposy, 0, 0);//меняем направление

        Cursor.lockState = CursorLockMode.Locked;//закрепляем в центре крусор

        Cursor.visible = false;//выключааем курсор
        Debug.DrawLine(transform.position, transform.forward, Color.black);
        Take();
    }

    public void Take()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
            {
           
                thing tg = hit.collider.transform.GetComponent<thing>();
                 _invent.Add(tg.index, tg.count);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
