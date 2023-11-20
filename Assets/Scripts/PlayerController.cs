using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable setting
    private float speed = 20.0f ;       
    private float turnSpeed = 25.0f ;
    private float horizontalInput ;   
    private float verticalInput ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Input
        horizontalInput = Input.GetAxis("Horizontal") ;
        verticalInput = Input.GetAxis("Vertical") ;

        //Move
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

    }
    // private void CalculateInputDirection()
    // {
    //     var inputMovement = _moveAction.ReadValue<Vector2>();
    //     if (inputMovement.x > 0.3f)
    //     {
    //         inputMovement.x = 1f;
    //     }
    //     else if (inputMovement.x < -0.3)
    //     {
    //         inputMovement.x = -1f;
    //     }
    //     else
    //     {
    //         inputMovement.x = 0f;
    //     }

    //     if (inputMovement.y > 0.3f)
    //     {
    //         inputMovement.y = 1f;
    //     }
    //     else if (inputMovement.y < -0.3f)
    //     {
    //         inputMovement.y = -1f;
    //     }
    //     else
    //     {
    //         inputMovement.y = 0f;
    //     }

    //     _inputDirection = new Vector3(inputMovement.x, 0f, inputMovement.y);
    // }

}
