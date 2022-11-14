using System;
using UnityEngine;
using DG.Tweening;

public class PlayerInput : MonoBehaviour
{
    private int _downHashCode;

    private void Start()
    {
        DOTween.Init(logBehaviour: LogBehaviour.Verbose);
    }

    public bool IsEqualHashCode(int hashCode) => _downHashCode == hashCode;
    
    public void SetHashCode(int hashCode) => _downHashCode = hashCode;
}
