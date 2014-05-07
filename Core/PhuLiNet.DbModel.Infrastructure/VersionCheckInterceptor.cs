using DbModel.Core;
using NHibernate;
using NHibernate.Type;

namespace Core.DbModel.Infrastructure
{
    public class VersionCheckInterceptor : EmptyInterceptor
    {
        public override bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState,
            string[] propertyNames, IType[] types)
        {
            var asVersionable = entity as IVersionableEntity;
            if (asVersionable != null && propertyNames != null && previousState != null)
            {
                int index = -1;
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    if (propertyNames[i] == "Version")
                    {
                        index = i;
                    }
                }

                if (index >= 0 && asVersionable.Version != 0 && ((int) previousState[index] != asVersionable.Version))
                {
                    throw new StaleObjectStateException(entity.GetType().Name, id);
                }
            }

            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }
    }
}