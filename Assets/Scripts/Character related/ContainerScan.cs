using UnityEngine;

public class ContainerScan : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = transform.parent.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!player.triggerList.Contains(other) && other.gameObject.GetComponent<Container>())
        {
            player.triggerList.Add(other);
            player.OpenContainerPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (player.triggerList.Contains(other))
        {
            player.triggerList.Remove(other);
            if (player.triggerList.Count == 0)
            {
                player.CloseContainerPanel();
            }
        }
    }
}
