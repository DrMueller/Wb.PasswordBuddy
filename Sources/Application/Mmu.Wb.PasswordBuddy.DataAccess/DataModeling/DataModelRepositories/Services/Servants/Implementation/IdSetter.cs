using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation
{
    public class IdSetter : IIdSetter
    {
        private static IReadOnlyCollection<Type> _typesToIgnore = new List<Type> { typeof(string), typeof(DateTime) };

        public void SetIds(AggregateRootDataModel agDm)
        {
            var list = new List<EntityDataModel> { agDm };

            CollectSubEntities(agDm, list);

            list.ForEach(f =>
            {
                if (string.IsNullOrEmpty(f.Id))
                {
                    f.Id = Guid.NewGuid().ToString();
                }
            });
        }

        private static void CollectSubEntities(object? parent, List<EntityDataModel> subEntities)
        {
            if (parent == null)
            {
                return;
            }

            var parentProps = parent.GetType().GetProperties();

            parentProps.ForEach(propInfo =>
            {
                if (propInfo.PropertyType.IsPrimitive || _typesToIgnore.Contains(propInfo.PropertyType))
                {
                    return;
                }

                if (propInfo.PropertyType == typeof(EntityDataModel))
                {
                    var val = (EntityDataModel)propInfo.GetValue(parent);
                    subEntities.Add(val);
                }

                if (propInfo.PropertyType.GetInterfaces().Any(i => i.IsAssignableTo(typeof(IEnumerable<EntityDataModel>))))
                {
                    var val = (IEnumerable<EntityDataModel>)propInfo.GetValue(parent);
                    subEntities.AddRange(val);
                }

                if (propInfo.PropertyType.IsAssignableTo(typeof(IEnumerable<object>)))
                {
                    var arr = (IEnumerable<object>)propInfo.GetValue(parent);

                    arr.ForEach(o => CollectSubEntities(o, subEntities));
                }
                else
                {
                    CollectSubEntities(propInfo.GetValue(parent), subEntities);
                }
            });
        }
    }
}