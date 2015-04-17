

using System;
using System.Collections;
using System.ComponentModel;
using BizTalkComponents.Utils;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Message.Interop;
using IComponent = Microsoft.BizTalk.Component.Interop.IComponent;

namespace BizTalkComponents.PipelineComponents.PromoteDateTimeFileName
{
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("53665F25-9F17-4508-9E2F-D0CFE2F37289")]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public partial class PromoteDateTimeFileName : IComponent, IBaseComponent,
                                        IPersistPropertyBag, IComponentUI
    {
        [RequiredRuntime]
        [DisplayName("Date Format")]
        [Description("The format of the expected date.")]
        public string DateFormat { get; set; }

        private const string DateFormatPropertyName = "DateFormat";

        public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
        {
            string errorMessage;

            if (!Validate(out errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            var fileNameProperty = new ContextProperty(FileProperties.ReceivedFileName);

            pInMsg.Context.Promote(fileNameProperty,DateTime.Now.ToString(DateFormat));

            return pInMsg;
        }

        public void Load(IPropertyBag propertyBag, int errorLog)
        {
            DateFormat = PropertyBagHelper.ToStringOrDefault(PropertyBagHelper.ReadPropertyBag(propertyBag, DateFormatPropertyName), string.Empty);
        }

        public void Save(IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
        {
            PropertyBagHelper.WritePropertyBag(propertyBag, DateFormatPropertyName, DateFormat);
        }
    }
}
