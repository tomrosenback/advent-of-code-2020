using Day3;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class Day3UnitTests
    {
        [Fact]
        public void ReadSlopes()
        {
            var slopes = new Application().GetSlopes("day3-slopes.txt");
            Assert.Equal(5, slopes.Count());

            var slope = slopes.First();
            Assert.Equal(1, slope.X);
            Assert.Equal(1, slope.Y);
            Assert.Equal(2, slope.Test);

            slope = slopes.Last();
            Assert.Equal(1, slope.X);
            Assert.Equal(2, slope.Y);
            Assert.Equal(2, slope.Test);
        }

        [Fact]
        public void ReadPatterns()
        {
            var patterns = new Application().GetPatterns("day3-test.txt");
            Assert.Equal(11, patterns.Count());
        }

        [Fact]
        public void CollisionCount()
        {
            var app = new Application();
            var patterns = app.GetPatterns("day3-test.txt");
            var slopes = app.GetSlopes("day3-slopes.txt");
            var slope = slopes.ElementAt(2);
            var collisions = app.FindCollisions(patterns, slope);
            var count = collisions.Select(c => c).Sum();

            Assert.Equal(slope.Test, count);
        }

        [Fact]
        public void CollisionCountBySlope()
        {
            var app = new Application();
            var patterns = app.GetPatterns("day3-test.txt");
            var slopes = app.GetSlopes("day3-slopes.txt");
            
            foreach (var slope in slopes)
            {
                var collisions = app.FindCollisions(patterns, slope);
                var count = collisions.Select(c => c).Sum();
                Assert.Equal(slope.Test, count);
            }    
            
            Assert.Equal(336, app.GetMultipliedCollisions(patterns, slopes));
        }
    }
}
