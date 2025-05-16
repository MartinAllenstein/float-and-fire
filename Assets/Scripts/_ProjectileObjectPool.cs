using System.Collections.Generic;
using UnityEngine;

public class ProjectileObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int initialPoolSize = 10;

    private readonly List<GameObject> projectilePool = new();

    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void CreateNewProjectile()
    {

    }

    public GameObject Acquire()
    {
        return null;
    }

    public void Return(GameObject projectile)
    {

    }
}
