using UnityEngine;

public class MovimentoCapsula : MonoBehaviour
{
	public float velocidadeQueda = 5f;
    void Update()
    {
		transform.Translate(Vector3.down * velocidadeQueda * Time.deltaTime);
		
		if (transform.position.y < -4f)
		{
			Destroy(gameObject);
		}

	}
}
