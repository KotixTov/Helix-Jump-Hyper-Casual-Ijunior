using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var torque = - touch.deltaPosition.x * Time.deltaTime * _rotationSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            _rigidbody.AddTorque(-Vector3.up * Input.GetAxis("Mouse X") * _rotationSpeed);
        }
#endif        
    }
}
