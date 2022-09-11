using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceDataIntegration
{
        public class Templates
        {
            public struct FieldOverride
            {
                public struct Fields
                {
                    public static readonly ID LotteryItemLink = new ID("{2B9D2B07-4F9A-41A9-AB51-0C328C2FDBFD}");
                    public static readonly ID OverrideList = new ID("{5C9BBFA8-9FBC-4CC6-A894-D46F766BC3C6}");
                }

            }

            public struct OverrideDetails
            {
                public static readonly ID TemplateId = new ID("{4062576B-06F9-403D-A3BF-ABD341B6EA52}");
                public struct Fields
                {
                    public static readonly ID FieldToOverride = new ID("{1919D2C4-73CB-475B-A2D6-115C2E858F22}");
                    public static readonly ID OverrideValue = new ID("{874A147F-237C-41A5-8461-674D9F9500A5}");
                }

            }
            
            public struct LotteryReferenceData
            {
                public static readonly ID TemplateId = new ID("{B0A521DA-E269-447C-B500-1E753E01C80A}");
                public struct Fields
                {
                    public static readonly ID LotteryId = new ID("{8D5E678B-E0D1-4730-B2F5-3E6B55C2D881}");
                    public static readonly ID LotteryTitle = new ID("{2411F3FD-BB85-43C1-9D56-2D2643B4029E}");
                    public static readonly ID LotteryDescription = new ID("{18A46055-17AF-4888-92C6-DEB0F14F5E7F}");
                    public static readonly ID LotteryDrawDate = new ID("{06DD81BF-EFF4-44D9-B533-CDC203B7582E}");                    
                }
            }
           
        }
}
