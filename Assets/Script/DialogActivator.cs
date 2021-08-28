using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogLeft, dialogRight;

    [SerializeField]
    private string[] dialogContent;

    [SerializeField]
    private bool[] useLeft;

    [SerializeField]
    private float[] time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator WaitAndPrint() {
        for(int i = 0; i < dialogContent.Length; i++) {
            if (useLeft[i]) {
                dialogRight.SetActive(false);
                dialogLeft.SetActive(true);
                dialogLeft.GetComponentInChildren<Text>().text = dialogContent[i];
            } else {
                dialogLeft.SetActive(false);
                dialogRight.SetActive(true);
                dialogRight.GetComponentInChildren<Text>().text = dialogContent[i];
            }
            yield return new WaitForSeconds(time[i]);
        }
        closeDialogs();

    }

    private void closeDialogs() {
        dialogLeft.GetComponentInChildren<Text>().text = "";
        dialogRight.GetComponentInChildren<Text>().text = "";
        dialogLeft.SetActive(false);
        dialogRight.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            StartCoroutine(WaitAndPrint());
        }
    }

    public void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            closeDialogs();
        }
    }
}
