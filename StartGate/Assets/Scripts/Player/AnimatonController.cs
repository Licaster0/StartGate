using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatonController : MonoBehaviour
{
  public Animator animator;
  public void MoveOnAnimator()
  {
    animator.SetFloat("speed", 1);
  }
  public void StopOnAnimator()
  {
    animator.SetFloat("speed", 0);
  }
}
