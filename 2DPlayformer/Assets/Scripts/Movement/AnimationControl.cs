using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationControl : MonoBehaviour
{
    private static readonly int moveAxisX = Animator.StringToHash("moveX");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float moveX)
    {
        _animator.SetFloat(moveAxisX, Mathf.Abs(moveX));
    }
}
