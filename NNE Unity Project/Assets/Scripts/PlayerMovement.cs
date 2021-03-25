
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] float speed = 12f;
    CharacterController controller;
    RaycastHit hit;

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
            return;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 3f))
            {
                Debug.Log("I hit: " + hit.collider.gameObject);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 2f);
            }
            else
            {
                Debug.Log("I missed");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red, 2f);
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

}
