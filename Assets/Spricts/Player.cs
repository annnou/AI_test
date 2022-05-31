using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator anim = null;

    private Rigidbody rb = null;
    private PlayerInput p_Input = null;

    static readonly int walkId = Animator.StringToHash("Walk");

    private Vector3 moveVec = Vector3.zero;

    [SerializeField]
    private float moveSpeed = 3;
    
    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out p_Input);

        var _player = p_Input.actions.FindActionMap("Player");

        _player["Move"].performed += Move;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(walkId, moveVec.magnitude);

        moveVec = transform.right * moveVec.x * moveSpeed;
        moveVec += transform.forward * moveVec.z * moveSpeed;
        moveVec.y = rb.velocity.y;

        rb.velocity = moveVec;
    }

    public void Move(InputAction.CallbackContext info)
    {
        Debug.Log("aaa");
        moveVec = new Vector3(info.ReadValue<Vector2>().x * moveSpeed, 0, info.ReadValue<Vector2>().y * moveSpeed);
    }
}