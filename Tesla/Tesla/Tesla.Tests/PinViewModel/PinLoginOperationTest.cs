using System.Threading.Tasks;
using Exrin.Abstraction;
using TeslaDefinition.Interfaces.Model;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Tesla.ViewModelOperation;
using Xunit;
using Tesla.Model;
using Exrin.Framework;
using Xunit.Extensions;

namespace Tesla.ViewModelOperation.Tests
{

    public partial class PinLoginOperationTest
    {

        public PinLoginOperationTest()
        {

        }



        public Func<IResult, Task> GetOperation()
        {
            return new PinLoginOperation(new PinModel(new DisplayService(), new ErrorHandlingService()), "<").Function;
        }
        // Business Rule definitions

        public static TheoryData<string[]> SimplePin { get { return new TheoryData<string[]>() { new string[] { "1", "2", "3", "4" } }; } }
        public static TheoryData<string[]> SimplePinWithBackspace { get { return new TheoryData<string[]>() { new string[] { "1", "2", "<", "4", "5" } }; } }
        public static TheoryData<string[]> StartingBackspacePin { get { return new TheoryData<string[]>() { new string[] { "<", "2", "1", "4", "5" } }; } }

        [Theory]
        [MemberData(nameof(SimplePin))]
        [MemberData(nameof(SimplePinWithBackspace))]
        [MemberData(nameof(StartingBackspacePin))]
        public void OperationTest(string[] characters)
        {
            // TODO: need to test by modifying the Model State

            var function = GetOperation();

            int count = 0;
            foreach (var character in characters)
            {
                IResult result = new Result(character);

                function(result);

                Assert.NotNull(result);

                if (count == 3)
                    Assert.Equal(result.ResultAction, ResultType.Navigation);
                else
                    Assert.Equal(result.ResultAction, ResultType.None);

            }
        }

      
    }
}
