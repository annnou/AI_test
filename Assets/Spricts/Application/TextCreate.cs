using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TextCreate : MonoBehaviour
{
    [SerializeField]
    GameObject textPrefab = null;

    InputField inputField = null;

    void Start()
    {
        TryGetComponent(out inputField);
    }

    void Update()
    {
        
    }
}
