using UnityEngine;
using System;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    [Header("玩家編號")]
    [SerializeField] private string playerID;
    [Header("可調變數")]
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float rotate_speed = 25.0f;
    [SerializeField] private float interactDistance = 1f;
    [Header("設定變數")]
    [SerializeField] private LayerMask counterLayerMask;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject particle;

    private float horizontalInput;
    private float verticalInput;
    private Vector2 inputVector;
    private Vector3 moveDir;
    private Vector3 interactDir;
    private bool isWalking;

    private  Animator animator;
    private KitchenObject KitchenObject;
    private BaseCounter SelectedCounter;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal_" + playerID);
        verticalInput = Input.GetAxisRaw("Vertical_" + playerID);

        inputVector = GetMovementVectorNormalized();
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            interactDir = moveDir;
        }
        //玩家移動
        if ( horizontalInput != 0 || verticalInput != 0)
        {
            PlayerMovement();
            HandleSelectedCounter();
        }
        //玩家互動
        if (Input.GetButtonDown("Interact_" +  playerID))
        {
            PlayerInteract();
        }
        //玩家切
        if (Input.GetButtonDown("Cut_" + playerID))
        {
            PlayerCut();
        }
        //動畫
        HandleWalkAnimation();
        HandleGetThingAnimation();
    }
    //處理方向
    private Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = inputVector.normalized;
        isWalking =inputVector != Vector2.zero;
        return inputVector;
    }
    //按wasd執行Movement
    private void PlayerMovement()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotate_speed);
    }
    //按e執行Interact
    private void PlayerInteract()
    {
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                basecounter.Interact(this);
           }
        }
    }
    //按f執行Cut
    private void PlayerCut()
    {
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                basecounter.Cut(this);
            }
        }
    }
    //選擇counter
    private void HandleSelectedCounter()
    {
        Debug.DrawRay(transform.position, interactDir * interactDistance, Color.red);
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                if (basecounter != SelectedCounter)
                    SetSelectedCounter(basecounter);
            }
            else
                SetSelectedCounter(null);
        }
        else
            SetSelectedCounter(null);
    }
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        if (SelectedCounter != null)
        {
            SelectedCounter.HideVisualObject();
        }
        this.SelectedCounter = selectedCounter;
        if (SelectedCounter != null)
        {
            SelectedCounter.ShowVisualObject();
        }
    }
    
    //定義KitchenObjectParent介面
    public Transform GetPoint()
    {
        return holdPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.KitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }
    public KitchenObject GetKitchenObject()
    {
        return KitchenObject;
    }
    public bool HasKitchenObject()
    {
        return this.KitchenObject != null;
    }

    //Animation
    public void HandleCutAnimation(bool isCutting)
    {
        if (isCutting) {
            animator.SetTrigger("Cut");
            knife.SetActive(true);
        }
        else
            knife.SetActive(false);
    }

    private void HandleGetThingAnimation()
    {
        if (this.HasKitchenObject())
        {            
            animator.SetBool("GetThing", true);
            knife.SetActive(false);
            animator.SetBool("Cut", false);
        }
        else
        {
            animator.SetBool("GetThing", false);
        }
    }

    private void HandleWalkAnimation()
    {
        if (isWalking)
        {
            animator.SetBool("Walk", true);
            particle.SetActive(true);
            knife.SetActive(false);
            animator.SetBool("Cut", false);
        }
        else
        {
            animator.SetBool("Walk", false);
            particle.SetActive(false);
        }
    }
}
