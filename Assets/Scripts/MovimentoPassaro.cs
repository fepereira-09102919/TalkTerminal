using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoPassaro : MonoBehaviour
{
    [Header("Configurações de Voo")]
    public float forcaDoPulo = 5.0f;
    private Rigidbody rb;
    public Transform asa;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Pular();
        }

        if (Input.GetKeyDown(KeyCode.Escape))

        {
            ReiniciarJogo();
        }
		

		asa.localRotation = Quaternion.Lerp(asa.localRotation, Quaternion.identity, Time.deltaTime * 5f);

	}

    void Pular()
    {
        
        rb.linearVelocity = Vector2.up * forcaDoPulo;
		asa.localRotation = Quaternion.Euler(-30, 0, 0);
        


	}
    private void OnCollisionEnter(Collision colisao)
    {
        ReiniciarJogo();
    }
    public static void ReiniciarJogo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PassouEntre"))
        {
            Debug.Log("Passou entre os canos!!");
        }
    }

}