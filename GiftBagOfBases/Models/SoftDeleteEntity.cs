namespace GiftBagOfBases.Models
{
    public abstract class SoftDeleteEntity<T> : Entity where T : Entity
    {
        public bool SoftDeleted { get; protected set; }

        protected bool IAmDeleted => true;

        protected bool IAmNotDeleted => false;

        public void Rebirth() => SoftDeleted = false;
    }
}