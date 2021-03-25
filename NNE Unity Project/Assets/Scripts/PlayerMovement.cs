
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
    }

    void Update()
    {
        if(!isLocalPlayer)
        {
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<MouseLook>().enabled = false;
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

}
