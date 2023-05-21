using UnityEngine;

namespace CasualSlasher.ColorFeatures
{
    public class ParticleSpawner : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private float _destroyDelay = 2f;

        public void SpawnAndPlay()
        {
            var particles = Instantiate(_particles, transform.position, Quaternion.identity);
            particles.Play();

            Invoke(nameof(DestroyObject), _destroyDelay);
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
