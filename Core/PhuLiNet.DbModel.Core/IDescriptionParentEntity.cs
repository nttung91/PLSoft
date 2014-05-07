using System.Collections.Generic;

namespace DbModel.Core
{
    public interface IDescriptionParentEntity<TE>
        where TE : IDescriptionEntity
    {
        void AddDescription(TE entity);
        void RemoveDescription(TE entity);
        TE FindDescriptionByLangId(string langId);
        IList<TE> Descriptions { get; set; }
    }
}