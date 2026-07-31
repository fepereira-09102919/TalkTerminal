using UnityEngine;
using TMPro;

public class GerenciadorTerminal : MonoBehaviour
{
	public TMP_InputField inputField;
	public TMP_Text textoTerminal; // O textão do terminal

	void Start()
	{
		// Garante que o jogador já comece digitando sem precisar clicar na barra
		inputField.ActivateInputField();

		textoTerminal.text = "Aqui sua jornada começa!. \nINVESTIGADOR, DIGITE SEU COMANDO:\n";
	}

	
	// Esse método deve ser interligado ao evento "On End Edit" do Input Field na Unity
	public void escrever(string msg)
	{
		msg = inputField.text;
		textoTerminal.text += $"\n>{msg}\n";

		inputField.text = "";
		inputField.ActivateInputField(); // Foca o cursor de volta

	}

}





//	// Esse método deve ser interligado ao evento "On End Edit" do Input Field na Unity
//	public void AoEnviarComando(string textoDigitado)
//	{
//		// Se o jogador der Enter sem digitar nada, ignore
//		if (string.IsNullOrWhiteSpace(textoDigitado)) return;

//		// 1. Mostra o que o jogador digitou no histórico
//		historicoTexto.text += $"\n> {textoDigitado}\n";

//		// 2. Limpa o campo de digitação
//		inputField.text = "";
//		inputField.ActivateInputField(); // Foca o cursor de volta

//		// 3. Processa a resposta
//		ProcessarResposta(textoDigitado.ToLower());
//	}

//	void ProcessarResposta(string entrada)
//	{
//		// Exemplo simples de checagem de palavras-chave
//		if (entrada.Contains("falar") && entrada.Contains("testemunha"))
//		{
//			historicoTexto.text += "A testemunha diz: 'O suspeito comprou uma passagem para o Egito e tinha um sotaque francês.'\n";
//		}
//		else if (entrada.Contains("viajar") && entrada.Contains("egito"))
//		{
//			historicoTexto.text += "Viajando para o Cairo, Egito...\n";
//		}
//		else
//		{
//			historicoTexto.text += "Comando não reconhecido. Tente 'falar com testemunha' ou 'viajar para [local]'.\n";
//		}

//		// TODO: Aqui você pode colocar uma lógica para fazer o Scroll View descer automaticamente
//	}
//}