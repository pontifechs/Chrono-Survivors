using Health;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(Health.Health))]
    [RequireComponent(typeof(FadeSpriteOut))]
    public class Blob : MonoBehaviour
    {
        [SerializeField] private GameObject gem;

        private FadeSpriteOut fadeSpriteOut;
        
        private void Awake()
        {
            GetComponent<Health.Health>().OnDeath += die;
            fadeSpriteOut = GetComponent<FadeSpriteOut>();
        }

        private void die()
        {
            fadeSpriteOut.StartFadeout();
            Instantiate(gem, transform.position, Quaternion.identity);
        }
    }
}