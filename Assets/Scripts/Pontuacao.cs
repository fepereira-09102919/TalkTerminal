using UnityEngine;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    public TextMeshProUGUI textoPlacar;
	public TextMeshProUGUI textoRecorde;
	public static int pontos = 0;
	public static int recorde = 0;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		pontos = 0;
		recorde = PlayerPrefs.GetInt("RecordeFlappy", 0);
		textoRecorde.text = ($"HIGHSCORE: {recorde}");

	}

    private void OnTriggerEnter(Collider other)
    {
		pontos++;
		textoPlacar.text = pontos.ToString("D2");
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (pontos > recorde)
        {
            recorde = pontos;
			MovimentoPassaro.ReiniciarJogo();
			// --- SALVAR O RECORDE NA MEMÓRIA ---
			// Grava o novo valor na etiqueta "RecordeFlappy"
			PlayerPrefs.SetInt("RecordeFlappy", recorde);

			// Força a Unity a salvar os dados no HD/Celular imediatamente
			PlayerPrefs.Save();
        }
        
            
			
            MovimentoPassaro.ReiniciarJogo();

		
    }


}
