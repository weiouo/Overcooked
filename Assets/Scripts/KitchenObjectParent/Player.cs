using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedEventArgs> OnSelectedCounter;
    public class OnSelectedEventArgs : EventArgs
    {
        public BaseCounter SelectedCounter;
    }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask counterLayerMask;
    [SerializeField] private Transform holdPoint;
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float rotate_speed = 25.0f;
    [SerializeField] private float interactDistance = 1f;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject particle;
    private  Animator animator;
    private Vector3 interactDir;
    private bool isWalking;
    private KitchenObject KitchenObject;
    private BaseCounter SelectedCounter;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one Player");
        }
        Instance = this;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        gameInput.OnCutAction += GameInput_OnCutAction;
    }
    void Update()
    {
        PlayerMovement();
        PlayerInteract();
        HandleWalkAnimation();
        HandleGetThingAnimation();
    }

    //按e執行Interact
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
             interactDir = moveDir;
        }
        Debug.DrawRay(transform.position, interactDir * interactDistance, Color.red);
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                basecounter.Interact(this);
           }
        }
    }
    private void PlayerInteract()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            interactDir = moveDir;
        }
        Debug.DrawRay(transform.position, interactDir * interactDistance, Color.red);
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                if (basecounter != SelectedCounter)
                {
                    SetSelectedCounter(basecounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }
    private void SetSelectedCounter(BaseCounter selectedCounter)
    {
        this.SelectedCounter = selectedCounter;

        OnSelectedCounter?.Invoke(this, new OnSelectedEventArgs { SelectedCounter = selectedCounter });
    }
    //按f執行Cut
    private void GameInput_OnCutAction(object sender, System.EventArgs e)
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            interactDir = moveDir;
        }
        if (Physics.Raycast(transform.position, interactDir, out RaycastHit raycastHit, interactDistance, counterLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter basecounter))
            {
                basecounter.Cut();
            }
        }
    }
    //移動
    private void PlayerMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        if (moveDir != Vector3.zero)
        {
            interactDir = moveDir;
        }

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotate_speed);
        isWalking = moveDir != Vector3.zero;
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


    //判斷Play狀態
    public void HandleCutAnimation(bool isCutting)
    {
        animator.SetTrigger("Cut");
        if (isCutting)
            knife.SetActive(true);
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
