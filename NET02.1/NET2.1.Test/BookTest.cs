using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02._1;

namespace NET2._1.Test
{
    [TestClass]
    public class BookTest
    {
        private Book _book;
        private const int Length = 1000;

        [TestInitialize]
        public void InitializeCatalog()
        {
            _book = new Book("Idiot", "978-5-38-904730-3", new DateTime(1657, 11, 04),
                new Author("Fyodor", "Dostoyevsky"));
        }

        [TestMethod]
        public void AreEqualBookTypeTest()
        {
            Assert.AreEqual(_book.GetType(), typeof(Book));
        }

        [TestMethod]
        public void InitializeDateInBook_Test()
        {
            Assert.IsFalse(_book.Date == null);
        }

        [TestMethod]
        public void TitleNotNullTest()
        {
            Assert.IsNotNull(_book.Title);
        }

        [TestMethod]
        public void IsTrueTitleLengthTest()
        {
            Assert.IsTrue(_book.Title.Length < Length);
        }
    }
}