using UnityEngine;

public class FundoInfinito : MonoBehaviour
{
	public  float velocidadeFundo = 0.1f;
	private MeshRenderer meshRenderer;

	void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}
	void Update()
	{
		// Move a textura horizontalmente com o tempo
		float deslocamento = Time.deltaTime * velocidadeFundo;
		meshRenderer.material.mainTextureOffset += new Vector2(deslocamento, 0);
	}


	


}