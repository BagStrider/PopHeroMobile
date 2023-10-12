using UnityEngine;

public class EntityView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticlePrefab;
    [SerializeField] private Entity _entity;

    private void Awake()
    {
        _entity.OnDied += PlayDeathParticle;
    }

    private void PlayDeathParticle()
    {
        var deathParticle = Instantiate(_deathParticlePrefab, transform.position, Quaternion.identity);
        Destroy(deathParticle.gameObject, 1.5f);
        
    }
}
