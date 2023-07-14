using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace weapons
{
    public class Lightning : Repeating
    {
        [SerializeField] float size = 5.0f;
        [SerializeField] int dmg = 1;
        [SerializeField] GameObject lightningPrefab;

        Vector3 RandomOnScreen()
        {
            var origin = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            var max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            return new Vector3(Random.Range(origin.x, max.x), Random.Range(origin.y, max.y), 0);
        }

        void SpawnLightning()
        {
            var target = Horde.RandomVisibleEnemy();
            var position = target != null ? target.transform.position : RandomOnScreen();

            var obj = GameObject.Instantiate(lightningPrefab, position, Quaternion.identity);
            obj.GetComponent<Light2D>().pointLightOuterRadius = size;
            obj.GetComponent<CircleCollider2D>().radius = size;
            obj.GetComponent<DamageOnCollision>().dmg = dmg;
        }

        protected override void Repeat()
        {
            SpawnLightning();
        }
    }
}