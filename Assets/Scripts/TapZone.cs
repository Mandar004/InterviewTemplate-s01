using UnityEngine;
using UnityEngine.EventSystems;

public class TapZone : MonoBehaviour, IPointerClickHandler
{
    public enum ZoneType { Player, Opponent }
    public ZoneType zone;
    public RopeController ropeController;

    public void OnPointerClick(PointerEventData eventData)
    {
        ropeController.MoveRope(zone == ZoneType.Player);
    }
}