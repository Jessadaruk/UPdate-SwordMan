using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls controls;

    public Vector2 moveInput;
    public bool jumpPressed;
    public float valueX;   // 👈 เพิ่มตัวนี้

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
            valueX = moveInput.x;   // 👈 อัปเดตค่า
        };
        controls.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
            valueX = 0f;
        };
        controls.Player.Jump.performed += ctx => jumpPressed = true;

        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    public void ResetJump()
    {
        jumpPressed = false;
    }

    // 👇 ฟังก์ชันนี้จะใช้แทน myControl.Disable() ที่เว็บบอก
    public void DisableControls()
    {
        controls.Player.Disable();
        moveInput = Vector2.zero;
        valueX = 0f;
        jumpPressed = false;
        enabled = false; // ปิดสคริปต์นี้ไปเลย
    }
}
