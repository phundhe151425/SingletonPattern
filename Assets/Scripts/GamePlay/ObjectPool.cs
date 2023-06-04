using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Static Instance
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    public int poolSize = 10;

    [SerializeField] private GameObject prefab;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
      
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject gameObject in pooledObjects)
        {
            if (!gameObject.activeInHierarchy)
            {
                pooledObjects.Remove(gameObject);
                gameObject.SetActive(true);    
                return gameObject;
            }
           
        }

        // Nếu không có đối tượng nào khả dụng trong Object Pool, hãy tạo thêm đối tượng mới
        GameObject newObj = Instantiate(prefab);
        pooledObjects.Add(newObj);
        return newObj;
    }

    // Phương thức để trả lại đối tượng vào Object Pool
    public void ReturnObjectToPool(GameObject obj)
    {
        pooledObjects.Add(obj);
        obj.SetActive(false);
    }
}
