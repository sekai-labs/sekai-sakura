using UnityEngine;

public abstract class SekaiSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    [SerializeField] private bool isLocked;

    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<T>();
            if (_instance != null) return _instance;
            var gameObject = new GameObject(typeof(T).Name);
            _instance = gameObject.AddComponent<T>();
            if ((_instance as SekaiSingleton<T>)?.isLocked == true)
            {
                DontDestroyOnLoad(gameObject);
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            if (_instance == null)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
