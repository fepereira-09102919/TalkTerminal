using UnityEngine;

public class GeradorDeCanos : MonoBehaviour
{
	[Header("Configurações do Prefab")]
	public GameObject prefabCanoNormal; // Arraste o seu Prefab de cano aqui pelo Inspector
	public GameObject prefabCanoEspecial; // Arraste o seu Prefab de cano aqui pelo Inspector

	[Header("Configurações de Tempo")]
	public float tempoMaximo = 5f; // Tempo em segundos entre cada cano
	private float cronometro = 0f;

	[Header("Configurações de Altura")]
	public float alturaMaxima = 1.0f; // Limite que o cano pode subir
	public float alturaMinima = -1.0f; // Limite que o cano pode descer

	void Start()
	{
		if (Pontuacao.pontos >= 10)
		{
			SpawnCano(prefabCanoEspecial);
			
		}
		else
		{
			SpawnCano(prefabCanoNormal);
			
		}
	}

	void Update()
	{
		// O cronômetro acumula o tempo que passou desde o último frame
		cronometro += Time.deltaTime;

		// Se o tempo acumulado passar do tempo máximo estipulado...
		if (cronometro >= tempoMaximo)
		{
			if (Pontuacao.pontos >= 10)
			{
				SpawnCano(prefabCanoEspecial);
				cronometro = 0f; // Reseta o cronômetro para recomeçar a contagem
			}
			else
			{
			SpawnCano(prefabCanoNormal);
			cronometro = 0f; // Reseta o cronômetro para recomeçar a contagem
			}
	
		}
	}

	void SpawnCano(GameObject canoEscolhido)
	{
		// Sorteia um número quebrado entre a altura mínima e máxima
		float alturaAleatoria = Random.Range(alturaMinima, alturaMaxima);

		// Define a posição de nascimento: o X do gerador, mas com o Y sorteado
		Vector3 posicaoNascimento = new Vector3(transform.position.x, alturaAleatoria, 0);

		// O comando mágico: Cria uma cópia do prefab na posição calculada e sem rotação (Quaternion.identity)
		Instantiate(canoEscolhido, posicaoNascimento, Quaternion.identity);
	}








}