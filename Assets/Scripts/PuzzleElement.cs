using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PuzzleElement : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _propName = "Clicked";
    [SerializeField] private Animator _puzzleAnimator;
    [SerializeField] private ParticleSystem _particle;
            
    public void OnPointerClick(PointerEventData eventData)
    {
        _puzzleAnimator.SetBool(_propName, true);
        _particle?.Play();

        Invoke(nameof(DropValue), 0.25f);
    }

    private void DropValue()
    {
        _puzzleAnimator.SetBool(_propName, false);
    }
}

