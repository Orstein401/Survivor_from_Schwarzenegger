using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAnimation : MonoBehaviour
{
    [SerializeField] private string _isActiveParamName = "isActive";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetIsActiveParam(bool isActive)
    {
        _animator.SetBool(_isActiveParamName, isActive);
    }
}
