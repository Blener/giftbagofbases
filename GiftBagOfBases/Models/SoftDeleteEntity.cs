namespace GiftBagOfBases.Models
{
    public abstract class SoftDeleteEntity<T> : Entity where T : Entity, new()
    {
        public bool SoftDeleted { get; set; }

        protected bool Deleted => true;

        protected bool NotDeleted => false;

        public void Rebirth() => SoftDeleted = false;
    }
}