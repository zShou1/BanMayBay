using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    string name = typeof(T).Name;
                    Debug.LogFormat("Create singleton object: {0}", name);
                    instance = new GameObject(name).AddComponent<T>();
                    if (instance == null)
                    {
                        Debug.LogWarning("Can't find singleton object: " + typeof(T).Name);
                        Debug.LogError("Can't create singleton object: " + typeof(T).Name);
                        return null;
                    }
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = (T)this;
            return true;
        }

        if (Instance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }

    protected void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }
}


public class ObjectPutter : SingletonMonoBehaviour<ObjectPutter>
{
    [SerializeField] private SpawnerTable table;

    private Dictionary<SpawnerType, Spawner> spawnerDict = new Dictionary<SpawnerType, Spawner>();

    private void Awake()
    {
        base.Awake();
        if (table == null)
        {
            table = Resources.Load("SpawnerTable") as SpawnerTable; // load file SpawnerTable đã tạo ở trên
        }
    }

    public Transform PutObject(SpawnerType type)
    {
        return Spawn(type);
    }

    private Transform Spawn(SpawnerType type)
    {
        if (!HasSpawner(type) && !CreateSpawner(type))
        {
            return null;
        }

        Transform transform = spawnerDict[type].Spawn();
        return transform;
    }

    private bool CreateSpawner(SpawnerType type)
    {
        SpawnerInfo spawnerInfo = table.GetSpawnerInfo(type);
        if (spawnerInfo == null)
        {
            Debug.LogError("error. hasn't " + type + " in spawner table");
            return false;
        }
        GameObject spawnerObject = new GameObject(spawnerInfo.prefab.name + "Spawner");
        spawnerObject.transform.SetParent(transform);
        spawnerObject.transform.localPosition = Vector3.zero;
        spawnerObject.AddComponent<Spawner>();
        spawnerObject.GetComponent<Spawner>().Init(type, spawnerInfo.prefab);
        spawnerDict.Add(type, spawnerObject.GetComponent<Spawner>());
        return true;
    }

    private bool HasSpawner(SpawnerType key)
    {
        return spawnerDict.ContainsKey(key);
    }
}
