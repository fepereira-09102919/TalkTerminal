using TMPro;
using UnityEngine;
using UnityEngine.Rendering; // Necessário para o Volume de Desfoque
using UnityEngine.Rendering.Universal;

public class GerenciadorJogo : MonoBehaviour
{
	[Header("Interfaces (UI)")]
	public GameObject painelMenuInicial; // Arraste o Painel do Menu aqui
	public GameObject hudGameplay;       // Arraste a HUD (Placar/Pausa) aqui

	[Header("Elementos do Jogo")]
	public Rigidbody rbPassaro;          // Arraste o Rigidbody do Pássaro aqui
	public MonoBehaviour scriptPassaro;   // Arraste o script 'MovimentoPassaro' aqui
	public GameObject geradorDeCanos;    // Arraste o objeto GeradorDeCanos aqui

	[Header("Efeitos e Sons")]
	public Volume volumeDeDesfoque;      // Arraste o Global Volume aqui
	//public AudioSource musicaDeFundo;    // Arraste o AudioSource da música aqui
	//public AudioSource somCliqueBotao;   // Arraste o AudioSource do clique aqui (opcional)

	void Start()
	{
		// 1. O jogo começa congelado/em espera
		Time.timeScale = 1f; // Tempo normal, mas os elementos estarão desligados

		// 2. Garante que as telas certas estão ligadas/desligadas no início
		painelMenuInicial.SetActive(true);
		hudGameplay.SetActive(false);

		// 3. Desliga o gerador e bota o pássaro em modo "estátua"
		geradorDeCanos.SetActive(false);
		scriptPassaro.enabled = false;   // Pássaro não responde aos comandos ainda
		rbPassaro.isKinematic = true;    // Pássaro não sofre com a gravidade ainda

		// 4. Configura a música inicial (Mais baixa, conforme o GDD)
		//if (musicaDeFundo != null)
		//{
		//	musicaDeFundo.volume = 0.3f;
		//	musicaDeFundo.Play();
		//}
	}

	// MÉTODO CHAMADO PELO BOTÃO JOGAR
	public void IniciarJogo()
	{
		// Som do clique
		//if (somCliqueBotao != null) somCliqueBotao.Play();

		// 1. Remove o desfoque de fundo
		if (volumeDeDesfoque != null)
		{
			volumeDeDesfoque.gameObject.SetActive(false);
		}

		// 2. Transição de Telas (Esconde o menu e mostra o placar)
		painelMenuInicial.SetActive(false);
		hudGameplay.SetActive(true);

		// 3. Liberta o Pássaro para a ação
		rbPassaro.isKinematic = false;   // Gravidade começa a agir!
		scriptPassaro.enabled = true;    // Jogador já pode pular!

		// 4. Liga o Spawner para começar a criar os canos
		geradorDeCanos.SetActive(true);

		// 5. Sobe a música para 100% de energia
		//if (musicaDeFundo != null)
		//{
		//	musicaDeFundo.volume = 1.0f;
		//}
	}
}