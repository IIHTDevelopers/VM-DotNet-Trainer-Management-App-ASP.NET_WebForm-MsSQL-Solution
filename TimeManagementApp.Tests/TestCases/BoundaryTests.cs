

using TimeManagementApp.DAL.Interrfaces;
using TimeManagementApp.DAL.Services;
using TimeManagementApp.DAL.Services.Repository;
using TimeManagementApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TimeManagementApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly ITimeService _timeService;
        public readonly Mock<ITimeRepository> timeservice = new Mock<ITimeRepository>();

        private readonly Time _time;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _timeService = new TimeService(timeservice.Object);

            _output = output;

            _time = new Time
            {
                Id = 1,
                Date = DateTime.Now,
                TaskName = "Task 1",
                Duration = TimeSpan.FromHours(2),
                Notes = "Completed the task successfully."
            };
        }

        [Fact]
        public async Task<bool> Testfor_Time_Taskname_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                timeservice.Setup(repo => repo.CreateTime(_time)).ReturnsAsync(_time);
                var result = await _timeService.CreateTime(_time);
                var actualLength = _time.TaskName.ToString().Length;
                if (result.TaskName.ToString().Length == actualLength)
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
        public async Task<bool> Testfor_Time_Duration_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                timeservice.Setup(repo => repo.CreateTime(_time)).ReturnsAsync(_time);
                var result = await _timeService.CreateTime(_time);
                var actualLength = _time.Duration.ToString().Length;
                if (result.Duration.ToString().Length == actualLength)
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