using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;


using OrderOrchestration;

namespace OrderProcessor.Test
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TestGreeting()
        {
            TestLambdaContext context = new TestLambdaContext();
            StepFunctionTasks functions = new StepFunctionTasks();
            string data = "{\"OrderID\":\"9b8fe2eb-94d5-4744-9947-74c47e871cfm\",\"OrderItems\":[\"test1\",\"test2\"],\"Cost\":295,\"IsApprovalRequired\":false}";
            var order= System.Text.Json.JsonSerializer.Deserialize<Order>(data);
            var result = functions.ValidateCostTask(order, context);
            Assert.True(result.IsApprovalRequired);
        }
    }
}
