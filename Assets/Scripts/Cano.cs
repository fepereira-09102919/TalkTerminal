using UnityEngine;

public class Cano : MonoBehaviour
{

	[Header("Movimento para a Esquerda")]
	public float velocidade = 1.0f;
    public float limiteEsquerdo = -17.0f;
	
	[Header("Movimento Vertical (Sobe e Desce)")]
	public bool canoMovel = false;
	public float velocidadeOndaMinima = 1.5f; // Velocidade mais lenta possível
	public float velocidadeOndaMaxima = 3.5f; // Velocidade mais rápida possível
	public float amplitudeOnda = 1.5f;

	
	private float posicaoYInicial;
	private float velocidadeOndaSorteada;
	private float deslocamentoDoTempo; // A "mágica" para inverter o ciclo

	private void Start()
    {
		posicaoYInicial = transform.position.y;

		// 1. Sorteia uma velocidade única para este cano ao nascer
		velocidadeOndaSorteada = Random.Range(velocidadeOndaMinima, velocidadeOndaMaxima);

		// 2. Sorteia o ponto de início da onda (e inverte a direção se necessário)
		// Se sortearmos um número de 0 a 180, mudamos completamente de onde o ciclo começa!
		deslocamentoDoTempo = Random.Range(0f, 100f);

		posicaoYInicial = transform.position.y;
	}



    void Update()
    {

        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if (transform.position.x < limiteEsquerdo)
        {
            Destroy(gameObject);
        }



        if (canoMovel)
        {

			CalcularFlutuacao();

		}

		void CalcularFlutuacao()
		{
			// Somamos o 'deslocamentoDoTempo' dentro do Seno. 
			// Isso faz com que cada cano comece em uma parte diferente da "onda" matemática.
			float tempoModificado = (Time.time * velocidadeOndaSorteada) + deslocamentoDoTempo;

			float variacaoY = Mathf.Sin(tempoModificado) * amplitudeOnda;

			transform.position = new Vector3(transform.position.x, posicaoYInicial + variacaoY, transform.position.z);
		}


	}









}