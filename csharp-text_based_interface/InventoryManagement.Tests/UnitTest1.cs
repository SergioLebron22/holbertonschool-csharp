using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using InventoryLibrary;

namespace InventoryManagement.Tests
{
    public class JSONStorageTests
    {
        private readonly string testFilePath = Path.Combine("storage", "test_inventory_manager.json");

        /// <summary>
        /// Helper method to create a test-specific JSONStorage instance.
        /// </summary>
        private JSONStorage CreateTestStorage()
        {
            var storage = new JSONStorage();

       
            var filePathField = typeof(JSONStorage).GetField("filePath", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            filePathField?.SetValue(storage, testFilePath);

            return storage;
        }

        [Fact]
        public void Test_New_And_All_Methods()
        {
            
            JSONStorage storage = CreateTestStorage();
            Item item = new Item("TestItem");

            
            storage.New(item);
            var objects = storage.All();

            
            Assert.Single(objects);
            Assert.Contains($"Item.{item.id}", objects.Keys);
        }

        [Fact]
        public void Test_Save_And_Load_Methods()
        {
            
            JSONStorage storage = CreateTestStorage();
            Item item = new Item("TestItem");
            storage.New(item);

            storage.Save(); 
            storage.Load(); 
            var objects = storage.All();

            Assert.Single(objects);
            Assert.Contains($"Item.{item.id}", objects.Keys);

            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Fact]
        public void Test_Empty_File_Load()
        {
           
            JSONStorage storage = CreateTestStorage();
            Directory.CreateDirectory("storage");
            File.WriteAllText(testFilePath, string.Empty);

            storage.Load();
            var objects = storage.All();

            Assert.Empty(objects);

            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Fact]
        public void Test_Nonexistent_File_Load()
        {
            JSONStorage storage = CreateTestStorage();

            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }

            storage.Load();
            var objects = storage.All();

            Assert.Empty(objects);
        }
    }
}