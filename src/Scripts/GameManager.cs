using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-100)]
public class AdministradorDeJuego : MonoBehaviour
{
    public static AdministradorDeJuego Instancia { get; private set; }

    [SerializeField] private Fantasma[] fantasmas;
    [SerializeField] private Pacman pacman;
    [SerializeField] private Transform bolitas;
    [SerializeField] private Text textoFinDeJuego;
    [SerializeField] private Text textoPuntuacion;
    [SerializeField] private Text textoVidas;

    public int puntuacion { get; private set; } = 0;
    public int vidas { get; private set; } = 3;

    private int multiplicadorFantasma = 1;

    private void Awake()
    {
        if (Instancia != null) {
            DestroyImmediate(gameObject);
        } else {
            Instancia = this;
        }
    }

    private void OnDestroy()
    {
        if (Instancia == this) {
            Instancia = null;
        }
    }

    private void Start()
    {
        NuevoJuego();
    }

    private void Update()
    {
        if (vidas <= 0 && Input.anyKeyDown) {
            NuevoJuego();
        }
    }

    private void NuevoJuego()
    {
        EstablecerPuntuacion(0);
        EstablecerVidas(3);
        NuevaRonda();
    }

    private void NuevaRonda()
    {
        textoFinDeJuego.enabled = false;

        foreach (Transform bolita in bolitas) {
            bolita.gameObject.SetActive(true);
        }

        ReiniciarEstado();
    }

    private void ReiniciarEstado()
    {
        for (int i = 0; i < fantasmas.Length; i++) {
            fantasmas[i].ReiniciarEstado();
        }

        pacman.ReiniciarEstado();
    }

    private void FinDeJuego()
    {
        textoFinDeJuego.enabled = true;

        for (int i = 0; i < fantasmas.Length; i++) {
            fantasmas[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    private void EstablecerVidas(int vidas)
    {
        this.vidas = vidas;
        textoVidas.text = "x" + vidas.ToString();
    }

    private void EstablecerPuntuacion(int puntuacion)
    {
        this.puntuacion = puntuacion;
        textoPuntuacion.text = puntuacion.ToString().PadLeft(2, '0');
    }

    public void PacmanComido()
    {
        pacman.SecuenciaMuerte();

        EstablecerVidas(vidas - 1);

        if (vidas > 0) {
            Invoke(nameof(ReiniciarEstado), 3f);
        } else {
            FinDeJuego();
        }
    }

    public void FantasmaComido(Fantasma fantasma)
    {
        int puntos = fantasma.puntos * multiplicadorFantasma;
        EstablecerPuntuacion(puntuacion + puntos);

        multiplicadorFantasma++;
    }

    public void BolitaComida(Bolita bolita)
    {
        bolita.gameObject.SetActive(false);

        EstablecerPuntuacion(puntuacion + bolita.puntos);

        if (!HayBolitasRestantes())
        {
            pacman.gameObject.SetActive(false);
            Invoke(nameof(NuevaRonda), 3f);
        }
    }

    public void BolitaDePoderComida(BolitaDePoder bolita)
    {
        for (int i = 0; i < fantasmas.Length; i++) {
            fantasmas[i].aterrorizado.Habilitar(bolita.duracion);
        }

        BolitaComida(bolita);
        CancelInvoke(nameof(ReiniciarMultiplicadorFantasma));
        Invoke(nameof(ReiniciarMultiplicadorFantasma), bolita.duracion);
    }

    private bool HayBolitasRestantes()
    {
        foreach (Transform bolita in bolitas)
        {
            if (bolita.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ReiniciarMultiplicadorFantasma()
    {
        multiplicadorFantasma = 1;
    }
}
