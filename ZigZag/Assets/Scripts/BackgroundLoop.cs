using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private static BackgroundLoop instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance);
        }
        DontDestroyOnLoad(gameObject);
    }
}
