using UnityEngine;

public class GoRotate : MonoBehaviour
{
    [Header("Attributes")] 
    [SerializeField] private bool _isEnable;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _rotateX;
    [SerializeField] private bool _rotateY;
    [SerializeField] private bool _rotateZ;
    [SerializeField] private void FixedUpdate()
    {
        if (!_isEnable) return;
        var transformTemp = transform;
        if (_rotateX)
        {
            transform.RotateAround(transformTemp.position, transformTemp.right, Time.deltaTime * 90f * _speed);
        }

        if (_rotateY)
        {
            transform.RotateAround(transformTemp.position, transformTemp.up, Time.deltaTime * 90f * _speed);
        }

        if (_rotateZ)
        {
            transform.RotateAround(transformTemp.position, transformTemp.forward, Time.deltaTime * 90f * _speed);
        }
    }

    public void TurnOnRotation()
    {
        _isEnable = true;
    }
    
    public void TurnOffRotation()
    {
        _isEnable = false;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    
    public void IncreaseSpeed(float val)
    {
        _speed += val;
    }
    
    public void DecreaseSpeed(float val)
    {
        _speed -= val;
    }

    public void SetRotateX(bool isOn)
    {
        _rotateX = isOn;
    }
    
    public void SetRotateY(bool isOn)
    {
        _rotateY = isOn;
    }
    
    public void SetRotateZ(bool isOn)
    {
        _rotateZ = isOn;
    }

    public void SetRotate(bool isRotateX, bool isRotateY, bool isRotateZ)
    {
        _rotateX = isRotateX;
        _rotateY = isRotateY;
        _rotateZ = isRotateZ;
    }
}
