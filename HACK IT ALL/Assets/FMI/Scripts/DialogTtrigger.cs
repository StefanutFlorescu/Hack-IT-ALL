using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string[] messages;
    private int messageIndex;
    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogBox.activeInHierarchy)
            {
                messageIndex = 0;
                dialogBox.SetActive(true);
                dialogText.text = messages[messageIndex];
            }
            else
            {
                messageIndex++;
                if (messageIndex < messages.Length)
                {
                    dialogText.text = messages[messageIndex];
                }
                else
                {
                    dialogBox.SetActive(false);
                }
            }
            Debug.Log("E pressed!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
