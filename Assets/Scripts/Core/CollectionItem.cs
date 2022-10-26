using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectionItem : MonoBehaviour
{
     string word;
    private int apples = 0;
    [SerializeField] private Text appleText;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            apples++;
            appleText.text = "Apple: " + apples + "\n\n" + "Word: " + word;
        }

        if (collision.gameObject.CompareTag("word"))
        {
            word = "BRAVE";
            Destroy(collision.gameObject);            
            appleText.text = "Apple: " + apples + "\n\n" + "Word: " + word;
        }

    }
}
