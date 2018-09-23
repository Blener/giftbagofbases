namespace GiftBagOfBases.Models
{
    public abstract class SoftDeleteEntity<T> : Entity where T : Entity
    {
        public bool SoftDeleted { get; protected set; }

        protected bool Deleted => true;

        protected bool NotDeleted => false;

        public void Rebirth() => SoftDeleted = false;
    }
}