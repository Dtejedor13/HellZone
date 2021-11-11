using UnityEngine;

namespace Assets.Scripts.Controller
{
    public class CameraController : MonoBehaviour
    {
        public float movementSpeed;
        public float movmentTime;

        public Vector3 newPosition;

        // Start is called before the first frame update
        void Start()
        {
            newPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            HandleMovmentInput();
        }

        void HandleMovmentInput()
        {
            if (Input.GetKey(KeyCode.W))
            {
                //newPosition += (transform.up * movementSpeed);
                newPosition.z += movementSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                //newPosition += (transform.up * -movementSpeed);
                newPosition.z -= movementSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                newPosition += (transform.right * movementSpeed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                newPosition += (transform.right * -movementSpeed);
            }

            transform.position = Vector3.Lerp(transform.position, newPosition, movementSpeed);
        }
    }
}
