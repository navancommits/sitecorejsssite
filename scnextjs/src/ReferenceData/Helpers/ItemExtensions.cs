using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceDataIntegration.Helpers
{
    public static class ItemExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldId"></param>
        /// <param name="newValue"></param>
        public static void SetFieldValue(this Item item, ID fieldId, string newValue)
        {
            var foundField = item.GetField(fieldId);
            if (foundField != null)
            {
                foundField.Value = newValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public static string GetFieldValue(this Item item, ID fieldId)
        {
            return item.GetField(fieldId)?.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public static Item GetReferenceFieldItem(this Item item, ID fieldId)
        {
            ReferenceField referenceField = item.Fields[fieldId];

            if (referenceField == null)
            {
                return null;
            }
            else if (referenceField.TargetItem == null)
            {
                return null;
            }
            else
            {
                Item referencedItem = referenceField.TargetItem;
                return referencedItem;
            }

        }

        public static Item[] GetMultilistFieldItems(this Item item, ID fieldId)
        {
            MultilistField multiselectField = item.Fields[fieldId];
            return multiselectField.GetItems();
        }

        /// <summary>
        /// Please call item.Fields.ReadAll() before this method if the field could be empty when called
        /// </summary>
        /// <param name="item"></param>
        /// <param name="fieldId"></param>
        /// <returns></returns>
        public static Field GetField(this Item item, ID fieldId)
        {
            var fieldItem = item.Fields.FirstOrDefault(field => field.ID.Equals(fieldId));
            return fieldItem;
        }
        /// <summary>
        /// Finds the child item based on templateId and name, or creates in the database specified if it can't be found
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="childTemplateId"></param>
        /// <param name="childItemName">Name to create child item with if not found</param>
        /// <param name="database">Database to create child item in (usually master db)</param>
        public static Item GetOrAddChildItemByName(this Item parent, ID childTemplateId, string childItemName, Database database)
        {
            var child = parent.Children.FirstOrDefault(item => item.TemplateID.Equals(childTemplateId) && item.Name.Equals(childItemName));
            if (child == null)
            {
                var childTemplate = database.GetTemplate(childTemplateId);
                child = parent.Add(childItemName, childTemplate);
            }
            return child;
        }

    }

}
