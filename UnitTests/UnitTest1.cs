using LeetCodeMinimumMovesToCaptureTheQueen;

namespace UnitTests
{
    [TestClass]
    public class SolutionTests
    {
        private Solution _solution;

        [TestInitialize]
        public void Setup()
        {
            _solution = new Solution();
        }

        [TestMethod]
        public void TestMethod1()
        {
            int a = 4, b = 3, c = 3, d = 4, e = 2, f = 5;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves,1);
        }


        [TestMethod]
        public void TestMethod2()
        {
            int a = 6, b = 1, c = 4, d = 4, e = 2, f = 2;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves,1);
        }


        [TestMethod]
        public void TestMethod3()
        {
            int a = 1, b = 6, c = 3, d = 3, e = 5, f = 6;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves, 1);
        }


        [TestMethod]
        public void TestMethod4()
        {
            int a = 5, b = 8, c = 8, d = 8, e = 1, f = 8;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves, 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int a = 4, b = 5, c = 6, d = 1, e = 4, f = 7;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int a = 1, b = 1, c = 1, d = 4, e = 1, f = 8;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves, 2);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int a = 4, b = 7, c = 8, d = 3, e = 7, f = 4;
            var moves = _solution.MinMovesToCaptureTheQueen(a, b, c, d, e, f);
            Assert.AreEqual(moves, 1);
        }


    }
}