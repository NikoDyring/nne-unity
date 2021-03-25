using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 100f;
    [SerializeField] Transform playerBody;
    RaycastHit hit;
    DataCube dataCube;

    float xRotation = 0f;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        Interact();
        ExitUI();
    }

    private void ExitUI()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            DisplayDataCube.Instance.Hide();
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 6f))
            {
                if (hit.collider.tag == "DataCube")
                {
                    dataCube = hit.collider.gameObject.GetComponent<DataCube>();
                    DisplayDataCube.Instance.SetData(dataCube).Show();
                    Debug.Log("DATACUBE HIT:" + hit.collider.gameObject.name);
                }
                else if (hit.collider.tag == "QRCode")
                {
                    QRCode qrCode = hit.collider.gameObject.GetComponentInParent<QRCode>();
                    ModelManager.Instance.AlignModel(qrCode.transform, qrCode.GetComponent<QRCode>().ghostQR);
                    Debug.Log("QRCode HIT: " + hit.collider.gameObject.name);
                }
            }
        }
    }
}
