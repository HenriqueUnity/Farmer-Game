using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    // Prefab do objeto a ser instanciado
    [SerializeField] private GameObject objectPrefab;

    // Quantidade de objetos no pool
    [SerializeField] private int poolSize = 8;

    // Lista dos objetos no pool
    private List<GameObject> objectPool;

    void Start()
    {
        // Cria a lista de objetos do pool
        objectPool = new List<GameObject>();

        // Instancia os objetos e os adiciona ao pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        // Procura por um objeto inativo no pool
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // Se não houver objetos inativos, cria um novo e o adiciona ao pool
        GameObject newObj = Instantiate(objectPrefab, transform);
        newObj.SetActive(true);
        objectPool.Add(newObj);
        return newObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        // Desativa o objeto e o retorna ao pool
        obj.SetActive(false);
    }
}
