using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int cubesPerAxis = 20;
    public float force = 300f;
    public float radius = 2f;
    public float randomRed;
    public float randomGreen;
    public float randomBlue;
    

      private void Start()
    {
        
    }
    
    private void Update()
    {
        randomRed = Random.value;
        randomGreen = Random.value;
        randomBlue = Random.value;
    }


    public void Explode()
    {
       
        for (int x = 0; x < cubesPerAxis; x++)
        {
            for(int y = 0; y < cubesPerAxis; y++)
            {
                for (int z = 0; z < cubesPerAxis; z++)
                    CreateCube(new Vector3(x, y, z));
            }
        }
        
        Destroy(gameObject);
        
        
       
    }

  public void CreateCube(Vector3 coordinates)
    {
        GameObject smallcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        smallcube.transform.localScale = transform.localScale / cubesPerAxis;
        Renderer rd = smallcube.GetComponent<Renderer>();
        rd.material = GetComponent<Renderer>().material;
        rd.material.color = new Color(randomRed, randomGreen, randomBlue);
        

       Vector3 firstcube = transform.position - transform.localScale / 2 + smallcube.transform.localScale / 2;
       smallcube.transform.position = firstcube + Vector3.Scale(coordinates, smallcube.transform.localScale);

        Rigidbody rb = smallcube.AddComponent<Rigidbody>();
        rb.AddExplosionForce(force, transform.position, radius);


    }


  

}
