using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET02._1;

namespace NET2._1.Test
{
    [TestClass]
    public class CatalogTest
    {
        private Catalog _catalog;

        [TestInitialize]
        public void InitializeCatalog()
        {
            var fyodorDostoyevsky = new Author("Fyodor", "Dostoyevsky");
            var levTolstoy = new Author("Lev", "Tolstoy");
            var alexanderPushkin = new Author("Alexander", "Pushkin");

            var crimeAndPunishment = new Book("Crime and punishment", "978-5-17-112393-2",
                new DateTime(1997, 07, 25),
                fyodorDostoyevsky, alexanderPushkin, levTolstoy);
            var idiot = new Book("Idiot", "978-5-38-904730-3", new DateTime(1657, 11, 04), fyodorDostoyevsky);
            var devils = new Book("Devils", "978-5-92-682607-1", new DateTime(2000, 12, 31), fyodorDostoyevsky);

            _catalog = new Catalog {crimeAndPunishment, idiot, devils};
        }

        [TestMethod]
        public void AreEqualCTest()
        {
            Assert.AreEqual(_catalog.GetType(), typeof(Catalog));
        }
    }
}