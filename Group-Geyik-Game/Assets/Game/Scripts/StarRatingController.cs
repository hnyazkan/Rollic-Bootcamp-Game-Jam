using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRatingController : MonoBehaviour
{
    public Animator anim; 

    private void Start()
    {
        anim = GetComponent<Animator>();

        switch (Score.stars)
        {
            case 3:
                anim.SetBool("star3Bool", true);
                break;
            case 2:  
                anim.SetBool("star2Bool", true);
                break;
            case 1:     
                anim.SetBool("star1Bool", true);
                break;
            default:
                break;
        }
    }
}
