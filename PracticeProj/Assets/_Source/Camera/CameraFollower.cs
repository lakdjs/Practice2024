using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float sensitivity; // чувствительность мышки
    [SerializeField] private float limit; // ограничение вращения по Y
    [SerializeField] private float zoom; // чувствительность при увеличении, колесиком мышки
    [SerializeField] private float zoomMax; // макс. увеличение
    [SerializeField] private float zoomMin; // мин. увеличение
    private float X, Y;
    

    void Start()
    {
        limit = Mathf.Abs(limit);
        //if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, offset.z);
        transform.position = target.position + offset;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
            offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, limit);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
            transform.position = transform.localRotation * offset + target.position;
        }
    }
}
