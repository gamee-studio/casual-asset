using DG.Tweening;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    private CameraState _cameraState = CameraState.Focus;
    private bool _isZoomIn;
    private bool _isRotate;
    private int _speedMul = 1;

    [SerializeField] private Vector3 posZoomOut = new Vector3(0,3.5f,-5f);
    [SerializeField] private Vector3 rotationZoomOut = new Vector3(30f,0,0);
    [SerializeField] private Vector3 posZoomIn = new Vector3(0,1.2f,-3f);
    [SerializeField] private Vector3 rotationZoomIn = new Vector3(0,0,0);
    private GoRotate CameraRotation => GetComponent<GoRotate>();
    private Camera Camera => GetComponentInChildren<Camera>();
    private Sequence zoomSequence;
    
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 30, 150, 30), _isZoomIn?"Zoom: ON":"Zoom in: OFF"))
        {
            OnClickZoom();
        }
        if (GUI.Button(new Rect(170, 30, 150, 30), _isRotate?"Rotate: ON":"Rotate: OFF"))
        {
            OnClickRotate();
        }
        if (GUI.Button(new Rect(330, 30, 150, 30), $"Speed: x{_speedMul}"))
        {
            OnClickChangeSpeed();
        }
    }

    private void OnClickZoom()
    {
        zoomSequence?.Kill();
        _isZoomIn = !_isZoomIn;
        if (_isZoomIn)
        {
            zoomSequence = DOTween.Sequence().Append(Camera.transform.DOLocalMove(posZoomIn, .5f)).Join(Camera.transform.DOLocalRotate(rotationZoomIn, .5f)).SetEase(Ease.Linear);
        }
        else
        {
            zoomSequence = DOTween.Sequence()
                .Append(Camera.transform.DOLocalMove(posZoomOut, .5f))
                .Join(Camera.transform.DOLocalRotate(rotationZoomOut, .5f))
                .SetEase(Ease.Linear);
        }
    }

    private void OnClickRotate()
    {
        _isRotate = !_isRotate;
        if (_isRotate)
        {
            CameraRotation.TurnOnRotation();
        }
        else
        {
            CameraRotation.TurnOffRotation();
        }
    }
    
    private void OnClickChangeSpeed()
    {
        switch (_speedMul)
        {
            case 1:
                _speedMul = 2;
                break;
            case 2:
                _speedMul = 3;
                break;
            case 3:
                _speedMul = 1;
                break;
        }
        CameraRotation.SetSpeed(.2f * _speedMul);
    }
}

public enum CameraState
{
    Focus,
    IsZooming,
}