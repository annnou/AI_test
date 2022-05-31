using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapHoldMove : MonoBehaviour
{
    private PlayerInput playerInput = null;

    [SerializeField]
    private Camera mainCameraView = null;

    [SerializeField]
    private Camera subCameraView = null;

    [SerializeField]
    private Transform transFormObjectpos = null;

    [SerializeField]
    private SwitchngUIRPC s = null;

    Vector3 _objPos = Vector3.zero;
    Vector3 _vecPos = Vector3.zero;
    bool _tapScreen = false;
    bool _switching = false;

    enum TapType
    {
        onetap,
        twotap,
    }

    TapType tapType = TapType.onetap;

    void Start()
    {
        TryGetComponent(out playerInput);

        playerInput.SwitchCurrentActionMap("UI");

        var input = playerInput.actions.FindActionMap("UI");

        input["Click"].started += PushOn;
        input["Click"].canceled += PushOff;
        input["Point"].performed += InputPos;
    }

    void Update()
    {
        if(_tapScreen)
        {
            switch (tapType)
            {
                case TapType.onetap:
                    OneTapUpdateState();
                    break;
                case TapType.twotap:
                    TwoTapUpdateState();
                    break;
                default:Debug.Log("default");
                    break;
            }
        }
    }

    private void OneTapUpdateState()
    {
        if(_vecPos.y < 1520 || _vecPos.x < 880)
            transFormObjectpos.position =
            mainCameraView.ScreenToWorldPoint(
                    new Vector3(_vecPos.x, _vecPos.y, 10)) + _objPos;
    }

    private void TwoTapUpdateState()
    {
        if (_vecPos.y < 1520 || _vecPos.x < 880) 
            subCameraView.transform.position = 
                mainCameraView.ScreenToWorldPoint(
                    new Vector3(_vecPos.x, _vecPos.y, -10));
    }

    //one tap 
    public void PushOn(InputAction.CallbackContext info)
    {
        _tapScreen = true;

        _objPos = transFormObjectpos.position -
            mainCameraView.ScreenToWorldPoint(
                        new Vector3(_vecPos.x, _vecPos.y, 10));

        //s.CreateRPC(mainCameraView.transform);
    }

    public void PushOff(InputAction.CallbackContext info)
    {
        _tapScreen = false;
    }

    public void InputPos(InputAction.CallbackContext info)
    {
        _vecPos = info.ReadValue<Vector2>();
    }

    public void Switching()
    {
        _tapScreen = false;

        if (!_switching)
        {
            _switching = true;

            tapType = TapType.twotap;
        }
        else
        {
            _switching = false;

            tapType = TapType.onetap;
        }
    }
}
