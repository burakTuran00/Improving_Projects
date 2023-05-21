using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Coin,
        ExtraLife,
        MagicMushroom,
        Starpower
    }

    public Type type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect(other.gameObject);
        }
    }

    private void Collect(GameObject player)
    {
        switch (type)
        {
            case Type.Coin:
                //todo
                break;
            case Type.ExtraLife:
                //todo
                break;
            case Type.MagicMushroom:
                //todo
                break;
            case Type.Starpower:
                //todo
                break;
        }

        Destroy (gameObject);
    }
}
