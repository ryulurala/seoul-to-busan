using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapClick : MonoBehaviour
{
    public GameObject minimapImage;

    public void minimapClick()
    {
        if (minimapImage != null)
        {
            Animator minimapAnim = minimapImage.GetComponent<Animator>();
            if (minimapAnim != null)
            {
                bool isOpen = minimapAnim.GetBool("isClick");

                minimapAnim.SetBool("isClick", !isOpen);
            }
        }
    }
}
