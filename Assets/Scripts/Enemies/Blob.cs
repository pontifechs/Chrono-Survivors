using Health;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(HasHealth))]
    [RequireComponent(typeof(FadeSpriteOut))]
    public class Blob : MonoBehaviour
    {
        [SerializeField] private GameObject gem;

        private FadeSpriteOut fadeSpriteOut;
        
        private void Awake()
        {
            GetComponent<HasHealth>().OnDeath += die;
            fadeSpriteOut = GetComponent<FadeSpriteOut>();
        }

        private void die()
        {
            fadeSpriteOut.StartFadeout();
            Instantiate(gem, transform.position, Quaternion.identity);
        }
    }
}