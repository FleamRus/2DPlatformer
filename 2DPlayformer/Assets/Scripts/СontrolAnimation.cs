using UnityEngine;

public class ÑontrolAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimationMove(float moveX)
    {
        string moveAxisX = "moveX";

        _animator.SetFloat(moveAxisX, Mathf.Abs(moveX));
    }
}
