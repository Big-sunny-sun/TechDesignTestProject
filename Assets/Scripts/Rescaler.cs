using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rescaler : MonoBehaviour
{
    private const float DefaultRatioWidth = 1080f / 1920f;
    private const float DefaultRatioHeight = 1920f / 1080f;
        
    [SerializeField] private float _minValue = 0.75f;
    [SerializeField] private float _maxValue = 1f;
        
    private Transform _targetTransform;

    private void Awake()
    {
        _targetTransform = transform;
            
        RescaleContent(Screen.width, Screen.height);
    }
        
    private void RescaleContent(int width, int height)
    {
        float currentRatioWidth = (float)height / width;
        float currentRatioHeight = (float)width / height;
        float scale;

        if ((currentRatioHeight < DefaultRatioHeight && (currentRatioWidth > DefaultRatioWidth)) || (currentRatioWidth < DefaultRatioWidth))
            scale = DefaultRatioWidth / currentRatioWidth;
        else
            scale = currentRatioWidth / DefaultRatioWidth;
            
        scale = Mathf.Clamp(scale,
            _minValue < 0 ? scale : _minValue,
            _maxValue < 0 ? scale : _maxValue);
            
        _targetTransform.localScale = new Vector3(scale, scale, scale);
    }
}