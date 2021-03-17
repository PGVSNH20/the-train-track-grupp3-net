using System;
using TrainConsole;
using TrainEngine.Models;
using Xunit;

namespace TrainConsole.Tests
{
    public class Tests
    {
        [Fact]
        public void When_LoadingExistingFile_Expect_Success()
        {
            // Arrange
            var train = new Train();
            var station = new Station();
            TrainPlaner trainPlan = new TrainPlaner(train, station);
            string _defaultSavePath = @"..\..\..\..\..\Data\";

            // Act
            trainPlan.Load(_defaultSavePath + "travelPlans-2-Golden Arrow-15-03-2021.json");

            // Assert
            Assert.Contains("Golden Arrow", trainPlan.Train.TrainName);
        }

        [Fact]
        public void When_LoadingNotExistingFile_Expect_ExceptionThrown()
        {
            // Arrange
            var train = new Train();
            var station = new Station();
            TrainPlaner trainPlan = new TrainPlaner(train, station);

            // Assert
            Assert.Throws<System.IO.FileNotFoundException>(() => trainPlan.Load("dfewgdg"));
        }

        [Fact]
        public void When_SavingTrainPlan_Expect_Json()
        {
            // Arrange
            var train = new Train();
            var station = new Station();
            TrainPlaner trainPlan = new TrainPlaner(train, station);
            string _defaultSavePath = @"..\..\..\..\..\Data\";

            // Act
            trainPlan.Save(_defaultSavePath + "save-test.json");

            // Assert
            Assert.Contains(".json", _defaultSavePath + "save-test.json");
        }
    }
}
