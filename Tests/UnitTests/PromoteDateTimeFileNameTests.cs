using System;
using System.Globalization;
using BizTalkComponents.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterdom.BizTalk.PipelineTesting;

namespace BizTalkComponents.PipelineComponents.PromoteDateTimeFileName.Tests.UnitTests
{
    [TestClass]
    public class PromoteDateTimeFileNameTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNullFormat()
        {
            var pipeline = PipelineFactory.CreateEmptySendPipeline();

            var component = new PromoteDateTimeFileName();

            pipeline.AddComponent(component, PipelineStage.PreAssemble);
            var message = MessageHelper.Create("<test></test>");

            var outout = pipeline.Execute(message);
        }
       
        [TestMethod]
        public void TestPromoteDate()
        {
            var pipeline = PipelineFactory.CreateEmptySendPipeline();
            var dateFormat = "yyyy-MM-dd";
            var component = new PromoteDateTimeFileName
            {
                DateFormat = dateFormat
            };
            
            pipeline.AddComponent(component, PipelineStage.PreAssemble);
            var message = MessageHelper.Create("<test></test>");

            var output = pipeline.Execute(message);
            var fileName = message.Context.Read(new ContextProperty(FileProperties.ReceivedFileName)) as string;
            
            Assert.IsFalse(string.IsNullOrEmpty(fileName));
            DateTime dateTime;
            Assert.IsTrue(DateTime.TryParseExact(fileName,dateFormat,null, DateTimeStyles.None, out dateTime));
        }
    }
}
