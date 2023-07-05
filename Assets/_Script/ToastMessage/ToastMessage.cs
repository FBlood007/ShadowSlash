using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToastMessage : MonoBehaviour
{
    public GameObject toastMessage;

    //function to set toast message active
    public void OnSelect()
    {
        toastMessage.SetActive(true);
        StartCoroutine(Timeout());
       
    }

    //function to set the toastmessage inactive after 2 seconds
    public IEnumerator Timeout()
    {
        yield return new WaitForSeconds(2f);
        toastMessage.SetActive(false);
    }
}