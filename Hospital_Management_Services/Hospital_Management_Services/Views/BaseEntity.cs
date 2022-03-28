using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_Services
{
    public abstract class BaseEntity
    {
        public List<BaseEvent> DomainEvents = new List<BaseEvent>();
        public long Id { get; set; }

        public override bool Equals(object obj)
        {
            BaseEntity entity = obj as BaseEntity;
            if (ReferenceEquals(obj, null))
                return false;
            else if (ReferenceEquals(this, obj))
                return true;
            else if (GetType().Name != obj.GetType().Name)
                return false;

            return this.Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return (GetType().FullName + this.Id).GetHashCode();
        }
    }
}
