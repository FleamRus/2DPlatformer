using UnityEngine;

public class VamperismView : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private VampirismSpell _spell;

    private void Awake()
    {
        if (_sphere != null)
            _sphere.SetActive(false);
    }

    private void OnEnable()
    {
        _spell.IsActiv += SpellActiv;
        _spell.IsStop += SpellStoped;
    }

    private void OnDisable()
    {
        _spell.IsActiv -= SpellActiv;
        _spell.IsStop -= SpellStoped;
    }

    private void OnValidate()
    {
        UpdateSphereRadius();
    }

    private void UpdateSphereRadius()
    {
        if (_sphere != null)
        {
            float spriteSizeInUnits = 2.5f;
            float diametr = _spell.SpaceSpellRadius / spriteSizeInUnits;
            _sphere.transform.localScale = new Vector3(diametr, diametr, 1f);
        }
    }

    private void SetActivateSphere(bool status)
    {
        if (_sphere != null)
            _sphere.SetActive(status);
    }

    private void SpellActiv() => SetActivateSphere(true);
    private void SpellStoped() => SetActivateSphere(false);
}
