using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[0];
    public float tiempoAnimacion = 0.25f;
    public bool bucle = true;

    private SpriteRenderer renderizadorSprite;
    private int fotogramaAnimacion;

    private void Awake()
    {
        renderizadorSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        renderizadorSprite.enabled = true;
    }

    private void OnDisable()
    {
        renderizadorSprite.enabled = false;
    }

    private void Start()
    {
        InvokeRepeating(nameof(Avanzar), tiempoAnimacion, tiempoAnimacion);
    }

    private void Avanzar()
    {
        if (!renderizadorSprite.enabled) {
            return;
        }

        fotogramaAnimacion++;

        if (fotogramaAnimacion >= sprites.Length && bucle) {
            fotogramaAnimacion = 0;
        }

        if (fotogramaAnimacion >= 0 && fotogramaAnimacion < sprites.Length) {
            renderizadorSprite.sprite = sprites[fotogramaAnimacion];
        }
    }

    public void Reiniciar()
    {
        fotogramaAnimacion = -1;

        Avanzar();
    }
}
