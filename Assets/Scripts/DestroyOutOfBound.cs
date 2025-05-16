using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public Transform topBoundTransform;
    public Transform lowerBoundTransform;

    public string[] tagsToDestroy = { "Enemy", "Bullet" };
    void Update()
    {
        float topBound = topBoundTransform.position.z;
        float lowerBound = lowerBoundTransform.position.z;
        
        //GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (string tag in tagsToDestroy)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                float z = obj.transform.position.z;
                if (z > topBound || z < lowerBound)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
