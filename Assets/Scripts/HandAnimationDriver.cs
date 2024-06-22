using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationDriver : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private InputActionProperty inputSelectValue;
    [SerializeField] private InputActionProperty inputActivateValue;

    private void Start()
    {
        animator = GetComponent<Animator>();

        inputSelectValue.action.performed += PlayerIsGripping;
        inputSelectValue.action.canceled += PlayerIsGripping;

        inputActivateValue.action.performed += PlayerIsDelecting;
        inputActivateValue.action.canceled += PlayerIsDelecting;
    }

    public void PlayerIsGripping(InputAction.CallbackContext inputActionCallback)
    {
        float inputValue = inputSelectValue.action.ReadValue<float>();
        animator.SetFloat("Grip", inputValue);
    }

    public void PlayerIsDelecting(InputAction.CallbackContext inputActionCallback)
    {
        float inputValue = inputActivateValue.action.ReadValue<float>();
        animator.SetFloat("Trigger", inputValue);
    }
}