using System;
using System.Collections.Generic;
using System.Linq;
using Csla;
using PhuLiNet.Business.Common.CslaBase;

namespace PhuLiNet.Business.Common.Languages.DescriptionBase
{
    [Serializable]
    public class LongDescriptionEditListBase<TList, TEntity> : PhuLiBusinessBindingListBase<TList, TEntity>
        where TList : LongDescriptionEditListBase<TList, TEntity>
        where TEntity : LongDescriptionEditBase<TEntity>
    {

        protected virtual string[] ExcludedLanguageIds
        {
            get { return LanguageList.LanguageIdsToExclude; }
        }

        /// <summary>
        /// If <c>null</c> all languages will be included (default implementation), if <c>new string[0]</c> no language will be included.
        /// </summary>
        protected virtual string[] IncludedLanguageIds
        {
            get { return null; }
        }


        #region Business Methods

        protected override void FetchChildren(IEnumerable<object> databaseObjects)
        {
            RaiseListChangedEvents = false;

            InitializeDescriptions();
            foreach (var item in databaseObjects)
            {
                var desc = DataPortal.FetchChild<TEntity>(item);
                var existingDescr = Find(desc.Language.LangId);

                if (existingDescr == null)
                    continue;
                MapDescription(existingDescr, desc);
                existingDescr.Version = desc.Version;
                existingDescr.RemoveIsDirtyAndIsNewFlag();
            }

            RaiseListChangedEvents = true;
        }

        protected virtual void MapDescription(TEntity existingDescr, TEntity desc)
        {
            existingDescr.Description = desc.Description;
        }

        protected override void Child_Update(params object[] parameters)
        {
            foreach (var entity in this.ToList().Where(entity => !entity.ContainsData()))
            {
                Remove(entity);
            }
            base.Child_Update(parameters);
        }

        // ReSharper disable UnusedMember.Local
        private void Child_Fetch(IEnumerable<object> currentDataAccessObject)
            // ReSharper restore UnusedMember.Local
        {
            ChildFetch(currentDataAccessObject);
        }

        protected virtual void ChildFetch(IEnumerable<object> currentDataAccessObject)
        {
            FetchChildren(currentDataAccessObject);
        }

        #endregion

        #region Factory Methods

        public static TList New()
        {
            var list = DataPortal.CreateChild<TList>();
            list.InitializeDescriptions();
            return list;
        }

        /// <summary>
        /// Initialize an instance of TList
        /// </summary>
        /// <remarks>Require use of factory methods </remarks>
        protected LongDescriptionEditListBase()
        {
        }

        #endregion

        public TEntity Find(string languageId)
        {
            return this.FirstOrDefault(descr => descr.Language.LangId == languageId);
        }

        public TEntity AddNewDescription()
        {
            return (TEntity) AddNewCore();
        }

        public IEnumerable<TEntity> GetDescriptions()
        {
            return this;
        }

        private void InitializeDescriptions()
        {
            var languageList = new LanguageList().Where
                (n => (IncludedLanguageIds == null || IncludedLanguageIds.Contains(n.LangId))
                    && (ExcludedLanguageIds == null || !ExcludedLanguageIds.Contains(n.LangId)));

            foreach (var language in languageList)
            {
                var description = Find(language.LangId);
                if (description == null)
                {
                    description = AddNewDescription();
                    description.Language = language;
                    description.RemoveIsDirtyFlag();
                }

                description.DisplaySequence = language.DisplaySequence;
            }
        }
    }
}