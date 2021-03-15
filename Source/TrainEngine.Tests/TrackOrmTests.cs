using TrainConsole;
using TrainEngine;
using TrainEngine.Models;
using TrainEngine.Reader;
using TrainEngine.Utilities;
using Xunit;

namespace TrainEngine.Tests
{
    public class TrackOrmTests
    {
        static readonly string _defaultSavePath = @"..\..\..\..\..\Data\";

        [Fact]
        public void When_OnlyAStationIsProvided_Expect_TheResultOnlyToContainAStationWithId1()
        {
            // Arrange
            string track = "[1]";
            TrackOrm trackOrm = new TrackOrm();

            // Act
            var result = trackOrm.ParseTrackDescription(track);

            // Assert
            //Assert.IsType<Station>(result.TackPart[0]);
            //Station s = (Station)result.TackPart[0];
            //Assert.Equal(1, s.Id);
        }

        [Fact]
        public void When_ProvidingTwoStationsWithOneTrackBetween_Expect_TheTrackToConcistOf3Parts()
        {
            // Arrange
            string track = "[1]-[2]";
            TrackOrm trackOrm = new TrackOrm();
            
            // Act
            var result = trackOrm.ParseTrackDescription(track);

            // Assert
            Assert.Equal(3, result.NumberOfTrackParts);
        }
        [Fact]
        public void When_LoadingFromJsonFile_Expect_OnePopulatedListOfTimbeTable()
        {
            //// Arrange
            //Train goldenArrow = new Train() { TrainId = 2, TrainName = "Golden Arrow", MaxSpeed = 120, IsOperated = true };
            //Station stonecro = new Station("Stonecro");

            //ITravelPlan travelPlan = new TrainPlaner(goldenArrow, stonecro);

            //// Act
            //travelPlan.Load(_defaultSavePath + "travelPlans-2-Golden Arrow-15-03-2021.json");

            ////Assert
            //Assert.Equal();

            //// Expect var loadedTimeplan = new List<Timetable>();
            ////var result = new TrainPlaner;
        }

        [Fact]
        public void When_LoadingFromJsonFile_Expect_TrainId()
        {
            // Arrange
            Train goldenArrow = new Train() { TrainId = 2, TrainName = "Golden Arrow", MaxSpeed = 120, IsOperated = true };
            Station stonecro = new Station("Stonecro");

            ITravelPlan travelPlan = new TrainPlaner(goldenArrow, stonecro);

            // Act
            travelPlan.Load(_defaultSavePath + "travelPlans-2-Golden Arrow-15-03-2021.json");

            //Assert
            Assert.Equal(2, travelPlan.Train.TrainId);

            // Expect var loadedTimeplan = new List<Timetable>();
            //var result = new TrainPlaner;
        }
    }
}
