using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    // Variables
    [SerializeField] private int velocidad;
    [SerializeField] private Rigidbody2D fisica;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int fuerzaSalto;
    [SerializeField] int numVidas;

    private void Awake()
    {
        fisica = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // FixedUpdate es sólo para movimiento horizontal
    void FixedUpdate()
    {
        float entradaX = Input.GetAxis("Horizontal");
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);
        if (fisica.linearVelocity.x > 0) spriteRenderer.flipX = false;
        else if (fisica.linearVelocity.x < 0) spriteRenderer.flipX = true;
    }

    // Update nos permite añadir movimiento vertical
    private void Update()
    {
        // Mecánica de salto
        if (Input.GetKeyDown(KeyCode.Space) && TocarSuelo())
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private bool TocarSuelo()
    {
        // Con esto evitamos que el jugador salte hacia arriba sin parar
        // Comprobamos que sólo puede saltar si está tocando (con un Raycast) el suelo
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }

    public void FinJuego()
    {
        // Con esto construimos otra vez la escena
        // Es decir, se reinicia el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitarVida()
    {
        numVidas--;
        if (numVidas == 0)
        {
            FinJuego();
        }
    }
}