using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{


    //方向灵敏度  
    public float RotateSensitivityX = 5F;
    public float RotateSensitivityY = 5F;
    public float MoveSensitivityX = 0.1F;
    public float MoveSensitivityY = 0.1F;
    public float sensitivityZoom = 0.01F;
    private Vector3 targetPos = Vector3.zero + new Vector3(0, 0.8f, 0);
    public Transform target;

    void Update()
    {
        if (Input.GetMouseButton(1))//totate
        {
            transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * RotateSensitivityX);
            transform.RotateAround(targetPos, target.right, Input.GetAxis("Mouse Y") * RotateSensitivityY);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)//zoom
        {
            float delta_z = Input.GetAxis("Mouse ScrollWheel");
            transform.position = transform.position - (-delta_z * sensitivityZoom * (targetPos - transform.position));
        }

        if(Input.GetMouseButton(0))//move
        {
            transform.Translate(new Vector3(-Input.GetAxis("Mouse X") * MoveSensitivityX, -Input.GetAxis("Mouse Y") * MoveSensitivityY, 0));
        }
    }
}
