using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    void SaveGame(GameObject player) {
        PlayerPrefs.SetFloat("Position_X", player.transform.position.x);
        PlayerPrefs.SetFloat("Position_Y", player.transform.position.y);
        PlayerPrefs.SetFloat("Life", player.GetComponent<PlayerP>().GetVida());
        PlayerPrefs.Save();
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            SaveGame(col.gameObject);
        }
    }
}
