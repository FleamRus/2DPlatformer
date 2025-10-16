using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationControl : MonoBehaviour
{
    private Animator _animator;

    private static readonly int moveAxisX = Animator.StringToHash("moveX");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float moveX)
    {
        _animator.SetFloat(moveAxisX, Mathf.Abs(moveX));
    }
}
