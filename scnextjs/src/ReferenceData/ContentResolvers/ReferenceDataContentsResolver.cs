using Sitecore.Data.Items;
using Sitecore.LayoutService.Configuration;
using Sitecore.LayoutService.ItemRendering.ContentsResolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Mvc.Presentation;
using ReferenceDataIntegration.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Common;
using Newtonsoft.Json.Linq;

namespace ReferenceDataIntegration.ContentResolvers
{
    public class ReferenceDataContentsResolver : RenderingContentsResolver
    {
        public override object ResolveContents(Rendering rendering, IRenderingConfiguration renderingConfig)
        {
            var contextItem = GetContextItem(rendering, renderingConfig);
            var originalFields = ProcessItem(contextItem, rendering, renderingConfig);

            //Pull rendering datasource and page.  
            Item lotteryItem;
            var lotteryItemRendering = rendering.Item.GetReferenceFieldItem(Templates.FieldOverride.Fields.LotteryItemLink);

            if (lotteryItemRendering != null)
            {
                lotteryItem = lotteryItemRendering;
            }
            else
            {
                return originalFields;
            }

            var overrideItems = contextItem.GetMultilistFieldItems(Templates.FieldOverride.Fields.OverrideList);
            overrideItems.ForEach(item =>
            {
                if (item.TemplateID.Equals(Templates.OverrideDetails.TemplateId))
                {
                    //Perform field override
                    var fieldToOverride = item.GetReferenceFieldItem(Templates.OverrideDetails.Fields.FieldToOverride)?.DisplayName;
                    var overrideValueFieldItem = item.GetReferenceFieldItem(Templates.OverrideDetails.Fields.OverrideValue);
                    if (fieldToOverride == null || overrideValueFieldItem == null) return;

                    Field field = lotteryItem.GetField(overrideValueFieldItem.ID);
                    if (field == null) return;
                    string overrideValue = string.Empty;

                    if (field.ID == Templates.LotteryReferenceData.Fields.LotteryId)
                    {
                        overrideValue = ApplyIdLogic(field);
                        originalFields=ApplyOverrideValue(originalFields, fieldToOverride, overrideValue);
                    }

                    if (field.ID == Templates.LotteryReferenceData.Fields.LotteryTitle)
                    {
                        overrideValue = ApplyTitleLogic(field);
                        originalFields = ApplyOverrideValue(originalFields, fieldToOverride, overrideValue);
                    }
                    
                }
                
            });

            return originalFields;
        }
        private string ApplyIdLogic(Field field)
        {
            var fieldValue = field.GetValue(false);
            
            //treat as string
            return "Lotto:" + fieldValue;
        }

        private string ApplyTitleLogic(Field field)
        {
            var fieldValue = field.GetValue(false);

            //treat as string
            return "Bonanza Lottery:" + fieldValue;
        }

        private JObject ApplyOverrideValue(JObject originalFields,string fieldToOverride,string overrideValue)
        {
            if (originalFields.ContainsKey(fieldToOverride))
                originalFields[fieldToOverride]["value"] = overrideValue;

            return originalFields;
        }
    }

}
