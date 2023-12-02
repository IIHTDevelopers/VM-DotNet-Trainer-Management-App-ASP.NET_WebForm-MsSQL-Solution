

using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainerManagementApp.DAL.Interfaces;
using TrainerManagementApp.DAL.Services;
using Xunit;
using Xunit.Abstractions;

namespace TrainerManagementApp.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ITrainerService _trainerService;
        public readonly Mock<ITrainerRepository> trainerservice = new Mock<ITrainerRepository>();

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
        {
            _trainerService = new TrainerService(trainerservice.Object);
            _output = output;
        }

        [Fact]
        public async Task<bool> Testfor_GetAll_Trainers_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                trainerservice.Setup(repos => repos.GetAll()).Returns("");
                var result = _trainerService.GetAll();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_Update_Trainers_NotNull()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();
            int id = 1;

            //Action
            try
            {
                trainerservice.Setup(repos => repos.Update()).Returns("");
                var result = _trainerService.Update();
                //Assertion
                if (result != null)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}