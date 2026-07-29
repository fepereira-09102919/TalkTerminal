using UnityEngine;

public class GeradorObstaculos : MonoBehaviour
{
    public GameObject PrefabBolinhas;

   
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Spawn();
        }
    }

    public void Spawn()
    { 
    float posicaoAleatoria = Random.Range(-20f, 20f);
	Vector3 posicaoSpawn = new Vector3(posicaoAleatoria, transform.position.y, 30);

	Instantiate(PrefabBolinhas, posicaoSpawn, Quaternion.identity);
    
    }
     

}
