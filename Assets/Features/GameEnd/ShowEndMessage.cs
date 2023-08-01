using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowEndMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text endMessage;
    private void OnTriggerEnter(Collider other)
    {
        endMessage.enabled = true;
        Time.timeScale = 0;
    }
}