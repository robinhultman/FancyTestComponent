using System;
using System.Collections;
using System.Linq;
using BizTalkComponents.Utils;

namespace BizTalkComponents.PipelineComponents.PromoteDateTimeFileName
{
    public partial class PromoteDateTimeFileName
    {
        public string Name { get { return "PromoteDateTimeFileName"; } }
        public string Version { get { return "1.0"; } }
        public string Description { get { return "Promotes the current date time to the SourceFileName property in the specified format."; } }
        
        public void GetClassID(out Guid classID)
        {
            classID = new Guid("0534895C-3ECA-4C8F-BE3C-82A21FAC2349");
        }

        public void InitNew()
        {

        }

        public IEnumerator Validate(object projectSystem)
        {
            return ValidationHelper.Validate(this, false).ToArray().GetEnumerator();
        }

        public bool Validate(out string errorMessage)
        {
            var errors = ValidationHelper.Validate(this, true).ToArray();

            if (errors.Any())
            {
                errorMessage = string.Join(",", errors);

                return false;
            }

            errorMessage = string.Empty;

            return true;
        }


        public IntPtr Icon { get { return IntPtr.Zero; } }
    }
}
