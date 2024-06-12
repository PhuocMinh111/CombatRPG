using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    private Player Player => GetComponentInParent<Player>();

    public void OnAnimationTrigger()
    {
        Debug.Log("On Animation Trigger");
        Player.OnAnimationTrigger();
    }
}
