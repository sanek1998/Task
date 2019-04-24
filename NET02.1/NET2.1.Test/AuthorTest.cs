using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02._1;

namespace NET2._1.Test
{
    [TestClass]
    public class AuthorTest
    {
        private Author _author;
        private const int Length = 200;

        [TestInitialize]
        public void InitializeAuthor()
        {
            _author = new Author("Fyodor", "Dostoyevsky");
        }

        [TestMethod]
        public void NotNullFirstNameTest()
        {
            Assert.IsNotNull(_author.FirstName);
        }

        [TestMethod]
        public void NotNullLastNameTest()
        {
            Assert.IsNotNull(_author.LastName);
        }

        [TestMethod]
        public void IsTrueFirstNameLengthTest()
        {
            Assert.IsTrue(_author.FirstName.Length < Length);
        }

        [TestMethod]
        public void IsTrueFLastNameLengthTest()
        {
            Assert.IsTrue(_author.LastName.Length < Length);
        }
    }
}