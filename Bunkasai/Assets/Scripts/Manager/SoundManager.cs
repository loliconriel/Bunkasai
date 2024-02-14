using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    GameObject ButtonSound;
    void Start()
    {
        foreach(GameObject gameObject in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            TraverseObject(gameObject);
        }
    }
    void TraverseObject(GameObject gameObject)
    {
        if (gameObject.tag == "NormalButton")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (ButtonSound != null)
                {
                    GameObject Effect = Instantiate(ButtonSound);
                    Destroy(Effect, Effect.GetComponent<AudioSource>().clip.length + 1f);
                }

            });
        }
        foreach (Transform transform in gameObject.transform)
        {
            TraverseObject(transform.gameObject);
        }
    }
    
}
